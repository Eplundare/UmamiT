using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerStarterA : MonoBehaviour
{
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

    public void Start()
    {
        startedRolling = false;
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
        

    }

    public void StartRolling()
    {
        StartCoroutine(StartRollingCoroutine());

    }

    IEnumerator StartRollingCoroutine()
    {
        ballAnimator.SetBool("isRolling", true);
        startedRolling = true;

        LeanTween.moveLocalZ(ghostObject, -5f, ghostTimerStop).setEase(ghostCurve); // THIS WILL SLOW DOWN GLOBAL SPEED.

        yield return new WaitForSeconds(ghostTimerStop);

        forgetAboutThis = true;
    }
}
