using System.Collections;
using System.Collections.Generic;
using Enums;
using Events;
using Managers;
using UnityEngine;
using Viking;

namespace Traps
{
    public class TrapSingleDamage : TrapBase
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
                VikingSing.Inst.stats.TakeDamage(damageValue);
                GetComponent<Animator>().SetTrigger("Closing");
                EventManager.Instance.QueueEvent(new PlaySimpleSoundEvent(SoundsEnum.BearTrap));
                Destroy(gameObject.GetComponent<BoxCollider>());
                Destroy(this);
            }
            else if (col.gameObject.layer == ConstantsLayer.troll)
            {
                GetComponent<Animator>().SetTrigger("Closing");
                EventManager.Instance.QueueEvent(new PlaySimpleSoundEvent(SoundsEnum.BearTrap));
                Destroy(gameObject.GetComponent<BoxCollider>());
                Destroy(col.gameObject);
            }
        }
    }
}

