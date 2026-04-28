using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BotStateMachine : StateMachine
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _miningDistance = 2f;
    [SerializeField] private float _dropDistance = 2f;

    private IMover _mover;
    private Inventory _resourceContainer;

    public Inventory ResourceContainer => _resourceContainer;
    public IBot Bot { get; private set; }

    public IMover GetBotMover() =>
        _mover;

    private void Awake()
    {
        if (_animator == null)
        {
            _animator = GetComponent<Animator>();
        }
    }

    private void Start()
    {
        AddState<Idle>(new Idle(this));
        AddState<Walk>(new Walk(this));
        AddState<Mining>(new Mining(this));
        AddState<Drop>(new Drop(this));

        TransiteTo<Idle>();
    }

    public void Init(IBot bot, IMover mover, Inventory resourceContainer)
    {
        Bot = bot;
        _mover = mover;
        _resourceContainer = resourceContainer;
    }
}