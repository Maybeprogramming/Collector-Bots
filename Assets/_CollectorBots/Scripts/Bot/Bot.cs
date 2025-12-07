
using UnityEngine;

public class Bot: MonoBehaviour, IBot
{
    [SerializeField] private Base _base;
    [SerializeField] private Mover _mover;
    [SerializeField] private Resource _currentResource;
    [SerializeField] private Inventory _resourceConteiner;
    [SerializeField] private BotStateMachine _stateMachine;

    public Resource CurrentResource => _currentResource;

    public Vector3 CurrentBasePosition => _base.gameObject.transform.position;

    public bool IsBusy => _stateMachine.GetCurrentState is Idle == false;

    private void Start()
    {
        _stateMachine.Init(this, _mover, _resourceConteiner);
    }

    public void GiveResource(Resource resource)
    {
        _base.TakeResource(resource);
    }

    //Плохо! Переделать
    public void SetResourceToMine(Resource resource)
    {
        _currentResource = resource;
    }
}