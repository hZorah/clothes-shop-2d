using UnityEngine;

namespace Presenter.StateMachine
{
    public abstract class BaseStateMachine : MonoBehaviour
    {
        protected IState currentState;
        [SerializeField] string _stateName;

        private void Update() {
            if (currentState.UsesFixedUpdate()) return;
            currentState.OnUpdate();
        }

        private void FixedUpdate() {
            if (!currentState.UsesFixedUpdate()) return;
            currentState.OnUpdate();
        }

        public void ChangeState(IState newState)
        {
            if(currentState != null)
            {
                currentState.OnExit();
            }

            currentState = newState;
            currentState.OnEnter(this);
            _stateName = newState.GetType().ToString();
        }
    }
}