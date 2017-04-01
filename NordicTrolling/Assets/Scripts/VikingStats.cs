using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VikingStats : MonoBehaviour
{
    [SerializeField] float hp;
    public GameObject gameOverScreen;

    void Start( ) {

    }

    public void TakeDamage( float val ) {
        hp = ( hp - val > 0.0f ) ? hp - val : 0.0f;
        if( hp <= 0.0f )
            Death( );
    }

    public void InstaKill( ) {
        hp = 0.0f;
        Death( );
    }

    void Death( ) {
        Time.timeScale = 0.0f;
        gameOverScreen.SetActive( true );
    }
}
