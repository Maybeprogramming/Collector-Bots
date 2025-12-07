using System.Collections;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private ResourceCounter _counter;
    [SerializeField] private Transform _target;
    [SerializeField] private Bot _bot;
    [SerializeField] private ResurceScanner _resurceScanner;
    [SerializeField] private float _delayTime;

    private Coroutine _working;
    private WaitForSeconds _wait;

    private void Start()
    {
        _wait = new WaitForSeconds(_delayTime);
        _working = StartCoroutine(Working());
    }

    public void TakeResource(Resource resource)
    {
        _counter.Add();
        resource.Contact();

        Debug.Log($"База приняла ресурс {resource.name}");
    }

    private void DoWork()
    {
        if (_resurceScanner.TryGetResource(out Resource resource) && _bot.IsBusy == false)
        {
            _bot.SetResourceToMine(resource);
        }
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