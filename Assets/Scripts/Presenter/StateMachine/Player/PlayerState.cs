

namespace Presenter.StateMachine.Player
{
    public abstract class PlayerState : IState
    {
        protected PlayerStateMachine owner;
        public virtual void OnEnter(BaseStateMachine ownerSM)
        {
            owner = (PlayerStateMachine) ownerSM;
        }

        public abstract void OnExit();
        public abstract void OnUpdate();
        public abstract bool UsesFixedUpdate();
    }
}