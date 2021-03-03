using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSizer : MonoBehaviour
{
    public Scorer scorer;
    public Flicker3d flickerBall;
    public Animator faceAnimator;

    public GameObject ballGo;
    public Transform ballScale;
    public MeshRenderer ballRenderer;

    public float growthUnit;
    public float currentSize;
    public float minSize;
    public float maxSize;
    public Vector3 scaleTarget;

    public AnimationCurve animCurve;

    public void Start()
    {
        currentSize = 0.6f;
        scaleTarget = new Vector3(currentSize, currentSize, currentSize);
        ballScale.transform.localScale = scaleTarget;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Shrinker")
        {
            BallShrink();
            flickerBall.FlickerSad();
            faceAnimator.SetBool("isWinning", false);
        }
        else if (other.tag == "Grower")
        {
            BallGrow();
            scorer.SnowmanScorer();
            faceAnimator.SetBool("isWinning", true);
        }
        else if (other.tag == "Berry")
        {
            scorer.StrawberryScorer();
        }
        else if (other.tag == "LoCandy")
        {
            scorer.CandyLoScorer();
        }
        else if (other.tag == "MedCandy")
        {
            scorer.CandyMedScorer();
        }
        else if (other.tag == "HiCandy")
        {
            scorer.CandyHiScorer();
        }
    }

    public void BallGrow()
    {
        currentSize += growthUnit;
        if (currentSize < maxSize)
        {
            scaleTarget = new Vector3(currentSize, currentSize, currentSize);
            LeanTween.scale(ballGo, scaleTarget, 0.5f).setEase(animCurve);
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
        scaleTarget = new Vector3(currentSize, currentSize, currentSize);
        LeanTween.scale(ballGo, scaleTarget, 0.5f).setEase(animCurve);
    }

    public void BallDestroyed()
    {
        ballRenderer.enabled = false;
    }
}
