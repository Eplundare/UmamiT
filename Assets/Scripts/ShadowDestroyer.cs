using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowDestroyer : MonoBehaviour
{
    public Vector3 scaleZero;
    public float time;
    public AnimationCurve curve;

    public void Start()
    {
        scaleZero = new Vector3(0f, 0f, 0f);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Bridge")
        {
            LeanTween.scale(gameObject, scaleZero, time).setEase(curve);
        }
    }
}
