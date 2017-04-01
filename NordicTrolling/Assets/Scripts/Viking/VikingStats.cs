using System.Collections;
using System.Collections.Generic;
using Events;
using Managers;
using Movement;
using UnityEngine;
using UnityEngine.AI;

namespace Viking
{
    public class VikingStats : MonoBehaviour
    {
        [SerializeField] float maxHp;
        public float MaxHp { get { return maxHp; } }

        public float Hp { get; private set; }

        void Start( ) {
            Hp = MaxHp;
        }

        public void TakeDamage( float val ) {
            Hp -= val;
            EventManager.Instance.InvokeEvent( new TrapRefreshHp( Hp, MaxHp ) );
            if( Hp <= 0.01f )
                Death( );
        }

        public void InstaKill( ) {
            TakeDamage( Hp );
        }

        void Death( ) {
            //Time.timeScale = 0.0f;
            GetComponent<Animator>().SetTrigger("Die");
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<MoveTo>().enabled = false;
            EventManager.Instance.QueueEvent( new GameOverEvent( false ) );
        }
    }
}
