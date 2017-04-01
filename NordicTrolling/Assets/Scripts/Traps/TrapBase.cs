using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Traps
{
    public class TrapBase : MonoBehaviour
    {
        [SerializeField] protected float damageValue = 0.0f;

        protected virtual void Start( ) {

        }

        protected virtual void OnCollisionEnter( Collision col ) {

        }

        protected virtual void OnCollisionStay( Collision col ) {

        }

        protected virtual void OnTriggerEnter( Collider col ) {

        }

        protected virtual void OnTriggerStay( Collider col ) {

        }
    }
}

