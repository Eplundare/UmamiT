using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSilentCopier : MonoBehaviour
{
    public Transform visibleBall;
    public Transform invisibleBall;
    public Transform ballShadowParent;

    public float isballPosX;
    public float shadowPosY;
    public float isballPosZ;
    public Vector3 shadowTargetVector;

    public bool ballHasLost;
    public void Update()
    {
        if (ballHasLost == false)
        {
            // LINE FOR INVISIBLE BALL
            invisibleBall.transform.position = visibleBall.position;

            // LINES FOR SHADOW
            isballPosX = visibleBall.position.x;
            shadowPosY = ballShadowParent.position.y;
            isballPosZ = visibleBall.position.z;

            shadowTargetVector = new Vector3(isballPosX, shadowPosY, isballPosZ);

            ballShadowParent.transform.position = (shadowTargetVector);
        }
    }
}
