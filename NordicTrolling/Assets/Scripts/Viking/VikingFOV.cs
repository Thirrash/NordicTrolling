﻿using System.Collections;
using System.Collections.Generic;
using FOV;
using Movement;
using UnityEngine;
using UnityEngine.AI;

namespace Viking
{
    public class VikingFOV : FieldOfView
    {
        private MoveTo moveTo;
        GameObject closestObject = null;

        protected override void Awake()
        {
            moveTo = GetComponent<MoveTo>();
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
            //if (distance < Mathf.Infinity)
            //{
            if (closestObject == null)
            {
                moveTo.DisableGoal();
            }
            else
            {
                moveTo.SetGoal(closestObject);
            }
            //}
        }
    }
}

