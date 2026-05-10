using UnityEngine;

public class Bootstraper : MonoBehaviour
{
    [SerializeField] private Base _base;
    [SerializeField] private ResourceCounter _counter;
    [SerializeField] private SpawnerResources _spawner;

    private void OnEnable()
    {
        _base.ResourceAdded += _counter.Add;
        _base.ResourceAdded += _spawner.Release;
    }

    private void OnDisable()
    {
        _base.ResourceAdded -= _counter.Add;
        _base.ResourceAdded -= _spawner.Release;
    }
}