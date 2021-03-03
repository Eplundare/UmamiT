using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerGameOver : MonoBehaviour
{
    public bool isGameOver;

    public GlobalValues gValues;
    public GameObject gameOverWindow;
    public GameObject vcam1n;
    public GameObject vcam2c;
    public GameObject vcam3go;

    public GameObject ghostObject; // GHOST OBJECT IS USED FOR A PSEUDO-LERP
    public Transform ghostObjTrans;
    public float ghostLerper;
    public float ghostTimer;
    public AnimationCurve ghostCurve;

    public float goWinPosIn;
    public float swipeTime;
    public AnimationCurve curve;

    public void Start()
    {
        LeanTween.moveLocalZ(ghostObject, -5f, 0f);
    }

    public void Update()
    {
        ghostLerper = ghostObjTrans.localPosition.z;
        if (isGameOver == true)
        {
            gValues.whatSpeed = ghostLerper;

        }

    }

    public void WindowGameOver()
    {
        LeanTween.moveLocalZ(ghostObject, 0f, ghostTimer).setEase(ghostCurve); // THIS WILL SLOW DOWN GLOBAL SPEED.

        LeanTween.moveLocalY(gameOverWindow, goWinPosIn, swipeTime).setEase(curve).setDelay(ghostTimer);
    }
}
