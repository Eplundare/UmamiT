using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRockBumper : MonoBehaviour
{
    public float currentLerpTime;
    public float lerpTime = 1f;

    public GlobalValues gValues;
    public float backSpeed;
    public float stillSpeed;
    public float normalSpeed;

    public void Start()
    {
        normalSpeed = gValues.whatSpeed;
    }

    //public void Update()
    //{
    //    if (Input.GetKeyUp(KeyCode.B))
    //    {
    //        Bumper();
    //    }
    //}

    //public void Bumper()
    //{
    //    StartCoroutine(BumperCoroutine());
    //}

    //IEnumerator BumperCoroutine()
    //{
    //    currentLerpTime = 0f;

    //    //increment timer once per frame
    //    currentLerpTime += Time.deltaTime;
    //    if (currentLerpTime > lerpTime)
    //    {
    //        currentLerpTime = lerpTime;
    //    }

    //    ////lerp!
    //    //float perc = currentLerpTime / lerpTime;
    //    //perc = Mathf.Sin(perc * Mathf.PI * 0.5f);
    //    //gValues.whatSpeed = Mathf.Lerp(backSpeed, stillSpeed, perc);
    //    ////gValues.whatSpeed = Mathf.Sin(perc * Mathf.PI * 0.5f);

    //    yield return new WaitForSeconds(lerpTime);

    //    //currentLerpTime = 0f;

    //    ////increment timer once per frame
    //    //currentLerpTime += Time.deltaTime;
    //    //if (currentLerpTime > lerpTime)
    //    //{
    //    //    currentLerpTime = lerpTime;
    //    //}

    //    ////lerp!
    //    ////float perc = currentLerpTime / lerpTime;
    //    //perc = Mathf.Sin(perc * Mathf.PI * 0.5f);
    //    //gValues.whatSpeed = Mathf.Lerp(stillSpeed, normalSpeed, perc);
    //}
}
