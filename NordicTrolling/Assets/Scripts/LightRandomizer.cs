using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRandomizer : MonoBehaviour
{
    Light light;

    void Start( ) {
        light = GetComponent<Light>( );
        light.intensity = Random.Range( 0.1f, 1.2f );
        light.color = Color.HSVToRGB( 283.0f, Random.Range( 0.0f, 60.0f ), Random.Range( 200.0f, 255.0f ) );
    }
}
