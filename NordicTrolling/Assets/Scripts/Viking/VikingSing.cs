using System.Collections;
using System.Collections.Generic;
using Enums;
using Events;
using Managers;
using UnityEngine;

namespace Viking
{
    public class VikingSing : MonoBehaviour
    {
        public static VikingSing Inst { get; private set; }
        public VikingStats stats;
        public VikingAttack attack;

        void Start( ) {
            if( Inst == null )
                Inst = this;
            else
                Destroy( this );
            stats = GetComponent<VikingStats>( );
            attack = GetComponent<VikingAttack>( );
        }
    }
}

