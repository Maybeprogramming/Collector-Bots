using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField] private SpawnerResources _spawner;

    private bool _isClaimed;

    public bool IsClaimed => _isClaimed;

    public bool TryClaim()
    {
        if (_isClaimed)
        {
            return false;
        }

        _isClaimed = true;
        return true;
    }
    
    public void PutToPool()
    {
        Unclaim();
        _spawner.Pool.Release(this);
    }

    public void Init(SpawnerResources spawner)
    {
        _spawner = spawner;
        Unclaim();
    }

    private void Unclaim() =>
    _isClaimed = false;
}