using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enums;
using Events;
using Managers;
using UnityEngine;
using Viking;

namespace Traps
{
    public class TrapAoE : TrapBase
    {
        [SerializeField]
        float radius = 0.0f;
        [SerializeField]
        float timeActive = 0.0f;
        [SerializeField]
        float timeInactive = 0.0f;
        [SerializeField]
        float offset = 0.0f;

        SphereCollider col;
        public ParticleSystem part;
        float timer;

        protected override void Start( ) {
            base.Start( );
            timer = offset;

            part.Stop( );

            col = GetComponent<SphereCollider>( );
            col.radius = radius;
            col.enabled = false;

            ParticleSystem.EmissionModule em = part.emission;
            em.enabled = false;

            ParticleSystem.MainModule main = part.main;
            main.duration = timeActive - main.startLifetime.constant;
            main.startLifetime = radius / 5.0f;
            
            StartCoroutine( ToggleParticles( ) );
        }

        void Update( ) {
            timer += Time.deltaTime;
        }

        protected override void OnTriggerStay( Collider col ) {
            base.OnTriggerStay( col );

            if( col.gameObject.layer == ConstantsLayer.viking )
                VikingSing.Inst.stats.TakeDamage( damageValue * Time.deltaTime );
        }

        IEnumerator ToggleParticles( ) {
            ParticleSystem.EmissionModule em = part.emission;
            while( true ) {
                yield return new WaitWhile( ( ) => timer < timeInactive );
                em.enabled = true;
                part.Play( );
                //EventManager.Instance.QueueEvent(new PlaySimpleSoundEvent(SoundsEnum.AOEAttack));
                col.enabled = true;

                yield return new WaitWhile( ( ) => timer < timeInactive + timeActive );
                em.enabled = false;
                part.Stop( );
                timer = 0.0f;
                col.enabled = false;

                yield return null;
            }
        }
    }
}
