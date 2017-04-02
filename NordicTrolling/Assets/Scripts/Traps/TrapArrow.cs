using System;
using System.Collections;
using System.Collections.Generic;
using Enums;
using Events;
using Managers;
using UnityEngine;

namespace Traps
{
    public class TrapArrow : TrapBase
    {
        [SerializeField]
        float cooldown;

        [SerializeField]
        float arrowSpeed;

        [SerializeField]
        GameObject spawned;

        [SerializeField]
        GameObject indicator;

        bool isTriggered = false;

        protected override void Start( ) {
            base.Start( );
            StartCoroutine( Spawn( ( x ) => { isTriggered = x; } ) );
        }

        protected override void OnTriggerEnter( Collider col ) {
            base.OnTriggerStay( col );

            if( col.gameObject.layer == ConstantsLayer.viking )
                isTriggered = true;
        }

        IEnumerator Spawn( Action<bool> isTriggeredPointer ) {
            while( true ) {
                yield return new WaitUntil( ( ) => isTriggered );
                isTriggeredPointer( false );

                GameObject arrow = Instantiate( spawned, indicator.transform.position, Quaternion.identity );
                EventManager.Instance.QueueEvent(new PlaySimpleSoundEvent(SoundsEnum.DragonWhoosh));
                arrow.GetComponent<Rigidbody>( ).AddForce( arrowSpeed * indicator.transform.forward, ForceMode.VelocityChange );
                arrow.GetComponent<Arrow>( ).damage = damageValue;

                yield return new WaitForSecondsRealtime( cooldown );
            }
        }
    }
}

