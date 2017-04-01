using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapContinousDamage : TrapBase
{
    public float damageValue = 0.0f;

    protected override void Start( ) {
        base.Start( );
    }

    protected override void OnCollisionEnter( Collision col ) {
        base.OnCollisionEnter( col );

        //Viking.Inst.attack.SetAgentActive( false );

        if( col.gameObject.layer == ConstantsLayer.viking )
            Viking.Inst.stats.TakeDamage( damageValue );
    }
}
