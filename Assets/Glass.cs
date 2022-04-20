using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{
    [SerializeField]
    private GameObject glass; //Referencia al vaso en cuestion  
    private Renderer glassRenderer; //referencia al mesh render del vaso
    private Color newGlassColor; // referencia al color que ira tomando el vaso
    public GlassSO glassType; //Referencia al scriptable object 
    public int glassValue; // Valor del vaso actualmente

    void Start()
    {
        glassRenderer = glass.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * Codigo que funciona de forma correcta, pero me genera dudas a la hora de como lo vamos a llevar a cabo
         * cuando hay mas de una orden al mismo tiempo. No utiliza ScriptableObjects
        if (GameFlow.plateValue == 100)
        {
            Debug.Log("entro100");
            newGlassColor = new Color(0, 0, 1, 1);
            glassRenderer.material.SetColor("_Color", newGlassColor);

            
        }else if (GameFlow.plateValue == 10)
        {
            Debug.Log("entro10");
            newGlassColor = new Color(255, 0, 255, 1);
            glassRenderer.material.SetColor("_Color", newGlassColor);
        }
        else if (GameFlow.plateValue == 110)
        {
            Debug.Log("entro110");
            newGlassColor = new Color(255, 0, 0, 1);
            glassRenderer.material.SetColor("_Color", newGlassColor);
        }
        */

        if (glassValue == 100)
        {
            Debug.Log("entro100");
            newGlassColor = new Color(0, 0, 1, 1);
            glassRenderer.material.SetColor("_Color", newGlassColor);


        }
        else if (glassValue == 10)
        {
            Debug.Log("entro10");
            newGlassColor = new Color(255, 0, 255, 1);
            glassRenderer.material.SetColor("_Color", newGlassColor);
        }
        else if (glassValue == 110)
        {
            Debug.Log("entro110");
            newGlassColor = new Color(255, 0, 0, 1);
            glassRenderer.material.SetColor("_Color", newGlassColor);
        }

        //Preguntar si la corroboracion esta bien especificada en esta parte
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (glassValue == glassType.drinkValue)
            {
                Debug.Log("Correcta");
            }
            else
            {
                Debug.Log("Incorrecta");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Bottle bottle = other.gameObject.GetComponent<Bottle>();


        /*
         * Codigo que funciona de forma correcta, pero me genera dudas a la hora de como lo vamos a llevar a cabo
         * cuando hay mas de una orden al mismo tiempo. No utiliza ScriptableObjects
         *
        if (other.gameObject.CompareTag("Bottle1"))
        {
            Debug.Log("Choco");
            GameFlow.plateValue += bottle.drinkValue;
            Debug.Log(GameFlow.plateValue + "" + GameFlow.orderValue);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Bottle2"))
        {
            GameFlow.plateValue += bottle.drinkValue;
            Debug.Log(GameFlow.plateValue + "" + GameFlow.orderValue);
            Destroy(other.gameObject);
        }
        */

        // Corroboracion que utiliza SO
        if (other.gameObject.CompareTag("Bottle1"))
        {
            Debug.Log("Choco");
            glassValue += bottle.drinkValue;
            Debug.Log(glassType.drinkValue + "" + glassType.drinkValue);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Bottle2"))
        {
            glassValue += bottle.drinkValue;
            Debug.Log(glassValue + "" + glassType.drinkValue);
            Destroy(other.gameObject);
        }

    }

    
}
