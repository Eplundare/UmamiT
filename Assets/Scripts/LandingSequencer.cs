using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingSequencer : MonoBehaviour
{
    public bool initiateLandingSequence;

    public GameObject landingParent;
    public GameObject cloudsParent;

    public GameObject ballGo;
    public GameObject silentBallGo;

    public GameObject landCam3;
    public GameObject landCam4;
    public ManagerGameOver windowManager;

    public bool hasLanded;
    public GlobalValues gValues;
    public GameObject ghostObject;
    public Transform ghostObjTrans;
    public float ghostTimerStop;
    public float ghostTimerSnow;
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
        //if (initiateLandingSequence == true)
        //{
            ghostLerper = ghostObjTrans.localPosition.z;
            if (hasLanded == true)
            {
                gValues.whatSpeed = ghostLerper;

            }
        //}
        

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
        BallSideController.playerIsInControl = false;
        LeanTween.moveLocalZ(ghostObject, 0f, ghostTimerStop).setEase(ghostCurve); // THIS WILL SLOW DOWN GLOBAL SPEED.

        yield return new WaitForSeconds(0.02f);

        ballGo.transform.parent = landingParent.transform;
        silentBallGo.transform.parent = landingParent.transform;

        yield return new WaitForSeconds(1.5f);

        landCam3.SetActive(true);

        yield return new WaitForSeconds(4f);

        landCam4.SetActive(true);
        windowManager.WindowScore();

    }

    public void LandingOnSnow()
    {
        StartCoroutine(LandingOnSnowCoroutine());
    }

    IEnumerator LandingOnSnowCoroutine()
    {
        hasLanded = true;
        BallSideController.playerIsInControl = false;
        LeanTween.moveLocalZ(ghostObject, 0f, ghostTimerStop).setEase(ghostCurve); // THIS WILL SLOW DOWN GLOBAL SPEED.
        
        yield return new WaitForSeconds(0.05f);

        ballGo.transform.parent = landingParent.transform;
        silentBallGo.transform.parent = landingParent.transform;

        yield return new WaitForSeconds(1.5f);

        landCam3.SetActive(true);

        yield return new WaitForSeconds(1f);

        landCam4.SetActive(true);
        windowManager.WindowScore();

    }
}
