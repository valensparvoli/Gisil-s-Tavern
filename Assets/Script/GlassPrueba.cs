using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GlassPrueba : MonoBehaviour
{
    public GlassSO glassType; //Guarda el SO del vaso
    public List<string> thisGlass; // Lista de lo que contiene ese vaso
    public List<string> dif; //Lista que guarda las diferencias entre vasos
    public int cantidadIngredientes;

    // public SpawnBottleManager spawnBottleManager;

    [SerializeField]
    private GameObject glass; //Referencia al vaso en cuestion  
    private Renderer glassRenderer; //referencia al mesh render del vaso
    private Color newGlassColor; // referencia al color que ira tomando el vaso

    private void Start()
    {
        dif = glassType.drinkList.Except(thisGlass).ToList(); //Se registra lo que debe contener el vaso
        cantidadIngredientes = glassType.cantidadIngredientesSO;
        glassRenderer = glass.GetComponent<Renderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        string botleName = other.name;

        if (other.gameObject.CompareTag("Bottle1"))
        {
            Debug.Log("INGRESO");
            //glassType.glassList.Add(botleName);
            thisGlass.Add(botleName); //Añade el nombre del vaso
            //dif =glassType.drinkList.Except(glassType.glassList).ToList();
            dif = glassType.drinkList.Except(thisGlass).ToList(); //corrobora las diferencias que existen ahora entre lo que deberia tener y lo que tiene
            foreach (var item in dif)
            {
                Debug.Log(item);
            }
            cantidadIngredientes -= 1;
            Destroy(other.gameObject); //Destruye el vaso
            //spawnBottleManager.bluePlace = false;
            newGlassColor = new Color(0, 0, 1, 1);
            glassRenderer.material.SetColor("_Color", newGlassColor);
            Compare(); //Corrobora si terminamos el pedido
            //spawnBottleManager.Respawn();
        }
        if (other.gameObject.CompareTag("Bottle2"))
        {
            //glassType.glassList.Add(botleName);
            //dif = glassType.drinkList.Except(glassType.glassList).ToList();
            thisGlass.Add(botleName); //Añade el nombre del vaso
            dif = glassType.drinkList.Except(thisGlass).ToList(); //corrobora las diferencias que existen ahora entre lo que deberia tener y lo que tiene
            foreach (var item in dif)
            {
                Debug.Log(item);
            }
            Destroy(other.gameObject);
            cantidadIngredientes -= 1;
            newGlassColor = new Color(1, 0, 0, 1);
            glassRenderer.material.SetColor("_Color", newGlassColor);
            Compare(); //Corrobora si terminamos el pedido
        }
        if (other.gameObject.CompareTag("Bottle3"))
        {
            thisGlass.Add(botleName);
            dif = glassType.drinkList.Except(thisGlass).ToList();
            foreach (var item in dif)
            {
                Debug.Log(item);
            }
            Destroy(other.gameObject);
            cantidadIngredientes -= 1;
            newGlassColor = new Color(120, 171, 57, 1);
            glassRenderer.material.SetColor("_Color", newGlassColor);
            Compare();
        }
    }

    private void Compare()
    {
        if (cantidadIngredientes == 0)
        {
            if (dif.Count == 0)
            {
                Debug.Log("Terminado");

            }
            else if (dif.Count == 1)
            {
                Debug.Log("Casi bien");
            }
            else
            {
                Debug.Log("Horrible");
            }
        }


    }

}
