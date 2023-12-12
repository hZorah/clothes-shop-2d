using UnityEngine;

namespace Presenter.StateMachine.Player
{
    public class IdleState : PlayerState
    {
        public override void OnEnter(BaseStateMachine ownerStateMachine)
        {
            base.OnEnter(ownerStateMachine);

            ApplyAnimations();
            ApplyMovement();
        }
        public override void OnExit()
        {
            owner.PlayerCoreModel.MainAnimator.SetBool("moving", true);
        }

        public override void OnUpdate()
        {
            if (owner.Moving)
            {
                owner.ChangeState(new MovingState());
            }
        }

        private void ApplyAnimations()
        {
            owner.PlayerCoreModel.MainAnimator.SetFloat("X", 0f);
            owner.PlayerCoreModel.MainAnimator.SetFloat("Y", 0f);
            owner.PlayerCoreModel.MainAnimator.SetBool("moving", false);
        }

        private void ApplyMovement()
        {
            owner.PlayerCoreModel.RigidBody.velocity = Vector2.zero;
        }

        public override bool UsesFixedUpdate() => false;
    }
}