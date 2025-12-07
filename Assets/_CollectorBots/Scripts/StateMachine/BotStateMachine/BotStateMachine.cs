using UnityEngine;

public class BotStateMachine : StateMachine
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _miningDistance = 2f;
    [SerializeField] private float _dropDistance = 2f;

    private IMover _botMover;
    private Inventory _resourceContainer;

    public Inventory ResourceContainer => _resourceContainer;
    public IBot Bot { get; private set; }

    public IMover GetBotMover() =>
        _botMover;

    private void Start()
    {
        AddState<Idle>(new Idle(this));
        AddState<Walk>(new Walk(this));
        AddState<Mining>(new Mining(this));
        AddState<Drop>(new Drop(this));

        TransiteTo<Idle>();
    }

    public void Init(IBot bot, IMover botMover, Inventory resourceContainer)
    {
        Bot = bot;
        _botMover = botMover;
        _resourceContainer = resourceContainer;
    }
}