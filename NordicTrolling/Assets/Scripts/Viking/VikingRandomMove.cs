using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Events;
using Managers;
using Movement;
using UnityEngine;
using UnityEngine.AI;

public class VikingRandomMove : MonoBehaviour
{

    private NavMeshAgent agent;
    private MoveTo moveTo;


    // Use this for initialization
    void Start ()
	{
	    agent = GetComponent<NavMeshAgent>();
	    moveTo = GetComponent<MoveTo>();
        EventManager.Instance.AddListener<VikingRandomMoveEvent>(HandleRandomMove);
	}

    private void HandleRandomMove(VikingRandomMoveEvent e)
    {
        if (e.IsEnabled)
        {
            
        }
    }

    // Update is called once per frame
	void Update () {
		
	}
}
