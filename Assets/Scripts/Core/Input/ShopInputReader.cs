using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Core.Input
{
    public class ShopInputReader : MonoBehaviour
    {
        [SerializeField] private UnityEvent OnPress;
        public void OpenAndCloseInventory (InputAction.CallbackContext callbackContext) {
            if (callbackContext.performed) {
                OnPress?.Invoke();
            }
        }
    }
}