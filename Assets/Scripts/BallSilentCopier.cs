using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSilentCopier : MonoBehaviour
{
    public Transform visibleBall;
    public Transform invisibleBall;
    public void Update()
    {
        invisibleBall.transform.position = visibleBall.position;
    }
}
