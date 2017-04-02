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

        IEnumerator OnTerrainClick( ) {
            while( true ) {
                yield return new WaitUntil( ( ) => Input.GetMouseButtonDown( 0 ) );

                Ray ray = cam.ScreenPointToRay( Input.mousePosition );
                RaycastHit hit;

                Physics.Raycast( ray, out hit, 100.0f, ConstantsLayer.BIT( ConstantsLayer.terrain ) );
                if( hit.collider.gameObject.layer != ConstantsLayer.terrain )
                    continue;

                if( count.GetTrollCount( choice.currTrollNr ) <= 0 )
                    continue;


                yield return new WaitForSecondsRealtime( 0.1f );
                if( !choice.currTroll.GetComponent<TrollBase>( ).IsStanding ) {
                    yield return new WaitForSecondsRealtime( 0.1f );
                    while( true ) {
                        yield return new WaitUntil( ( ) => Input.GetMouseButtonUp( 0 ) );

                        RaycastHit hit2;
                        ray = cam.ScreenPointToRay( Input.mousePosition );
                        Physics.Raycast( ray, out hit2, 100.0f, ConstantsLayer.BIT( ConstantsLayer.terrain ) );
                        if( hit2.collider.gameObject.layer != ConstantsLayer.terrain )
                            continue;

                        GameObject trollSpawned = Instantiate( choice.currTroll, hit.point + new Vector3( 0.0f, 1.0f, 0.0f ), Quaternion.identity ) as GameObject;
                        yield return new WaitForSecondsRealtime( 0.05f );

                        TrollWalking troll = trollSpawned.GetComponent<TrollWalking>( );
                        troll.EndPoint = hit2.point;
                        troll.TriggerMove( );
                        break;
                    }
                } else {
                    GameObject trollSpawned = Instantiate( choice.currTroll, hit.point + new Vector3( 0.0f, 1.0f, 0.0f ), Quaternion.identity ) as GameObject;
                }

                count.ChangeTrollCount( choice.currTrollNr, count.GetTrollCount( choice.currTrollNr ) - 1 );
                Debug.Log( "Spawned Troll!" );
                yield return new WaitForSecondsRealtime( cooldownTime );
            }
        }
    }
}

