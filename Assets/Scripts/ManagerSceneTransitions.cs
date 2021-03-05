using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerSceneTransitions : MonoBehaviour
{
    public UiStartSwiper startScreenManager;

    public float screenOutUpY;
    public float screenOutDownY;
    public GameObject currentLvl;
    public string currentLvlName;
    public GameObject nextLvl;
    public string nextLvlName;
   
    public float swipeTime;
    public float timeBeforeNextScene = 0.5f;
    public AnimationCurve curve;

    public void Start()
    {
        LeanTween.moveLocalY(currentLvl, 0f, 0f);
        LeanTween.moveLocalY(nextLvl, screenOutUpY, 0f);


        StartCoroutine(SwipeCurrentLvlScreenCoroutine());

    }

    IEnumerator SwipeCurrentLvlScreenCoroutine()
    {
        yield return new WaitForSeconds(2.5f);
        LeanTween.moveLocalY(currentLvl, screenOutDownY, swipeTime).setEase(curve);

    }

    public void RestartLvl()
    {
        StartCoroutine(RestartLvlTransitionCoroutine());

    }

    IEnumerator RestartLvlTransitionCoroutine()
    {
        LeanTween.moveLocalY(currentLvl, screenOutUpY, 0f);
        LeanTween.moveLocalY(currentLvl, 0f, swipeTime).setEase(curve);

        yield return new WaitForSeconds(swipeTime + 0.5f);

        SceneManager.LoadScene(currentLvlName, LoadSceneMode.Single);
    }

    public void NextLvl()
    {
        StartCoroutine(NextLvlTransitionCoroutine());

    }

    IEnumerator NextLvlTransitionCoroutine()
    {
        LeanTween.moveLocalY(nextLvl, 0f, swipeTime).setEase(curve);

        yield return new WaitForSeconds(swipeTime + (timeBeforeNextScene));

        SceneManager.LoadScene(nextLvlName, LoadSceneMode.Single);

    }
}
