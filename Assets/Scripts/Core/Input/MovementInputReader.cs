using UnityEngine;
using UnityEngine.InputSystem;
using Utils;

namespace Core.Input
{
    /// <summary>
    /// Intermediate script for listeners doesn't need for depend on InputSytem 
    /// </summary>
    public class MovementInputReader : MonoBehaviour
    {
        [SerializeField] private UnityEventVector2 _movementVector; // Event for prevent depedency
        [SerializeField] private UnityEventBool _isMoving;

        public void ReadInput (InputAction.CallbackContext callbackContext) {
            if (callbackContext.started) {
                _isMoving?.Invoke(true);
            }
            if (callbackContext.canceled) {
                _isMoving?.Invoke(false);
            }
            Vector2 movement = callbackContext.ReadValue<Vector2>();
            _movementVector?.Invoke(movement);
        }
    }
}