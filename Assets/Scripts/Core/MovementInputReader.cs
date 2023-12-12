using UnityEngine;
using UnityEngine.InputSystem;
using Utils;

namespace Core
{
    /// <summary>
    /// Intermediate script for listeners doesn't need for depend on InputSytem 
    /// </summary>
    public class MovementInputReader : MonoBehaviour
    {
        [SerializeField] private UnityEventVector2 _movementVector; // Event for prevent depedency

        public void ReadInput (InputAction.CallbackContext callbackContext) {
            Vector2 movement = callbackContext.ReadValue<Vector2>();
            _movementVector?.Invoke(movement);
        }
    }
}