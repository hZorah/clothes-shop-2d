using UnityEngine;

namespace Core
{
    /// <summary>
    /// Moves the PC according to input and speed
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerCharacterMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Rigidbody2D myRigidBody;
        private Vector2 movementInput;

        public Vector2 MovementInput { set => movementInput = value; } // receives the input from an Event

        private void Start() {
            myRigidBody = GetComponent<Rigidbody2D>(); // caching rigidbody;
        }

        private void FixedUpdate() {
            myRigidBody.velocity = movementInput * _speed;
        }
    }
}