using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollSpawn : MonoBehaviour
{
    TrollChoice choice;
    Camera cam;
    RaycastHit hit;

    void Start( ) {
        cam = Camera.main;
        choice = GetComponent<TrollChoice>( );

        StartCoroutine( OnTerrainClick( ) );
    }

    IEnumerator OnTerrainClick( ) {
        while( true ) {
            yield return new WaitUntil( ( ) => Input.GetMouseButtonDown( 0 ) );

            Ray ray = cam.ScreenPointToRay( Input.mousePosition );
            if( !Physics.Raycast( ray, out hit, ConstantsLayer.BIT( ConstantsLayer.terrainLayer ) ) )
                continue;

            GameObject trollSpawned = Instantiate( choice.currTroll, hit.point, Quaternion.identity ) as GameObject;

            Debug.Log( "Spawned Troll!" );
            yield return new WaitForSecondsRealtime( 0.5f );
        }
    }
}
