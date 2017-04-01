using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FogOfWarBehaviour : MonoBehaviour
{
    private ParticleSystem particleSystem;
    [SerializeField]
    private GameObject viking;

    [SerializeField] private float yDownTransform = -16f;
    [SerializeField] private float doMoveDuration = 2f;
    [SerializeField] private float fogDiscoverDistance = 20f;

    // Use this for initialization
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!(Vector3.Distance(transform.position, viking.transform.position) < fogDiscoverDistance)) return;
        particleSystem.Stop();
        //Destroy(particleSystem);
        particleSystem.transform.DOMoveY(yDownTransform, doMoveDuration);
        Destroy(this);
    }
}
