using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiStartSwiper : MonoBehaviour
{
    public Canvas startCanvas;
    public string firstLvlName;

    public float screenOutY;
    public GameObject startParent;
    public GameObject logo;
    public GameObject startButton;
    public float swipeTime;
    public float logoDripTime;
    public AnimationCurve curve;

    public void Start()
    {
        LeanTween.moveLocalY(startParent, screenOutY, 0f);
        LeanTween.moveLocalY(startParent, 0f, swipeTime).setEase(curve);

        LeanTween.moveLocalY(logo, 460f, 0f);
        LeanTween.moveLocalY(logo, 97f, logoDripTime).setEase(curve);

        //LeanTween.moveLocalY(startButton, -310f, 0f);
        //LeanTween.moveLocalY(startButton, -677f, logoDripTime).setEase(curve);

    }

    public void StartGame()
    {
        StartCoroutine(DisableStartScreenCoroutine());

    }

    IEnumerator DisableStartScreenCoroutine()
    {
        LeanTween.moveLocalY(startParent, -screenOutY, (swipeTime/1.5f)).setEase(curve);

        yield return new WaitForSeconds(swipeTime + 1f);
        startCanvas.enabled = false;
        SceneManager.LoadScene(firstLvlName);

    }
}
