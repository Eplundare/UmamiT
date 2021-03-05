using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LnBallJumper : MonoBehaviour
{
    public bool isJumping;
    public GameObject ball;
    public float jumpHeight;
    //public Transform snomanJumpPos;
    //public Transform berryHiJumpPos;
    //public Transform berryLoJumpPos;
    public float snomanJumpTime;
    public float berryJumpTime;
    public AnimationCurve riseCurve;
    public AnimationCurve fallCurve;

    public GameObject ballShadowMesh;
    private Vector3 smallShadowVector;

    public void Start()
    {
        smallShadowVector = new Vector3(0.6f, 0.6f, 0.6f);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            SnomanJump();
        }
    }

    public void SnomanJump()
    {
        if (ball != null)
        {
            if (isJumping == false)
            {
                StartCoroutine(SnomanJumpCoroutine());

            }
        }
        
    }

    IEnumerator SnomanJumpCoroutine()
    {
        isJumping = true;
        
        // ANIMATE BALL
        LeanTween.moveLocalY(ball, jumpHeight, snomanJumpTime).setEase(riseCurve).setLoopPingPong(1);

        // ANIMATE BALL SHADOW
        //LeanTween.moveLocalX(ballShadowMesh, 1.1f, snomanJumpTime).setEase(riseCurve).setLoopPingPong(1);
        LeanTween.scale(ballShadowMesh, smallShadowVector, snomanJumpTime).setEase(riseCurve).setLoopPingPong(1);


        yield return new WaitForSeconds(snomanJumpTime * 2);

        isJumping = false;

    }
}
