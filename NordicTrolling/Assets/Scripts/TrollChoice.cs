using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollChoice : MonoBehaviour
{
    public GameObject[] trollObjs = new GameObject[5];
    public GameObject currTroll;

    public Canvas canvas;

    void Start( ) {
        currTroll = trollObjs[0];
    }

    void InputTrollChange( ) {
        if( Input.GetButtonDown("Select Troll 1") )
            currTroll = trollObjs[0];
        else if( Input.GetButtonDown("Select Troll 2") )
            currTroll = trollObjs[1];
        else if( Input.GetButtonDown("Select Troll 3") )
            currTroll = trollObjs[2];
        else if( Input.GetButtonDown("Select Troll 4") )
            currTroll = trollObjs[3];
        else if( Input.GetButtonDown("Select Troll 5") )
            currTroll = trollObjs[4];
    }
}
