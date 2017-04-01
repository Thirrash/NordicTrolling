using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Events;
using Enums;
using FOV;
using Managers;
using Movement;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Viking
{
    public class VikingFOV : FieldOfView
    {
        private MoveTo moveTo;
        private NavMeshAgent agent;
        GameObject closestObject = null;

        private bool isRandom;
        private bool isTrollSpotted;
        private int positionRange = 20;

        protected override void Awake()
        {
            moveTo = GetComponent<MoveTo>();
            agent = GetComponent<NavMeshAgent>();
        }

        protected override void TakeActionOnVisibleObjects()
        {

            float distance = Mathf.Infinity;
            closestObject = null;
            if (currentTargetMask.Equals(defaultTargetMask))
            {
                foreach (var visibleObject in VisibleObjects)
                {
                    var dis = Vector3.Distance(transform.position, visibleObject.transform.position);
                    if (dis < distance)
                    {
                        distance = dis;
                        closestObject = visibleObject;
                    }
                }

                if (closestObject == null)
                {
                    SwapTargetMask(true);
                    isTrollSpotted = false;
                    moveTo.DisableGoal();
                    GetComponent<Animator>().SetTrigger("Walk");
                }
                else
                {
                    moveTo.SetGoal(closestObject);
                }
                HandleAnim(closestObject);
            }
            else
            {
                foreach (GameObject visibleObject in VisibleObjects)
                {
                    if (LayerMask.LayerToName(visibleObject.layer).Equals(LayersEnum.Troll))
                    {
                        isTrollSpotted = true;
                        SwapTargetMask(false);
                        GetComponent<Animator>().SetTrigger("Run");
                    }
                }
                float dupa = (Random.Range(0, VisibleObjects.Count));
                if (VisibleObjects.Count > 0)
                {
                    closestObject = VisibleObjects.ElementAt((int)dupa);
                }
                if (moveTo.CheckIfGoalIsNull())
                {
                    if (closestObject != null)
                    {
                        moveTo.SetGoal(closestObject);
                    }
                    else
                    {
                        //moveTo.SetGoal(Random.insideUnitCircle * viewRadius);
                        moveTo.SetGoal(new Vector3(Random.Range(-positionRange, positionRange), 1, Random.Range(-positionRange, positionRange)));
                    }
                }
                HandleAnim(closestObject);

            }

            if (closestObject == null && currentTargetMask.Equals(defaultTargetMask))
            {
                SwapTargetMask(true);
                isTrollSpotted = false;
            }

            if (closestObject == null)
            {
                moveTo.DisableGoal();
            }
            else
            {
                moveTo.SetGoal(closestObject);
            }
        }

        void HandleAnim(GameObject gameObject)
        {
            //if (gameObject == null) return;
            //if (LayerMask.LayerToName(gameObject.layer) == "Troll")
            //{
            //    GetComponent<Animator>().SetTrigger("Run");
            //}
            //else
            //{
            //    GetComponent<Animator>().SetTrigger("Walk");
            //}


        }
    }
}

