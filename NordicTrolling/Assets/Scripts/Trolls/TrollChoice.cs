using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Trolls
{
    public class TrollChoice : MonoBehaviour
    {
        public GameObject[] trollObjs = new GameObject[4];
        public GameObject currTroll;
        public int currTrollNr;

        void Start( ) {
            currTroll = trollObjs[0];
            currTrollNr = 0;
        }

        void Update( ) {
            InputTrollChange( );
        }

        void InputTrollChange( ) {
            if( Input.GetButtonDown( "Select Troll 1" ) )
                currTrollNr = 0;
            else if( Input.GetButtonDown( "Select Troll 2" ) )
                currTrollNr = 1;
            else if( Input.GetButtonDown( "Select Troll 3" ) )
                currTrollNr = 2;
            else if( Input.GetButtonDown( "Select Troll 4" ) )
                currTrollNr = 3;

            currTroll = trollObjs[currTrollNr];
        }
    }
}

