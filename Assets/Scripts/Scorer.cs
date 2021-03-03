using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scorer : MonoBehaviour
{
    public float currentPoints;
    public TextMeshProUGUI tmpPointsDisplay;
    public Flicker3d flickerBall;
    public Animator sprinkles1Animator;
    public Animator sprinkles2Animator;

    public float snowmanPoint;
    public float loCandyPoint;
    public float medCandyPoint;
    public float hiCandyPoint;

    public void Start()
    {
        currentPoints = 0f;
        tmpPointsDisplay.text = "" + currentPoints;
    }

    public void StrawberryScorer()
    {
        currentPoints++;
        tmpPointsDisplay.text = "" + currentPoints;
        flickerBall.Flicker();
    }

    public void SnowmanScorer()
    {
        currentPoints += snowmanPoint;
        tmpPointsDisplay.text = "" + currentPoints;
        flickerBall.Flicker();

    }

    public void CandyLoScorer()
    {
        currentPoints += loCandyPoint;
        tmpPointsDisplay.text = "" + currentPoints;
        sprinkles1Animator.SetBool("isWinning", true);
    }

    public void CandyMedScorer()
    {
        currentPoints += medCandyPoint;
        tmpPointsDisplay.text = "" + currentPoints;
        sprinkles2Animator.SetBool("isWinning", true);

    }

    public void CandyHiScorer()
    {
        currentPoints += hiCandyPoint;
        tmpPointsDisplay.text = "" + currentPoints;
        sprinkles1Animator.SetBool("isWinning", true);
        sprinkles2Animator.SetBool("isWinning", true);

    }
}
