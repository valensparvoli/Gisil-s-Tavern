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
        if (entrega == true && glass.canDeliver == true)
        {
            gameManager.Prueba();
            entrega = false;
        }
    }

    private void OnMouseDown() 
    {
        entrega = true;
    }
}
