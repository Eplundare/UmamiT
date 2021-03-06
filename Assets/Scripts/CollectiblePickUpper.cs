using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblePickUpper : MonoBehaviour
{
    public bool invinciGranter;
    public bool isBridge;
    public Flicker3d flickerObj1;
    public Flicker3d flickerObj2;
    public Flicker3d flickerObj3;
    public GameObject collectibleParent;
    //public float shrinkTime;
    public AnimationCurve animCurve;

    public Invinsibiliter invincibiliter;

    private Vector3 vectorZero;

    public void Start()
    {
        vectorZero = new Vector3(0f, 0f, 0f);
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            if (flickerObj2 != null && flickerObj3 == null)
            {
                flickerObj1.FlickerCollectible();
                flickerObj2.FlickerCollectible();
                if (invinciGranter == true)
                {
                    invincibiliter.GrantInvin();

                }

            }
            else if (flickerObj3 != null)
            {
                flickerObj1.FlickerCollectible();
                flickerObj2.FlickerCollectible();
                flickerObj3.FlickerCollectible();

                if (invinciGranter == true)
                {
                    invincibiliter.GrantInvin();

                }

            }
            else if (flickerObj2 == null && flickerObj3 == null)
            {
                flickerObj1.FlickerCollectible();
                if (invinciGranter == true)
                {
                    invincibiliter.GrantInvin();

                }

            }
        }

        if (isBridge == false)
        {
            LeanTween.scale(collectibleParent, vectorZero, 0.3f).setEase(animCurve);

        }
    }

}
