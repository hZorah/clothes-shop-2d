using Model.Core;
using UnityEngine;

namespace Presenter.StateMachine.Player
{
    public class PlayerStateMachine : BaseStateMachine
    {
        [SerializeField] private PlayerCoreModel _playerCoreModel;
        private Vector2 movementInput;
        private bool moving;

        public PlayerCoreModel PlayerCoreModel { get => _playerCoreModel; }
        public Vector2 MovementInput { get => movementInput; set => movementInput = value; }
        public bool Moving { get => moving; set => moving = value; }

        private void Awake() {
            ChangeState(new IdleState());
        }
    }
}