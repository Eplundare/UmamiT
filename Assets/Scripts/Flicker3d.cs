using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flicker3d : MonoBehaviour
{
    public Renderer ren;
    public Material objMaterial;
    //public Material whiteMaterial;

    public bool isBall;
    public Image whiteBerryUi;

    public Color originalC;
    public Color whiteC;
    public Color hitC;

    //public int flickerLoops;

    public void Start()
    {
        ren = gameObject.GetComponent<Renderer>();
        objMaterial = ren.material;
        originalC = ren.material.color;
        whiteC = new Color32(255, 255, 215, 255);
        hitC = new Color32(63, 205, 112, 255);


    }

    public void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            Flicker();
        }
        if (Input.GetKeyDown("s"))
        {
            FlickerSad();
        }
    }

    public void Flicker()
    {
        StartCoroutine(FlickerCoroutine());
        
    }

    public void FlickerSad()
    {
        StartCoroutine(FlickerSadCoroutine());
    }

    IEnumerator FlickerCoroutine()
    {

        ren.material.SetColor("_Color", whiteC);
        if (isBall == true)
        {
            whiteBerryUi.enabled = true;
        }
        yield return new WaitForSeconds(0.1f);

        ren.material.SetColor("_Color", originalC);
        if (isBall == true)
        {
            whiteBerryUi.enabled = false;
        }
        yield return new WaitForSeconds(0.1f);

        ren.material.SetColor("_Color", whiteC);
        if (isBall == true)
        {
            whiteBerryUi.enabled = true;
        }
        yield return new WaitForSeconds(0.1f);

        ren.material.SetColor("_Color", originalC);
        if (isBall == true)
        {
            whiteBerryUi.enabled = false;
        }
        yield return new WaitForSeconds(0.1f);

    }

    IEnumerator FlickerSadCoroutine()
    {

        ren.material.SetColor("_Color", hitC);
        yield return new WaitForSeconds(0.4f);

        ren.material.SetColor("_Color", originalC);
        

    }
}
