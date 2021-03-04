using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRangeLimiter : MonoBehaviour
{
    public BallSideController ballSideCtrl;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag=="CandyLimiter")
        {
            ballSideCtrl.CandyLimiter();
        }

        else if (other.tag == "NormalLimiter")
        {
            ballSideCtrl.ResetLimiter();
        }
    }
}
