using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            LayerMask mask = 1 << 8;

            if( !Physics.Raycast( ray, out hit, 100.0f, mask ) )
                continue;
            else
                Debug.Log( hit.collider.gameObject.layer );

            if( count.GetTrollCount( choice.currTrollNr ) <= 0 )
                continue;

            GameObject trollSpawned = Instantiate( choice.currTroll, hit.point, Quaternion.identity ) as GameObject;
            count.ChangeTrollCount( choice.currTrollNr, count.GetTrollCount( choice.currTrollNr ) - 1 );

            Debug.Log( "Spawned Troll!" );
            yield return new WaitForSecondsRealtime( cooldownTime );
        }
    }
}
