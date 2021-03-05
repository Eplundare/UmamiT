using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerGameOver : MonoBehaviour
{
    public bool isGameOver;

    public Animator ballAnimator;

    public GlobalValues gValues;
    public float originalGSpeed;
    public GameObject gameOverWindow;
    public GameObject pauseWindow;
    public GameObject scoreWindow;
    public GameObject vcam1n;
    public GameObject vcam2c;
    public GameObject vcam3go;

    public GameObject ghostObject; // GHOST OBJECT IS USED FOR A PSEUDO-LERP
    public Transform ghostObjTrans;
    public float ghostLerper;
    public float ghostTimer;
    public AnimationCurve ghostCurve;

    public float goWinPosIn;
    public float goWinPosOut;
    public float swipeTime;
    public AnimationCurve curve;

    public GameObject pauseButton;
    public GameObject resumeButton;

    public void Start()
    {
        isGameOver = false;

        originalGSpeed = -5f;
        LeanTween.moveLocalZ(ghostObject, originalGSpeed, 0f);
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
        // GHOST's POSITION DETERMINES GLOBAL SPEED.
        LeanTween.moveLocalZ(ghostObject, 0f, ghostTimer).setEase(ghostCurve); // THIS WILL SLOW DOWN GLOBAL SPEED.

        LeanTween.moveLocalY(gameOverWindow, goWinPosIn, swipeTime).setEase(curve).setDelay(ghostTimer/2f);
    }

    public void WindowPause()
    {
        isGameOver = true;
        LeanTween.moveLocalZ(ghostObject, 0f, ghostTimer).setEase(ghostCurve); // THIS WILL SLOW DOWN GLOBAL SPEED.

        LeanTween.moveLocalY(pauseWindow, goWinPosIn, swipeTime).setEase(curve).setDelay(ghostTimer/2f);

        resumeButton.SetActive(true);
        pauseButton.SetActive(false);

        BallSideController.playerIsInControl = false;

        ballAnimator.SetBool("isRolling", false);
        ballAnimator.speed = 2f;

    }

    public void WindowPunpause()
    {
        StartCoroutine(UnpauseCoroutine());
    }

    IEnumerator UnpauseCoroutine()
    {
        pauseButton.SetActive(true);
        resumeButton.SetActive(false);

        LeanTween.moveLocalY(pauseWindow, goWinPosOut, swipeTime).setEase(curve);

        LeanTween.moveLocalZ(ghostObject, originalGSpeed, ghostTimer).setEase(ghostCurve).setDelay(swipeTime/2f); // THIS WILL SLOW DOWN GLOBAL SPEED.

        ballAnimator.SetBool("isRolling", true);
        ballAnimator.speed = 1f;

        yield return new WaitForSeconds(swipeTime / 2f);
        BallSideController.playerIsInControl = true;

        //yield return new WaitForSeconds(ghostTimer + (swipeTime/2f));
        yield return new WaitForSeconds(swipeTime / 2f);
        yield return new WaitForSeconds(ghostTimer);
        isGameOver = false;
    }

    public void WindowScore()
    {
        //isGameOver = true;
        //LeanTween.moveLocalZ(ghostObject, 0f, ghostTimer).setEase(ghostCurve); // THIS WILL SLOW DOWN GLOBAL SPEED.

        LeanTween.moveLocalY(scoreWindow, goWinPosIn, swipeTime).setEase(curve).setDelay(ghostTimer);
    }

}
