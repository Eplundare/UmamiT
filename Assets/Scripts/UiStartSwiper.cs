using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiStartSwiper : MonoBehaviour
{
    public Canvas startCanvas;

    public float screenOutY;
    public GameObject startParent;
    public float swipeTime;
    public AnimationCurve curve;

    public void Start()
    {
        LeanTween.moveLocalY(startParent, screenOutY, 0f);
        LeanTween.moveLocalY(startParent, 0f, swipeTime).setEase(curve);

    }

    public void StartGame()
    {
        StartCoroutine(DisableStartScreenCoroutine());

    }

    IEnumerator DisableStartScreenCoroutine()
    {
        LeanTween.moveLocalY(startParent, -screenOutY, swipeTime).setEase(curve);

        yield return new WaitForSeconds(swipeTime + 1f);
        startCanvas.enabled = false;

    }
}
