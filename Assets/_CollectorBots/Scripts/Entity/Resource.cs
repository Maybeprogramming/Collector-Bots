using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField] private SpawnerResources _spawner;

    public void PutToPool()
    {
        try
        {
            _spawner.Pool.Release(this);
        }
        catch (System.Exception)
        {
            Debug.LogError($"{name}");            
        }        
    }

    public void Init(SpawnerResources spawner)
    {
        _spawner = spawner;
    }
}