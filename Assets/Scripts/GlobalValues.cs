using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalValues : MonoBehaviour
{
    // whatSpeed WILL BE -5.
    public static float globalSpeed;
    public float whatSpeed;

    public static int globalFlickerLoops;
    public int whatFlickerLoops;

    public void Start()
    {
        whatSpeed = -5f;
        whatSpeed = 0f;
    }

    public void Update()
    {
        globalSpeed = whatSpeed;
        //sizerUnit = whatSize;
    }
}
