using UnityEngine;

namespace Presenter.StateMachine.Player
{
    public class MovingState : PlayerState
    {
        public override void OnEnter(BaseStateMachine ownerStateMachine)
        {
            base.OnEnter(ownerStateMachine);
            
            owner.PlayerCoreModel.MainAnimator.SetBool("moving", true);

        }
        public override void OnExit()
        {
             owner.PlayerCoreModel.MainAnimator.SetBool("moving", false);
        }

        public override void OnUpdate()
        {
            if (!owner.Moving) {
               owner.ChangeState(new IdleState());
               return;
            }
            
            ApplyMovement();
            ApplyAnimations();
        }

        private void ApplyAnimations(){
            owner.PlayerCoreModel.MainAnimator.SetFloat("X", owner.MovementInput.x);
            owner.PlayerCoreModel.MainAnimator.SetFloat("Y", owner.MovementInput.y);
        }
        private void ApplyMovement() {
            Vector2 newVelocity =  owner.MovementInput * owner.PlayerCoreModel.MovementSpeed;
            owner.PlayerCoreModel.RigidBody.velocity = newVelocity;
        }

        public override bool UsesFixedUpdate() => false;
    }
}