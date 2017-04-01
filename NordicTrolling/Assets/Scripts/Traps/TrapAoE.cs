using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        ParticleSystem part;
        float timer;

        protected override void Start( ) {
            base.Start( );
            timer = offset;

            part = gameObject.GetComponentInChildren<ParticleSystem>( );
            part.Stop( );

            col = GetComponent<SphereCollider>( );
            col.radius = radius;
            col.enabled = false;

            ParticleSystem.EmissionModule em = part.emission;
            em.enabled = false;

            ParticleSystem.ShapeModule shape = part.shape;
            shape.radius = radius;

            ParticleSystem.MainModule main = part.main;
            main.duration = timeActive - main.startLifetime.constant;
            
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
