using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Trolls
{
    public class TrollSpawn : MonoBehaviour
    {
        public float cooldownTime = 0.5f;
        TrollChoice choice;
        TrollCount count;
        Camera cam;

        void Start( ) {
            cam = Camera.main;
            choice = GetComponent<TrollChoice>( );
            count = GetComponent<TrollCount>( );

            StartCoroutine( OnTerrainClick( ) );
        }

        void Update( ) {

        }

        IEnumerator OnTerrainClick( ) {
            while( true ) {
                yield return new WaitUntil( ( ) => Input.GetMouseButtonDown( 0 ) );

                Ray ray = cam.ScreenPointToRay( Input.mousePosition );
                RaycastHit hit;
                LayerMask mask = 1 << 8;

                if( !Physics.Raycast( ray, out hit, 100.0f, mask ) )
                    continue;

                if( count.GetTrollCount( choice.currTrollNr ) <= 0 )
                    continue;

                Debug.Log( choice.currTrollNr );
                GameObject trollSpawned = Instantiate( choice.currTroll, hit.point, Quaternion.identity ) as GameObject;
                count.ChangeTrollCount( choice.currTrollNr, count.GetTrollCount( choice.currTrollNr ) - 1 );

                yield return new WaitForSecondsRealtime(0.1f);
                Debug.Log( trollSpawned.GetComponent<TrollBase>( ).IsStanding );
                if( !trollSpawned.GetComponent<TrollBase>( ).IsStanding ) {
                    yield return new WaitForSecondsRealtime( 0.1f );
                    TrollWalking troll = trollSpawned.GetComponent<TrollWalking>( );
                    while( true ) {
                        yield return new WaitUntil( ( ) => Input.GetMouseButtonDown( 0 ) );

                        ray = cam.ScreenPointToRay( Input.mousePosition );
                        if( !Physics.Raycast( ray, out hit, 100.0f, mask ) )
                            continue;

                        troll.EndPoint = hit.point;
                        troll.TriggerMove( );
                        break;
                    }
                }


                Debug.Log( "Spawned Troll!" );
                yield return new WaitForSecondsRealtime( cooldownTime );
            }
        }
    }
}

