using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingSequencer : MonoBehaviour
{
    public GameObject landingParent;
    public GameObject cloudsParent;

    public bool hasLanded;
    public GlobalValues gValues;
    public GameObject ghostObject;
    public Transform ghostObjTrans;
    public float ghostTimer;
    public AnimationCurve ghostCurve;
    public float ghostLerper;
    public float originalGSpeed;

    public float lowPosFloat;
    public float centerPosFloat;
    public float hiPosFloat;

    public float animTime;
    public AnimationCurve animCurve;

    public void Start()
    {
        hasLanded = false;

        LeanTween.moveLocalY(landingParent, lowPosFloat, 0f);

        // FOR GHOST OBJECT
        originalGSpeed = gValues.whatSpeed;
        LeanTween.moveLocalZ(ghostObject, originalGSpeed, 0f);
    }

    public void Update()
    {
        ghostLerper = ghostObjTrans.localPosition.z;
        if (hasLanded == true)
        {
            gValues.whatSpeed = ghostLerper;

        }

    }

    public void StartLanding()
    {
        // Move Landing Island.
        LeanTween.moveLocalY(landingParent, centerPosFloat, animTime).setEase(animCurve);

        // Move clouds.
        LeanTween.moveLocalY(cloudsParent, hiPosFloat, animTime).setEase(animCurve);

    }

    public void LandingOnCone()
    {
        StartCoroutine(LandingOnConeCoroutine());
    }

    IEnumerator LandingOnConeCoroutine()
    {
        hasLanded = true;
        LeanTween.moveLocalZ(ghostObject, 0f, ghostTimer).setEase(ghostCurve); // THIS WILL SLOW DOWN GLOBAL SPEED.

        yield return new WaitForSeconds(0f);
    }

    public void LandingOnSnow()
    {
        StartCoroutine(LandingOnSnowCoroutine());
    }

    IEnumerator LandingOnSnowCoroutine()
    {
        hasLanded = true;
        LeanTween.moveLocalZ(ghostObject, 0f, ghostTimer).setEase(ghostCurve); // THIS WILL SLOW DOWN GLOBAL SPEED.

        yield return new WaitForSeconds(0f);
    }
}
