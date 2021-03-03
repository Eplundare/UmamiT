using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSilentCopier : MonoBehaviour
{
    public Transform visibleBall;
    public Transform invisibleBall;

    public bool ballHasLost;
    public void Update()
    {
        if (ballHasLost == false)
        {
            invisibleBall.transform.position = visibleBall.position;

        }
    }
}
