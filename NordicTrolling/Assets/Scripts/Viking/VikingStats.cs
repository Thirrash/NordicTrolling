using System.Collections;
using System.Collections.Generic;
using Enums;
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

        private bool died;

        void Start( ) {
            Hp = MaxHp;
        }

        public void TakeDamage( float val ) {
            Hp -= val;
            EventManager.Instance.InvokeEvent( new TrapRefreshHp( Hp, MaxHp ) );
            if( Hp <= 0.01f && !died)
                Death( );
        }

        public void InstaKill( ) {
            TakeDamage( Hp );
            EventManager.Instance.QueueEvent(new PlaySimpleSoundFromListEvent(new List<string> { SoundsEnum.VikingInsane, SoundsEnum.VikingYhhyh }));
        }

        void Death( ) {
            //Time.timeScale = 0.0f;
            died = true;
            GetComponent<Animator>().SetTrigger("Die");
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<MoveTo>().enabled = false;
            EventManager.Instance.QueueEvent(new PlaySimpleSoundFromListEvent(new List<string> { SoundsEnum.VikingDie1, SoundsEnum.VikingDie2, SoundsEnum.VikingDie3 }));
            EventManager.Instance.QueueEvent( new GameOverEvent( false ) );
        }
    }
}
