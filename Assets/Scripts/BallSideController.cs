using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallSideController : MonoBehaviour/*, IPointerDownHandler*/
{
    public static bool playerIsInControl;
    public bool playerisincontrolCopy;

    public bool isUsingPc;

    public float lerper;

    public Transform ballPos;

    public Transform posA;
    public Transform posB;
    public Transform posCcandy;
    public Transform posDcandy;

    public Vector3 ballLimitA;
    public Vector3 ballLimitB;

    public bool isInNormalPath;
    public bool isInCandyPath;
    

    public void Start()
    {
        //playerIsInControl = true;
        isInNormalPath = true;
        isInCandyPath = false;

        lerper = 0.5f;

        ballLimitA = new Vector3(posA.position.x, ballPos.position.y, ballPos.position.z);
        ballLimitB = new Vector3(posB.position.x, ballPos.position.y, ballPos.position.z);

    }

    public void Update()
    {
        //TEST
        playerisincontrolCopy = playerIsInControl;

        if (isInNormalPath == true)
        {
            ballLimitA = new Vector3(posA.position.x, ballPos.position.y, ballPos.position.z);
            ballLimitB = new Vector3(posB.position.x, ballPos.position.y, ballPos.position.z);
        }

        else if (isInCandyPath == true)
        {
            ballLimitA = new Vector3(posCcandy.position.x, ballPos.position.y, ballPos.position.z);
            ballLimitB = new Vector3(posDcandy.position.x, ballPos.position.y, ballPos.position.z);
        }
        AssignLerper();

        if (playerIsInControl == true)
        {
            ballPos.transform.position = Vector3.Lerp(ballLimitA, ballLimitB, lerper);

        }


    }

    public void CandyLimiter()
    {
        lerper = 0.5f;

        isInNormalPath = false;
        isInCandyPath = true;

        //ballLimitA = new Vector3(posCcandy.position.x, ballPos.position.y, ballPos.position.z);
        //ballLimitB = new Vector3(posDcandy.position.x, ballPos.position.y, ballPos.position.z);

        playerIsInControl = true;

    }

    public void ResetLimiter()
    {
        ballLimitA = new Vector3(posA.position.x, ballPos.position.y, ballPos.position.z);
        ballLimitB = new Vector3(posB.position.x, ballPos.position.y, ballPos.position.z);

        lerper = 0.5f;

        playerIsInControl = true;


    }

    //public void OnPointerDown(PointerEventData pointerEventData)
    //{
    //    playerIsInControl = true;
    //}

    public void AssignLerper()
    {
        if (playerIsInControl == true)
        {
            // FOR TOUCH CONTROLS
            if (isUsingPc == false)
            {
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);

                    if (touch.position.y < 1850)
                    {
                        lerper = (touch.position.x / Screen.width);
                    }
                }
            }

            else if (isUsingPc == true)
            {
                if (Input.GetMouseButton(0))
                {
                    if (Input.mousePosition.y < 1850)
                    {
                        lerper = (Input.mousePosition.x / Screen.width);
                    }

                    //Debug.Log("Click Position : " + Input.mousePosition);
                }
            }
        }
       
       
    }

}
