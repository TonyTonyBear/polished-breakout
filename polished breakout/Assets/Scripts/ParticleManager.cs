using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleManager : Singleton<ParticleManager>
{
    private ParticleSystem particleSystem;
    private Vector3 positionOrigin;

    private void Awake()
    {
        particleSystem = GetComponent<ParticleSystem>();
        positionOrigin = transform.position;
    }

    public void PlayParticlesAtPosition(Vector3 position)
    {
        position.z = positionOrigin.z;
        transform.position = position;
        particleSystem.Play();
    }
}
