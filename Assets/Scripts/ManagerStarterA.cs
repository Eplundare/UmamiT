using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerStarterA : MonoBehaviour
{
    public Animator upArrowAnimator;
    public GameObject upArrowGo;
    public Animator sideArrowAnimator;
    public GameObject sideArrowGo;

    public bool forgetAboutThis;
    public bool startedRolling;
    public Animator ballAnimator;
    public GlobalValues gValues;
    public GameObject ghostObject;
    public Transform ghostObjTrans;
    public float ghostTimerStop;
    public AnimationCurve ghostCurve;
    public float ghostLerper;
    public float originalGSpeed;

    private bool emptyBool;

    public void Start()
    {
        forgetAboutThis = false;
        startedRolling = false;
        BallSideController.playerIsInControl = false;
    }

    public void Update()
    {
        if (forgetAboutThis == false)
        {
            ghostLerper = ghostObjTrans.localPosition.z;
            if (startedRolling == true)
            {
                gValues.whatSpeed = ghostLerper;

            }
        }

        else if (forgetAboutThis == true)
        {
            emptyBool = true;
        }
        

    }

    public void StartRolling()
    {
        StartCoroutine(StartRollingCoroutine());

    }

    IEnumerator StartRollingCoroutine()
    {
        ballAnimator.SetBool("isRolling", true);
        startedRolling = true;
        BallSideController.playerIsInControl = true;

        upArrowAnimator.SetBool("hasServed", true);

        LeanTween.moveLocalZ(ghostObject, -5f, ghostTimerStop).setEase(ghostCurve); // THIS WILL ACCELERATE GLOBAL SPEED.

        yield return new WaitForSeconds(ghostTimerStop);

        forgetAboutThis = true;
        startedRolling = false;

        yield return new WaitForSeconds(ghostTimerStop);

        upArrowGo.SetActive(false);
        sideArrowGo.SetActive(true);

    }

    public void HideSideArrowHinter()
    {
        StartCoroutine(HideSideArrowHinterCoroutine());

    }

    IEnumerator HideSideArrowHinterCoroutine()
    {
       
        sideArrowAnimator.SetBool("hasServed", true);

        yield return new WaitForSeconds(ghostTimerStop);

        sideArrowGo.SetActive(false);

    }


}
