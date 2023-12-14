using UnityEngine;

namespace Core.Presenter.StateMachine.Player
{
    public class MovingState : PlayerState
    {
        public override void OnEnter(BaseStateMachine ownerStateMachine)
        {
            base.OnEnter(ownerStateMachine);
            
           ApplyAnimations(true);

        }
        public override void OnExit()
        {
             ApplyAnimations(false);
        }

        public override void OnUpdate()
        {
            if (!owner.IsMoving) {
               owner.ChangeState(new IdleState());
               return;
            }
            
            ApplyMovement();
            ApplyAnimations(owner.MovementInput.x, owner.MovementInput.y, true);
        }

        public override bool UsesFixedUpdate() => false;
    }
}