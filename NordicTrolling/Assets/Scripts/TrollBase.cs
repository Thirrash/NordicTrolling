using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollBase : MonoBehaviour
{
    void Start( ) {
        gameObject.layer = ConstantsLayer.troll;
    }
}
