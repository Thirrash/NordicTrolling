using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrollCount : MonoBehaviour
{
    public Canvas canvas;
    [SerializeField] Text[] trollText = new Text[5];
    [SerializeField] int[] trollCount = new int[5];

	void Start () {
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
