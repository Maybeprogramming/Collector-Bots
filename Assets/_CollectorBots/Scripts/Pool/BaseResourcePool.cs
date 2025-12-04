using UnityEngine;
using UnityEngine.Pool;

public class BaseResourcePool<T> : MonoBehaviour where T : Resource
{
    [SerializeField] private T _prefab;
    [SerializeField] private bool _collectionCheck;
    [SerializeField] private int _defaultCapacity;
    [SerializeField] private int _poolMaxSize;

    public ObjectPool<T> Pool { get; protected set; }

    protected void PoolInit()
    {
        Pool = new ObjectPool<T>
            (
                () => Create(),
                (resource) => Get(resource),
                (resource) => Release(resource), 
                (resource) => ToDestroy(resource), 
                _collectionCheck, 
                _defaultCapacity, 
                _poolMaxSize
            );
    }

    private void ToDestroy(T resource) =>    
        GameObject.Destroy(resource);
    

    private void Release(T resource) =>    
        resource.gameObject.SetActive(false);
    

    private void Get(T resource) =>    
        resource.gameObject.SetActive(true);
    

    public T Create() =>   
         Instantiate(_prefab, Vector3.zero, Quaternion.identity);    
}