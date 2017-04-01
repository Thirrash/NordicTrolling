using System.Collections;
using System.Collections.Generic;
using Events;
using Managers;
using UnityEngine;

public class HomeTownBehaviour : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Viking")
        {
            EventManager.Instance.QueueEvent(new GameOverEvent(true));
        }
    }

}
