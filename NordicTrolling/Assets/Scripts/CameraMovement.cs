using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraMovement : MonoBehaviour
{
    delegate void InputMethodPointer( );

    [SerializeField] float sensitivityHor = 0.25f;
    [SerializeField] float sensitivityVer = 0.25f;
    [SerializeField] float sensitivityZoom = 2.5f;

    [SerializeField] float horizontalBound = 25.0f;
    [SerializeField] float verticalBoundUp = -10.0f;
    [SerializeField] float verticalBoundDown = -40.0f;
    [SerializeField] float zoomInBound = -2.0f;
    [SerializeField] float zoomOutBound = -40.0f;

    int mousePosFromBorderToMoveHor = 15;
    int mousePosFromBorderToMoveVer = 10;

    /// <summary>
    /// If false, choose mouse on screen border movement
    /// </summary>
    public bool chooseKeyboardMovement = true;

    Camera cam;
    InputMethodPointer movementMethod;

    void Start( ) {
        cam = Camera.main;
        movementMethod = (chooseKeyboardMovement) ? new InputMethodPointer(CheckKeyboard) : new InputMethodPointer(CheckMouse);
    }

    void Update( ) {
        movementMethod( );
        CheckZoom( );
    }

    void CheckKeyboard( ) {
        CheckKeyboardHorizontal( );
        CheckKeyboardVertical( );
    } 

    void CheckKeyboardHorizontal( ) {
        float sign = Input.GetAxis( "Horizontal" );
        float offset;

        if( sign > 0.0f )
            offset = sensitivityHor;
        else if( sign < 0.0f )
            offset = -sensitivityHor;
        else
            return;

        float camPosHor = cam.transform.position.x;
        float newPosHor = Mathf.Clamp( camPosHor + offset, -horizontalBound, horizontalBound );
        cam.transform.position = new Vector3( newPosHor, cam.transform.position.y, cam.transform.position.z );
    }

    void CheckKeyboardVertical( ) {
        float sign = Input.GetAxis( "Vertical" );
        float offset;

        if( sign > 0.0f )
            offset = sensitivityVer;
        else if( sign < 0.0f )
            offset = -sensitivityVer;
        else
            return;

        float camPosVer = cam.transform.position.z;
        float newPosVer = Mathf.Clamp( camPosVer + offset, verticalBoundDown, verticalBoundUp );
        cam.transform.position = new Vector3( cam.transform.position.x, cam.transform.position.y, newPosVer );
    }

    void CheckMouse( ) {
        CheckMouseHorizontal( );
        CheckMouseVertical( );
    }

    void CheckMouseHorizontal( ) {
        float offset = 0.0f;
        if( Input.mousePosition.x > Screen.width - mousePosFromBorderToMoveHor )
            offset = sensitivityHor;
        else if( Input.mousePosition.x < mousePosFromBorderToMoveHor )
            offset = -sensitivityHor;
        else
            return;

        float camPosHor = cam.transform.position.x;
        float newPosHor = Mathf.Clamp( camPosHor + offset, -horizontalBound, horizontalBound );
        cam.transform.position = new Vector3( newPosHor, cam.transform.position.y, cam.transform.position.z );
    }

    void CheckMouseVertical( ) {
        float offset = 0.0f;
        if( Input.mousePosition.y > Screen.height - mousePosFromBorderToMoveVer )
            offset = sensitivityVer;
        else if( Input.mousePosition.y < mousePosFromBorderToMoveVer )
            offset = -sensitivityVer;
        else
            return;

        float camPosVer = cam.transform.position.z;
        float newPosVer = Mathf.Clamp( camPosVer + offset, verticalBoundDown, verticalBoundUp );
        cam.transform.position = new Vector3( cam.transform.position.x, cam.transform.position.y, newPosVer );
    }

    void CheckZoom( ) {
        float offset = sensitivityZoom * Input.GetAxis( "Mouse ScrollWheel" );
        if( offset == 0.0f )
            return;

        if( cam.transform.position.z < zoomOutBound && offset < 0.0f )
            return;
        else if ( cam.transform.position.z > zoomInBound && offset > 0.0f )
            return;

        cam.transform.Translate( new Vector3( 0.0f, 0.0f, offset ) );
    }
}
