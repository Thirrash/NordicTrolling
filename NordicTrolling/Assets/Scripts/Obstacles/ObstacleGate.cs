using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Obstacles
{
    public class ObstacleGate : ObstacleBase
    {
        public GameObject gateObj;

        public float offsetTime = 0.0f;
        public float gateOpenedTime = 2.0f;
        public float gateClosedTime = 2.0f;
        public float gateClosingTime = 2.0f;

        float timer = 0.0f;

        protected override void Start( ) {
            base.Start( );
            timer = offsetTime;
        }

        void Update( ) {
            timer += Time.deltaTime;
            if( timer < gateOpenedTime )
                return;

            Vector3 scale = gateObj.transform.localScale;
            Vector3 pos = gateObj.transform.localPosition;

            if( timer >= gateOpenedTime && timer < gateOpenedTime + gateClosingTime ) {
                gateObj.transform.localScale = new Vector3( scale.x, 1.5f * ( timer - gateOpenedTime ) / gateClosingTime, scale.z );
                gateObj.transform.localPosition = new Vector3( pos.x, -1.0f + 0.75f * ( timer - gateOpenedTime ) / gateClosingTime, pos.z );
            } else if( timer >= gateOpenedTime + gateClosingTime + gateClosedTime &&
                timer < gateOpenedTime + 2.0f * gateClosingTime + gateClosedTime ) {
                gateObj.transform.localScale = new Vector3( scale.x, 1.5f - 1.5f * ( timer - gateOpenedTime - gateClosingTime - gateClosedTime ) / gateClosingTime, scale.z );
                gateObj.transform.localPosition = new Vector3( pos.x, -0.25f - 0.75f * ( timer - gateOpenedTime - gateClosingTime - gateClosedTime ) / gateClosingTime, pos.z );
            } else if( timer >= gateOpenedTime + 2.0f * gateClosingTime + gateClosedTime )
                timer = 0.0f;
        }
    }
}

