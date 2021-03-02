using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSpeeder : MonoBehaviour
{
    public static float globalSpeed;
    public float whatSpeed;

    public void Update()
    {
        globalSpeed = whatSpeed;
    }
}
