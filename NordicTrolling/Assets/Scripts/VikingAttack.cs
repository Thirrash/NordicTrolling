﻿using System.Collections;
using System.Collections.Generic;
using Movement;
using UnityEngine;
using UnityEngine.AI;

public class VikingAttack : MonoBehaviour
{
    public LayerMask TargetMask;
    private float FightDuration = 4;
    public float RayDist = 2;
    private NavMeshAgent agent;
    private float timer;
    private float fightTimer;
    private MoveTo moveTo;
    private GameObject fightParticles;
    private bool isFighting;
    private GameObject detectedTroll;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        moveTo = GetComponent<MoveTo>();
    }

    void Update()
    {
        timer = Mathf.MoveTowards(timer, 1, Time.deltaTime);
        if (timer < 1) return;
        if (isFighting)
        {
            fightTimer = Mathf.MoveTowards(fightTimer, FightDuration, Time.deltaTime);
        }
        DetectFight();
        HandleFight();
    }

    void DetectFight()
    {
        if (isFighting) return;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, RayDist, TargetMask))
        {
            if (fightParticles == null)
            {
                fightParticles = EffectSpawner.SpawnFightParticles(transform.position + transform.forward + Vector3.up);
                SetAgentActive(false);
                detectedTroll = hit.collider.gameObject;
                isFighting = true;
            }
        }
    }

    void HandleFight()
    {
        if (fightTimer < FightDuration) return;
        if (detectedTroll != null)
        {
            Destroy(detectedTroll);
        }
        Destroy(fightParticles);
        SetAgentActive(true);
        fightTimer = 0;
        isFighting = false;

    }

    void SetAgentActive(bool active)
    {
        agent.enabled = active;
        moveTo.enabled = active;
    }
}