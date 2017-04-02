using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Events;
using Managers;
using Movement;
using UnityEngine;
using UnityEngine.AI;

namespace Viking
{
    public class VikingAttack : MonoBehaviour
    {
        public LayerMask TargetMask;
        private float FightDuration = 4;
        public float RayDist = 2;
        public float TrollStopDist = 5;
        public float TrollRunDist = 20;
        private NavMeshAgent agent;
        private float timer;
        private float fightTimer;
        private MoveTo moveTo;
        private GameObject fightParticles;
        private bool isFighting;
        private GameObject detectedTroll;

        private void Start( ) {
            agent = GetComponent<NavMeshAgent>( );
            moveTo = GetComponent<MoveTo>( );
        }

        void Update( ) {
            timer = Mathf.MoveTowards( timer, 1, Time.deltaTime );
            if( timer < 1 ) return;
            if( isFighting ) {
                fightTimer = Mathf.MoveTowards( fightTimer, FightDuration, Time.deltaTime );
            }
            DetectFight( );
            HandleFight( );
        }

        void DetectFight( ) {
            if( isFighting ) return;
            RaycastHit hit;
            if( Physics.Raycast( transform.position, transform.forward, out hit, RayDist, TargetMask ) ) {
                if( fightParticles == null ) {
                    fightParticles = EffectSpawner.SpawnFightParticles( transform.position + transform.forward + ( 3 * Vector3.up ) );
                    SetAgentActive( false );
                    detectedTroll = hit.collider.gameObject;
                    FightDuration = detectedTroll.GetComponent<Trolls.TrollBase>( ).FightTime;
                    isFighting = true;
                }
            }

            if( Physics.Raycast( transform.position, transform.forward, out hit, TrollStopDist, TargetMask ) ) {
                detectedTroll = hit.collider.gameObject;
                if( detectedTroll.GetComponent<Trolls.TrollWalking>( ) != null )
                    detectedTroll.GetComponent<Trolls.TrollWalking>( ).SetAgentActive( false );
            }

            if( Physics.Raycast( transform.position, transform.forward, out hit, TrollRunDist, TargetMask ) ) {
                detectedTroll = hit.collider.gameObject;
                if( detectedTroll.GetComponent<Trolls.TrollFast>( ) != null )
                    agent.speed = 7.0f;
            } else
                agent.speed = 3.5f;
        }

        void HandleFight( ) {
            if( fightTimer < FightDuration ) return;
            if( detectedTroll != null ) {
                Destroy( detectedTroll );
            }
            Destroy( fightParticles );
            SetAgentActive( true );
            fightTimer = 0;
            isFighting = false;

        }

        public void SetAgentActive( bool active ) {
            agent.enabled = active;
            moveTo.enabled = active;
        }
    }
}

