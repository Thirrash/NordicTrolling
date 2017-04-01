using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Viking;

namespace Traps
{
    public class TrapContinousDamage : TrapBase
    {
        protected override void Start( ) {
            base.Start( );
        }

        protected override void OnCollisionEnter( Collision col ) {
            base.OnCollisionEnter( col );

            if( col.gameObject.layer == ConstantsLayer.viking )
                VikingSing.Inst.stats.TakeDamage( damageValue * Time.deltaTime );
        }

        protected override void OnCollisionStay( Collision col ) {
            base.OnCollisionEnter( col );

            if( col.gameObject.layer == ConstantsLayer.viking )
                VikingSing.Inst.stats.TakeDamage( damageValue * Time.deltaTime );
            else if( col.gameObject.layer == ConstantsLayer.troll )
                Destroy( col.gameObject );
        }
    }
}

