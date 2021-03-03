using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeJumpSequencer : MonoBehaviour
{
    public GlobalValues gValues;
    public Animator ballRotAnim;
    public float newBallRotAnimSpeed;
    public float newGlobalSpeed;
    public float normalGlobalSpeed;

    public GameObject ballGo;
    public GameObject bridgeGo;
    public float newHeightFloat;
    //public Vector3 newHeightVector;
    public float rampDuration;
    public AnimationCurve animCurveBridge;

    public GameObject vcam1;
    public GameObject vcam2;

    public void Start()
    {
        normalGlobalSpeed = gValues.whatSpeed;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bridge")
        {
            vcam1.SetActive(false);

            ballRotAnim.speed = newBallRotAnimSpeed;
            gValues.whatSpeed = newGlobalSpeed;
            //LeanTween.moveLocalY(ballGo, newHeightFloat, rampDuration).setEase(animCurveBridge);
            LeanTween.moveLocalY(bridgeGo, -newHeightFloat, rampDuration).setEase(animCurveBridge);


        }

    }
}
