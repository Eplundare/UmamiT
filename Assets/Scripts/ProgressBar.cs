using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public GameObject progressGo;

    public float levelDuration;

    public Transform progress;
    public Transform anchorGoal;
    public Transform anchorBall;

    public Vector2 anchorGoalVect;
    public Vector2 anchorBallVect;

    public Transform bridgeGoal;
    public Transform ballPivot;

    public float totalDistance;


    public float lerper;

   
    //public void Update()
    //{
    //    totalDistance = bridgeGoal.localPosition.z - ballPivot.localPosition.z;

    //    lerper = 0f;

    //    progress.transform.localPosition = Vector2.Lerp(anchorBallVect, anchorGoalVect, lerper);

    //}

    public void ProgressStart()
    {
        LeanTween.moveLocalX(progressGo, 22f, levelDuration);
    }

}
