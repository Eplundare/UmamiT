using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeJumpSequencer : MonoBehaviour
{
    public GlobalValues gValues;
    public BallSideController ballSideCtrl;
    public ManagerGameOver gameOverManager;
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
    public AnimationCurve animCurveSimpleS;

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
            gameOverManager.isGameOver = false; // OVERRIDES PAUSE SEQUENCE SUPPOSEDLY;

            ballRotAnim.speed = newBallRotAnimSpeed;
            gValues.whatSpeed = newGlobalSpeed;
            //LeanTween.moveLocalY(ballGo, newHeightFloat, rampDuration).setEase(animCurveBridge);
            LeanTween.moveLocalY(bridgeGo, -newHeightFloat, rampDuration).setEase(animCurveBridge);

            // Center Ball
            BallSideController.playerIsInControl = false;
            //ballSideCtrl.lerper = 0.5f;
            LeanTween.moveLocalX(ballGo, 0f, 1f).setEase(animCurveSimpleS);


        }

    }
}
