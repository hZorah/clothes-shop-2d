using UnityEngine;

namespace Presenter.StateMachine.Player
{
    public class IdleState : PlayerState
    {
        public override void OnEnter(BaseStateMachine ownerStateMachine)
        {
            base.OnEnter(ownerStateMachine);

            ApplyAnimations(0f, 0f, false);
            ApplyMovement();
        }
        public override void OnExit()
        {
            ApplyAnimations(true);
        }

        public override void OnUpdate()
        {
            if (owner.IsMoving)
            {
                owner.ChangeState(new MovingState());
            }
        }
        public override bool UsesFixedUpdate() => false;
    }
}