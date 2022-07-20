using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescarteBTN : MonoBehaviour
{
    public bool descarte = false;
    public bool hasTime=true;
    public GameManager gameManager;
    public GlassPrueba glass;
    void Update()
    {
        if (descarte == false)
            return;
        
        if (hasTime == true)
        {
            glass.ResetGlassValuesDescarte();
            descarte = false;
        }
        else if (descarte == true && hasTime == false) 
        {
            Debug.Log("Entre");
            gameManager.TesteoVaso();
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
            Debug.Log("DescarteAnim");
            descarte = true;
            gameManager.glass = glass.GetComponent<GlassPrueba>();
            glass.descarteAnimation();
        }
    }
}
