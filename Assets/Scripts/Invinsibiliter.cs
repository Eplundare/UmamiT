using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invinsibiliter : MonoBehaviour
{
    public Collider ballCollider;
    public float invinsibilityTime;
    //public bool grants; // COLLECTIBLEPICKUPPER SCRIPT HANDLES THIS

    public void GrantInvin()
    {
        //if (grants == true)
        {
            StartCoroutine(InvincibilityCoroutine());

        }
    }

    IEnumerator InvincibilityCoroutine()
    {
        ballCollider.enabled = false;
        yield return new WaitForSeconds(invinsibilityTime);
        ballCollider.enabled = true;
    }
}
