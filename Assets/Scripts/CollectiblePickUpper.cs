using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblePickUpper : MonoBehaviour
{
    public Flicker3d flickerObj1;
    public Flicker3d flickerObj2;
    public GameObject collectibleParent;
    //public float shrinkTime;
    public AnimationCurve animCurve;

    private Vector3 vectorZero;

    public void Start()
    {
        vectorZero = new Vector3(0f, 0f, 0f);
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            if (flickerObj2 != null)
            {
                flickerObj1.FlickerCollectible();
                flickerObj2.FlickerCollectible();

            }
            else if (flickerObj2 == null)
            {
                flickerObj1.FlickerCollectible();
            }
        }

        LeanTween.scale(collectibleParent, vectorZero, 0.3f).setEase(animCurve);
    }

}
