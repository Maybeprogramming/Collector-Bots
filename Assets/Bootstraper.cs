using UnityEngine;

public class Bootstraper : MonoBehaviour
{
    [SerializeField] private Base _base;
    [SerializeField] private ResourceCounter _counter;

    private void OnEnable()
    {
        _base.ResourceAdded += _counter.Add;
    }

    private void OnDisable()
    {
        _base.ResourceAdded -= _counter.Add;
    }
}