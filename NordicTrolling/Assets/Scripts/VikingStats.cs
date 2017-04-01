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
        hp -= val;
        if( hp <= 0.01f )
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
