using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ManagerUi : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isStartButt;
    public bool isLevelButt;

    public Image startNormalSquare;
    public TextMeshProUGUI startNormalTxt;
    public Image startPressedSquare;
    public TextMeshProUGUI startPressedTxt;

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        if (isStartButt)
        {
            startNormalSquare.enabled = false;
            startNormalTxt.enabled = false;
        }
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        if (isStartButt)
        {
            startNormalSquare.enabled = true;
            startNormalTxt.enabled = true;
        }
    }
}
