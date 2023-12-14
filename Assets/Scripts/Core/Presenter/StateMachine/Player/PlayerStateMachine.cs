using Core.Model;
using UnityEngine;
using View;

namespace Core.Presenter.StateMachine.Player
{
    public class PlayerStateMachine : BaseStateMachine
    {
        [SerializeField] private PlayerCoreModel _playerCoreModel;
        [SerializeField] private CosmeticsAnimator _cosmeticsAnimator;
        private Vector2 movementInput;
        private bool isMoving;

        public PlayerCoreModel PlayerCoreModel { get => _playerCoreModel; }
        public CosmeticsAnimator CosmeticsAnimator { get => _cosmeticsAnimator; set => _cosmeticsAnimator = value; }
        public Vector2 MovementInput { get => movementInput; set => movementInput = value; }
        public bool IsMoving { get => isMoving; set => isMoving = value; }

        private void Awake() {
            ChangeState(new IdleState());
        }        
    }
}