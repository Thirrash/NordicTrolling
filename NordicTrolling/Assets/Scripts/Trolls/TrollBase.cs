using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Trolls
{
    public class TrollBase : MonoBehaviour
    {
        public float FightTime { get; protected set; }
        public bool IsStanding = true;
        public Vector3 EndPos { get; set; }

        protected virtual void Start( ) {
            FightTime = 4.0f;
            IsStanding = true;
            gameObject.layer = ConstantsLayer.troll;
        }
    }
}

