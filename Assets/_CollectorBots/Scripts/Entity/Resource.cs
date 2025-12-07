using UnityEngine;
public class Resource : MonoBehaviour
{
    [SerializeField] private SpawnerResources _spawner;

    public void PutToPool()
    {
        _spawner.Pool.Release(this);
    }

    public void Init(SpawnerResources spawner)
    {
        _spawner = spawner;
    }
}