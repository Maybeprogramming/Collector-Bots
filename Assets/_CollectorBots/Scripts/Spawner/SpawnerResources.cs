using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerResources : BaseResourcePool<Resource>
{
    [SerializeField] private Transform _conteiner;
    [SerializeField] private float _minTimeSpawn;
    [SerializeField] private float _maxTimeSpawn;
    [SerializeField] private float _offsetXPosition;
    [SerializeField] private float _offsetZPosition;
    [SerializeField] private float _positionY;
    [SerializeField] private Vector3 _spawnCentrPosition;
    [SerializeField] private int _maxCount;

    public event Action Spawned;

    private void Start()
    {
        PoolInit();
        StartCoroutine(Spawning());
    }

    private void Spawn()
    {
        Vector3 newSpawnPosition = GetRandomPosition();

        Resource resource = Pool.Get();
        resource.transform.position = newSpawnPosition;
        resource.transform.rotation = Quaternion.identity;
        resource.transform.localScale = Vector3.one;
        resource.transform.parent = _conteiner.transform;
        resource.Init(this);

        Spawned?.Invoke();
    }

    private Vector3 GetRandomPosition()
    {
        float minX = _spawnCentrPosition.x - _offsetXPosition;
        float maxX = _spawnCentrPosition.x + _offsetXPosition;
        float minZ = _spawnCentrPosition.z - _offsetZPosition;
        float maxZ = _spawnCentrPosition.z + _offsetZPosition;

        return new Vector3(Random.Range(minX, maxX), _positionY, Random.Range(minZ, maxZ));
    }

    private IEnumerator Spawning()
    {
        while (enabled)
        {
            if (Pool.CountActive < _maxCount)
            {
                Spawn();
            }

            yield return GetRandomDelayTime();            
        }
    }

    private WaitForSeconds GetRandomDelayTime()
    {
        return new WaitForSeconds(Random.Range(_minTimeSpawn, _maxTimeSpawn));
    }
}