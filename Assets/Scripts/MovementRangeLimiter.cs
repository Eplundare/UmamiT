using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRangeLimiter : MonoBehaviour
{
    public BallSideController ballSideCtrl;
    public BoxCollider camConfiner;
    //public Vector3 normalVectorSize;
    //public Vector3 normalVectorCenter;
    //public Vector3 candyVectorSize;
    public float normalConfinerXSize;
    //public float normalConfinerXCenter;
    public float candyConfinerXSize;
    //public float candyConfinerXCenter;

    //public void Start()
    //{
    //    normalVectorSize = camConfiner.size;
    //    //normalVectorCenter = camConfiner.center;

    //}

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag=="CandyLimiter")
        {
            ballSideCtrl.CandyLimiter();

            camConfiner.size = new Vector3 (candyConfinerXSize, camConfiner.size.y, camConfiner.size.z);
        }

        else if (other.tag == "NormalLimiter")
        {
            ballSideCtrl.ResetLimiter();

            camConfiner.size = new Vector3(normalConfinerXSize, camConfiner.size.y, camConfiner.size.z);

        }
    }
}
