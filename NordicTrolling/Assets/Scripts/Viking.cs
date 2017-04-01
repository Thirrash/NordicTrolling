using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viking : MonoBehaviour
{
    public static Viking Inst { get; private set; }
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
