using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntregaBTN : MonoBehaviour
{
    bool entrega = false;
    public GameManager gameManager;
    public GlassPrueba glass;
    // Update is called once per frame
    void Update()
    {
        /*
        if (entrega == true && glass.canDeliver == true)
        {
            gameManager.Prueba();
            entrega = false;
            glass.entregaAnimation();
            //glass.glassAnimator.SetBool("entregaBool", false);
        }*/
        if (entrega == true )
        {
            gameManager.TesteoVaso();
            entrega = false;
            //glass.stopTimer = false;
            //glass.StopTimer();
            //glass.StartTimer();
            glass.entregaAnimation();
            //glass.glassAnimator.SetBool("entregaBool", false);
        }
    }

    private void OnMouseDown() 
    {
        entrega = true;
        gameManager.glass = glass.GetComponent<GlassPrueba>();
        Debug.Log(gameManager.glass);
        //glass.glassAnimator.SetBool("entregaBool", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            entrega = true;
            gameManager.glass = glass.GetComponent<GlassPrueba>();
            Debug.Log(gameManager.glass);
        }
    }
}
