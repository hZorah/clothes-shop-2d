using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model.Core
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerCoreModel : MonoBehaviour
    {
        [SerializeField] private Animator _mainAnimator;
        [SerializeField] private float _movementSpeed;
        private Rigidbody2D mRigidBody;

        public float MovementSpeed { get => _movementSpeed; }
        public Animator MainAnimator { get => _mainAnimator; }
        public Rigidbody2D RigidBody {             
            get {
                if (mRigidBody == null) {
                    mRigidBody = GetComponent <Rigidbody2D> (); //caching rigidbody;    
                }
                return mRigidBody;
            }
        }
    }
}
