using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseRemover : MonoBehaviour
{
    public Button pauseButton;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PauseRemover")
        {
            pauseButton.interactable = false;
        }
    }
}
