using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Trolls
{
    public class TrollResupply : MonoBehaviour
    {
        [SerializeField]
        float[] spawnRate = new float[4];

        [SerializeField]
        Text popUp;

        TrollCount count;

        float slowestRate;
        float[] timer = new float[4];

        void Start( ) {
            count = GetComponent<TrollCount>( );
        }

        void Update( ) {
            for( int i = 0; i < 4; i++ )
                timer[i] += Time.deltaTime;

            if( timer[0] >= spawnRate[0] )
                ChangeTroll( 0 );

            if( timer[1] >= spawnRate[1] ) 
                ChangeTroll( 1 );

            if( timer[2] >= spawnRate[2] ) 
                ChangeTroll( 2 );

            if( timer[3] >= spawnRate[3] ) 
                ChangeTroll( 3 );
        }

        void ChangeTroll( int noTroll ) {
            count.ChangeTrollCount( noTroll, count.GetTrollCount( noTroll ) + 1 );
            timer[noTroll] = 0.0f;
            popUp.text = "Resupplied Troll!";
            switch( noTroll ) {
                case 0:
                    popUp.color = Color.yellow;
                    break;
                case 1:
                    popUp.color = Color.red;
                    break;
                case 2:
                    popUp.color = Color.green;
                    break;
                case 3:
                    popUp.color = Color.blue;
                    break;
            }
        }
    }
}

