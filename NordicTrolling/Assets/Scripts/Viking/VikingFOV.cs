using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Events;
using FOV;
using Managers;
using Movement;
using UnityEngine;
using UnityEngine.AI;

namespace Viking
{
    public class VikingFOV : FieldOfView
    {
        private MoveTo moveTo;
        GameObject closestObject = null;

        private bool isRandom;

        protected override void Awake()
        {
            moveTo = GetComponent<MoveTo>();
        }

        protected override void Start()
        {
            EventManager.Instance.AddListener<VikingRandomMoveEvent>(AdaptToRandomMove);
            base.Start();
        }


        protected override void TakeActionOnVisibleObjects()
        {

            float distance = Mathf.Infinity;
            closestObject = null;
            foreach (var visibleObject in VisibleObjects)
            {
                var dis = Vector3.Distance(transform.position, visibleObject.transform.position);
                if (dis < distance)
                {
                    distance = dis;
                    closestObject = visibleObject;
                }
            }

            EventManager.Instance.InvokeEvent(closestObject == null
                ? new VikingRandomMoveEvent(true)
                : new VikingRandomMoveEvent(false));

            if (isRandom)
            {
                int dupa = Random.Range(0, VisibleObjects.Count - 1);
                if (VisibleObjects.Count > 0)
                {
                    closestObject = VisibleObjects.ElementAt(dupa);
                }
                else
                {
                    //moveTo.SetGoal();
                }
            }

        }
        private void AdaptToRandomMove(VikingRandomMoveEvent e)
        {
            if (e.IsEnabled)
            {
                moveTo.DisableGoal();
                SwapTargetMask(true);
                isRandom = true;
            }
            else
            {
                moveTo.SetGoal(closestObject);
                SwapTargetMask(false);
                isRandom = false;
            }
        }
    }
}

