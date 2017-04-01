using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Enums;
using UnityEngine;

public class TreeTrap : MonoBehaviour
{
    [SerializeField]
    private GameObject tree;
    private BoxCollider collider;

    // Use this for initialization
    void Start( ) {
        collider = GetComponent<BoxCollider>( );
    }

    private void OnTriggerEnter( Collider other ) {
        if( other.gameObject.layer == ConstantsLayer.viking )
            tree.transform.DORotate( new Vector3( 0.0f, 0.0f, 90f ), 1f, RotateMode.WorldAxisAdd );
    }
}
