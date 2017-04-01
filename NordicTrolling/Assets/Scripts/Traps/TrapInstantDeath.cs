using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Viking;

namespace Traps
{
    public class TrapInstantDeath : TrapBase
    {
        protected override void Start( ) {
            base.Start( );
        }

        protected override void OnCollisionEnter( Collision col ) {
            base.OnCollisionEnter( col );

            if( col.gameObject.layer == ConstantsLayer.viking )
                VikingSing.Inst.stats.InstaKill( );
        }
    }
}

