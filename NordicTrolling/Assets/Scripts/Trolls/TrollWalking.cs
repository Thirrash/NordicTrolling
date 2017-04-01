using System.Collections;
using System.Collections.Generic;
using Movement;
using UnityEngine;
using UnityEngine.AI;

namespace Trolls
{
    public class TrollWalking : MonoBehaviour
    {
        TrollBase troll;
        NavMeshAgent nav;
        MoveTo move;

        Vector3 startPoint;
        public Vector3 EndPoint;
        bool isToGoToEnd = true;

        void Start( ) {
            troll = GetComponent<TrollBase>( );
            troll.IsStanding = false;
            startPoint = transform.position;

            nav = gameObject.AddComponent<NavMeshAgent>( );
            move = gameObject.AddComponent<MoveTo>( );
            SetAgentActive( false );
        }

        void Update( ) {
            if( nav.enabled == false )
                return;

            if( !nav.pathPending )
                if( nav.remainingDistance <= nav.stoppingDistance )
                    if( !nav.hasPath || nav.velocity.sqrMagnitude == 0f )
                        Move(  );
        }

        public void TriggerMove( ) {
            SetAgentActive( true );
            Move( );
        }

        void Move( ) {
            move.SetGoal( ( !isToGoToEnd ) ? startPoint : EndPoint );
            isToGoToEnd = !isToGoToEnd;
        }

        public void SetAgentActive( bool active ) {
            nav.enabled = active;
            move.enabled = active;
        }
    }

}
