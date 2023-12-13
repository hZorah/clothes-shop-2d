using UnityEngine;

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

        protected void ApplyMovement () {
            Vector2 newVelocity = owner.MovementInput * owner.PlayerCoreModel.MovementSpeed;
            owner.PlayerCoreModel.RigidBody.velocity = newVelocity;
        }

        protected void ApplyAnimations (bool isMoving) {   
            owner.PlayerCoreModel.MainAnimator.SetBool("moving", isMoving);
            owner.CosmeticsAnimator.SetBool("moving", isMoving);
        }

        protected void ApplyAnimations (float x, float y) {
            owner.PlayerCoreModel.MainAnimator.SetFloat("X", x);
            owner.PlayerCoreModel.MainAnimator.SetFloat("Y", y);

            owner.CosmeticsAnimator.SetFloat("X", x);
            owner.CosmeticsAnimator.SetFloat("Y", y);
        }

         protected void ApplyAnimations (float x, float y, bool moving) {
            ApplyAnimations(x, y);
            ApplyAnimations(moving);
         }
    }
}