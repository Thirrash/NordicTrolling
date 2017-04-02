using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Trolls
{
    public class TrollCount : MonoBehaviour
    {
        public Canvas canvas;
        [SerializeField] Text[] trollText = new Text[4];
        [SerializeField] int[] trollCount = new int[4];

        void Start( ) {
            for( int i = 0; i < trollCount.Length; i++ )
                ChangeTrollCount( i, trollCount[i] );
        }

        public int GetTrollCount( int noTroll ) {
            return trollCount[noTroll];
        }

        public void ChangeTrollCount( int noTroll, int newNumber ) {
            trollCount[noTroll] = newNumber;
            trollText[noTroll].text = newNumber.ToString( );
        }
    }

}
