using System;
using UnityEngine;

namespace Events
{
    public class TrapRefreshHp : GameEvent
    {
        public float hpRatio;

        public TrapRefreshHp( float hp, float maxHp ) {
            hpRatio = hp / maxHp;
        }
    }
}
