using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Obstacles
{
    public class ObstacleBase : MonoBehaviour
    {
        protected virtual void Start( ) {
            gameObject.layer = ConstantsLayer.obstacle;
        }
    }
}

