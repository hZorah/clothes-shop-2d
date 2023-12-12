namespace Presenter.StateMachine
{
    public interface IState
    {
        public void OnEnter(BaseStateMachine ownerStateMachine);

        public void OnUpdate();
        public void OnExit(); 
        public bool UsesFixedUpdate();
    }
}