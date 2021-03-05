using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSizer : MonoBehaviour
{
    public Scorer scorer;
    public Flicker3d flickerBall;
    public Animator faceAnimator;
    public Animator ballAnimator;

    public ManagerGameOver gameOverManager;
    public LandingSequencer landSequencer;

    public BallSilentCopier ballCopier;

    public GameObject ballGo;
    public Collider ballCollider;
    public Transform ballScale;
    public MeshRenderer ballRenderer;
    public MeshRenderer[] otherBallMeshes;

    public float growthUnit;
    public float currentSize;
    public float minSize;
    public float maxSize;
    public Vector3 scaleTarget;
    public Vector3 vectorZero;

    public AnimationCurve animCurve;
    public AnimationCurve gameOverCurve;

    public ParticleBurster particleManager;

    public void Start()
    {
        currentSize = ballScale.localScale.x;
        scaleTarget = new Vector3(currentSize, currentSize, currentSize);
        ballScale.transform.localScale = scaleTarget;

        vectorZero = new Vector3(0f, 0f, 0f);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Shrinker")
        {
            BallShrink();
            flickerBall.FlickerSad();
            faceAnimator.SetBool("isWinning", false);

            particleManager.burstSad();
        }
        else if (other.tag == "Grower")
        {
            BallGrow();
            scorer.SnowmanScorer();
            faceAnimator.SetBool("isWinning", true);

            particleManager.burstPlus5();

        }
        else if (other.tag == "Berry")
        {
            scorer.StrawberryScorer();

            particleManager.burstPlus1();

        }
        else if (other.tag == "LoCandy")
        {
            scorer.CandyLoScorer();

            particleManager.burstPlus10();

        }
        else if (other.tag == "MedCandy")
        {
            scorer.CandyMedScorer();

            particleManager.burstPlus20();

        }
        else if (other.tag == "HiCandy")
        {
            scorer.CandyHiScorer();

            particleManager.burstPlus50();

        }

        else if (other.tag == "LandingSequencer")
        {
            landSequencer.StartLanding();
            ballAnimator.SetBool("isRolling", false);
        }

        else if (other.tag == "GoalCone")
        {
            landSequencer.LandingOnCone();

            particleManager.burstConfetti();
        }

        else if (other.tag == "GoalSnow")
        {
            landSequencer.LandingOnSnow();
        }
    }

    public void BallGrow()
    {
        currentSize += growthUnit;
        if (currentSize < maxSize)
        {
            scaleTarget = new Vector3(currentSize, currentSize, currentSize);
            LeanTween.scale(ballGo, scaleTarget, 0.5f).setEase(animCurve).setDelay(0.25f);
        }
        else if (currentSize >= maxSize)
        {
            Debug.Log("Ball has reached max size.");
        }
    }

    public void BallShrink()
    {
        currentSize -= growthUnit;
        if (currentSize < minSize)
        {
            BallDestroyed();
        }

        else if (currentSize >= minSize)
        {
            scaleTarget = new Vector3(currentSize, currentSize, currentSize);
            LeanTween.scale(ballGo, scaleTarget, 0.5f).setEase(animCurve);
        }
        
    }

    public void BallDestroyed()
    {
        ballCopier.ballHasLost = true;
        ballCollider.enabled = false;
        //ballRenderer.enabled = false;

        for (int i = 0; i < otherBallMeshes.Length; i++)
        {
            otherBallMeshes[i].enabled = false;
        }

        LeanTween.scale(ballGo, vectorZero, 0.5f).setEase(gameOverCurve);

        gameOverManager.isGameOver = true;
        gameOverManager.WindowGameOver();

        //Destroy(ballGo);
        //lnBallJumper.ball = null;
        //ballSideController.ballPos = null;
    }
}
