using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translator : MonoBehaviour
{
    //public float forwardSpeed;
    public Vector3 forwardVector;

    public void Start()
    {
        //forwardSpeed = -2f;
        //forwardVector = new Vector3(0f, 0f, forwardSpeed);

    }

    public void Update()
    {
        forwardVector = new Vector3(0f, 0f, GlobalValues.globalSpeed);

        transform.Translate(forwardVector * Time.deltaTime, Space.Self);
    }
}
