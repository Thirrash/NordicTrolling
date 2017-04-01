using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float t { get; private set; }
    public float resetTime = 0.1f;

    void Start( ) {
        t = 0.0f;
    }

    void Update( ) {
        t += Time.deltaTime;
        if( t > resetTime )
            t = 0.0f;
    }
}
