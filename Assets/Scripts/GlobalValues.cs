using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalValues : MonoBehaviour
{
    public static float globalSpeed;
    public float whatSpeed;

    public static int globalFlickerLoops;
    public int whatFlickerLoops;

    //public static float sizerUnit;
    //public float whatSize;

    public void Update()
    {
        globalSpeed = whatSpeed;
        //sizerUnit = whatSize;
    }
}
