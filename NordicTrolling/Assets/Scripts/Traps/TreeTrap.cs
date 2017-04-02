﻿using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Enums;
using UnityEngine;

public class TreeTrap : MonoBehaviour
{
    [SerializeField]
    private GameObject tree;
    private BoxCollider collider;
    public Vector3 rotation;

    // Use this for initialization
    void Start( ) {
        collider = GetComponent<BoxCollider>( );
    }

    private void OnTriggerEnter( Collider other ) {
        if( other.gameObject.layer == ConstantsLayer.viking )
            tree.transform.DORotate( rotation, 1f, RotateMode.WorldAxisAdd );
        Destroy( gameObject );
    }
}
