using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Viking
{
    public class RadiusCheck : MonoBehaviour
    {
        float radius;

        void Start( ) {
            radius = GetComponentInParent<VikingFOV>( ).viewRadius;
            transform.localScale = new Vector3( 2.0f * radius, transform.localScale.y, 2.0f * radius );
        }
    }
}

