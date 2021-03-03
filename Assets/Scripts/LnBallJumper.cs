using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LnBallJumper : MonoBehaviour
{
    public bool isJumping;
    public GameObject ball;
    public Transform snomanJumpPos;
    public Transform berryHiJumpPos;
    public Transform berryLoJumpPos;
    public float snomanJumpTime;
    public float berryJumpTime;
    public AnimationCurve riseCurve;
    public AnimationCurve fallCurve;

    public void Start()
    {
        //if (Input.GetButtonDown("j"))
        //{
        //    SnomanJump();
        //}
    }

    public void SnomanJump()
    {
        if (isJumping == false)
        {
            StartCoroutine(SnomanJumpCoroutine());

        }
    }

    IEnumerator SnomanJumpCoroutine()
    {
        isJumping = true;
        LeanTween.moveLocalY(ball, 1.2f, snomanJumpTime).setEase(riseCurve).setLoopPingPong(1);
        yield return new WaitForSeconds(snomanJumpTime * 2);

        isJumping = false;

    }
}
