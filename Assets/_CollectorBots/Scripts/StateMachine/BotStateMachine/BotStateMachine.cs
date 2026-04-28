public class BotStateMachine : StateMachine
{
    private IMover _mover;
    private Inventory _resourceContainer;

    public Inventory ResourceContainer => _resourceContainer;
    public IBot Bot { get; private set; }

    public IMover GetBotMover => _mover;

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