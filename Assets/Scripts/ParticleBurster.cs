using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBurster : MonoBehaviour
{
    public ParticleSystem plus1;
    public ParticleSystem plus5;
    public ParticleSystem plus10;
    public ParticleSystem plus20;
    public ParticleSystem plus50;

    public ParticleSystem sad;

    public ParticleSystem confettiA;
    public ParticleSystem confettiB;


    public void Start()
    {
        plus1.Stop();
        plus5.Stop();
        plus10.Stop();
        plus20.Stop();
        plus50.Stop();
        sad.Stop();

        confettiA.Stop();
        confettiB.Stop();

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            burstPlus1();
        }
    }

    public void burstPlus1()
    {
        plus1.Emit(1);
    }

    public void burstPlus5()
    {
        plus5.Emit(1);
    }

    public void burstPlus10()
    {
        plus10.Emit(1);
    }

    public void burstPlus20()
    {
        plus20.Emit(1);
    }

    public void burstPlus50()
    {
        plus50.Emit(1);
    }

    public void burstSad()
    {
        sad.Emit(1);
    }

    public void burstConfetti()
    {
        confettiA.Emit(20);
        confettiB.Emit(20);

    }
}
