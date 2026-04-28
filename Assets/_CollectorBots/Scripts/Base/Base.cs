using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using CollectorBots.Sheduler;

[RequireComponent(typeof(ResourceScanner))]
public class Base : MonoBehaviour
{
    [SerializeField] private ResourceCounter _counter;
    [SerializeField] private Transform _target;
    [SerializeField] private List<Bot> _bots;
    [SerializeField] private ResourceScanner _resurceScanner;
    [SerializeField] private float _delayTime;

    private Coroutine _working;
    private WaitForSeconds _wait;
    private TaskSheduler _taskSheduler;

    private void Awake()
    {
        if (_resurceScanner == null)
        {
            _resurceScanner = GetComponent<ResourceScanner>();
        }

        if (_counter == null)
        {
            _counter = GetComponent<ResourceCounter>();
        }
    }

    private void Start()
    {
        _wait = new WaitForSeconds(_delayTime);
        _taskSheduler = new TaskSheduler(_bots ?? new List<Bot>());
        _working = StartCoroutine(Working());
    }

    public void TakeResource(Resource resource)
    {
        _counter.Add();
        resource.PutToPool();

        Debug.Log($"База приняла ресурс {resource.name}");
    }

    private void DoWork()
    {
        List<Resource> foundResources = null;

        while (_resurceScanner.TryGetResource(out Resource resource))
        {
            foundResources ??= new List<Resource>();
            foundResources.Add(resource);
        }

        if (foundResources != null)
        {
            Vector3 basePosition = transform.position;

            foreach (Resource resource in foundResources.OrderBy(r => Vector3.Distance(basePosition, r.transform.position)))
            {
                _taskSheduler.AddTask(new Task(resource, basePosition));
            }
        }

        int assignedTasksCount = _taskSheduler.AssignTasks();

        if (_taskSheduler.PendingTasksCount > 0 && assignedTasksCount == 0)
        {
            Debug.Log("Нет свободных рабочих");
        }
    }

    private IEnumerator Working()
    {
        while (enabled) 
        {
            yield return _wait;
            DoWork();
        }
    }
}