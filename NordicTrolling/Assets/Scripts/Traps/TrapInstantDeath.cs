using System.Collections;
using System.Collections.Generic;
using Enums;
using Events;
using Managers;
using UnityEngine;
using Viking;

namespace Traps
{
    public class TrapInstantDeath : TrapBase
    {
        protected override void Start()
        {
            base.Start();
        }

        protected override void OnCollisionEnter(Collision col)
        {
            base.OnCollisionEnter(col);

            if (col.gameObject.layer == ConstantsLayer.viking)
            {
                VikingSing.Inst.stats.InstaKill();
                EventManager.Instance.QueueEvent(new PlaySimpleSoundEvent(SoundsEnum.LakeSplash));
            }
            else if (col.gameObject.layer == ConstantsLayer.troll)
                Destroy(col.gameObject);
        }
    }
}

