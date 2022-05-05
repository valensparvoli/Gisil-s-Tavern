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
        if (descarte == true)
        {
            if (hasTime == true) // Todavia tiene tiempo
            {
                gameManager.glass1.ResetGlass();
                descarte = false;
            }
            else if(descarte==true && hasTime ==false) //No tiene tiempo y apreta para descartar
            {
                gameManager.DescartarYNuevaOrden();
                descarte = false;

            }            
        }
    }

    private void OnMouseDown()
    {
        descarte = true;
    }
}
