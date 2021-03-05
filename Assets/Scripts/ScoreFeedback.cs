using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreFeedback : MonoBehaviour
{
    public TextMeshProUGUI topScore;
    public TextMeshProUGUI windowScore;

    public void Update()
    {
        windowScore.text = topScore.text;
    }

}
