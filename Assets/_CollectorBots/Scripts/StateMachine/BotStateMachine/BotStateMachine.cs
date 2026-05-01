public class BotStateMachine : StateMachine
{
    private IMover _mover;
    private Inventory _inventory;

    public Inventory Inventory => _inventory;
    public IBot Bot { get; private set; }

    public IMover GetBotMover => _mover;

    private void Start()
    {
        AddState<IdleState>(new IdleState(this));
        AddState<WalkState>(new WalkState(this));
        AddState<MiningState>(new MiningState(this));
        AddState<DropState>(new DropState(this));

        TransiteTo<IdleState>();
    }

    public void Init(IBot bot, IMover mover, Inventory resourceContainer)
    {
        Bot = bot;
        _mover = mover;
        _inventory = resourceContainer;
    }
}