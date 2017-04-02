using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Events;
using Managers;

public class HpUI : MonoBehaviour
{
    Image targetScale;

    void Start( ) {
        EventManager.Instance.AddListener<TrapRefreshHp>( ChangeBarScale );
        targetScale = GetComponent<Image>( );
    }

    void ChangeBarScale( TrapRefreshHp t ) {
        RectTransform tr = GetComponent<RectTransform>( );
        if( t.hpRatio < 0 ) t.hpRatio = 0;
        tr.localScale = new Vector3( t.hpRatio, 1.0f, 1.0f );
    }
}
