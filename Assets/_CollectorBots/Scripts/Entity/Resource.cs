using UnityEngine;
public class Resource : MonoBehaviour
{
    [SerializeField] ResourceSpawner _spawner;

    public void Contact()
    {
        _spawner.Pool.Release(this);
    }

    public void Init(ResourceSpawner spawner)
    {
        _spawner = spawner;
    }
}