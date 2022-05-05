using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntregaBTN : MonoBehaviour
{
    bool entrega = false;
    public GameManager gameManager;
    // Update is called once per frame
    void Update()
    {
        if (entrega == true)
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
