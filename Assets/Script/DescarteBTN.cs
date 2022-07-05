using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescarteBTN : MonoBehaviour
{
    public bool descarte = false;
    public bool hasTime=true;
    public GameManager gameManager;
    public GlassPrueba glass;
    // Update is called once per frame
    void Update()
    {
        /*
        if (glass.gameTime <= 0)
        {
            hasTime = false;
        }
        */

        if (descarte == false)
            return;
        
        if (hasTime == true) // Todavia tiene tiempo
        {
            glass.ResetGlassValuesDescarte();
            descarte = false;
        }
        else if (descarte == true && hasTime == false) //No tiene tiempo y apreta para descartar
        {
            //gameManager.Prueba();
            Debug.Log("Entre");
            gameManager.score -= 10;
            gameManager.TesteoVaso();
            //glass.stopTimer = false;
            descarte = false;
        }
        
    }

    private void OnMouseDown()
    {
        descarte = true;
        gameManager.glass = glass.GetComponent<GlassPrueba>();
        glass.descarteAnimation();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            descarte = true;
            gameManager.glass = glass.GetComponent<GlassPrueba>();
            glass.descarteAnimation();
        }
    }
}
