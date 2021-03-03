using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallSideController : MonoBehaviour/*, IPointerDownHandler*/
{
    public static bool playerIsInControl;

    public bool isUsingPc;

    public float lerper;

    public Transform ballPos;

    public Transform posA;
    public Transform posB;

    public Vector3 ballLimitA;
    public Vector3 ballLimitB;

    

    public void Start()
    {
        playerIsInControl = true;

        lerper = 0.5f;

        ballLimitA = new Vector3(posA.position.x, ballPos.position.y, ballPos.position.z);
        ballLimitB = new Vector3(posB.position.x, ballPos.position.y, ballPos.position.z);

    }

    public void Update()
    {
        AssignLerper();

        ballPos.transform.position = Vector3.Lerp(ballLimitA, ballLimitB, lerper);
        
    }

    //public void OnPointerDown(PointerEventData pointerEventData)
    //{
    //    playerIsInControl = true;
    //}

    public void AssignLerper()
    {
        // FOR TOUCH CONTROLS
        if (isUsingPc == false)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                lerper = (touch.position.x / Screen.width);

            }
        }
        
        else if (isUsingPc == true)
        {
            if (Input.GetMouseButton(0))
            {

                lerper = (Input.mousePosition.x / Screen.width);

                //Debug.Log("Click Position : " + Input.mousePosition);
            }
        }
       
    }

}
