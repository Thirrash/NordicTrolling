using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Traps
{
    public class Arrow : MonoBehaviour
    {
        public float damage;
        float timer = 0.0f;

        void Update( ) {
            timer += Time.deltaTime;
            if( timer > 5.0f )
                Destroy( gameObject );
        }


        void OnCollisionEnter( Collision col ) {
            if( col.gameObject.layer == ConstantsLayer.viking ) {
                Viking.VikingSing.Inst.stats.TakeDamage( damage );
                Destroy( gameObject );
            }

            if( col.gameObject.layer == ConstantsLayer.obstacle || col.gameObject.layer == ConstantsLayer.troll )
                Destroy( gameObject );
        }
    }
}

