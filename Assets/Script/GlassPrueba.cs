using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GlassPrueba : MonoBehaviour
{
    public PedidoSO orderType; 
    public GlassSO glassType; //Guarda el SO del vaso
    public List<string> thisGlass; // Lista de lo que contiene ese vaso
    public List<string> dif; //Lista que guarda las diferencias entre vasos
    public int ingredientesFaltantes;
    public GameManager gameManager;
    public DescarteBTN descarteBtn;
    public bool correctPreparation;

    public GameObject order;
    public Renderer orderRenderer;

    //Timer
    public float timeValue;
    bool timer;

    public bool canDeliver = true;
    // public SpawnBottleManager spawnBottleManager;

    [SerializeField]
    private GameObject glass; //Referencia al vaso en cuestion  
    private Renderer glassRenderer; //referencia al mesh render del vaso
    private Color newGlassColor; // referencia al color que ira tomando el vaso

    private void Awake()
    {
        glassType.drinkList.Clear(); //Limpiamos la lista para no generar problemas 
        ingredientesFaltantes= orderType.cantidadIngredientesOrden; // igualamos la cantidad de ingredientes que puede poseer con los que la orden nos indica 
    }

    private void Start()
    {
        glassType.drinkList.AddRange(orderType.orderList); //Sumamos las listas de la orden y del objeto vaso
        timeValue = orderType.orderTime; //Contador igualado al tiempo que debe tener la orden
        dif = glassType.drinkList.Except(thisGlass).ToList(); //Se registra lo que debe contener el vaso
        glassRenderer = glass.GetComponent<Renderer>();
        orderRenderer = order.GetComponent<Renderer>();
        orderRenderer.material = orderType.orderMat;
    }

    private void Update()
    {
        if(timeValue> 0 && timer==false)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            descarteBtn.hasTime = false;
            timer = true;
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        //string botleName = other.name;
        string bottleName = other.GetComponent<Bottle1>().bottleName;

        if (other.gameObject.CompareTag("Bottle1"))
        {
            Debug.Log("INGRESO");
            //glassType.glassList.Add(botleName);
            //thisGlass.Add(botleName); //Añade el nombre del vaso
            thisGlass.Add(bottleName);

            //dif =glassType.drinkList.Except(glassType.glassList).ToList();
            dif = glassType.drinkList.Except(thisGlass).ToList(); //corrobora las diferencias que existen ahora entre lo que deberia tener y lo que tiene
            foreach (var item in dif)
            {
                Debug.Log(item);
            }

            //ingredientesFaltantes -= 1;
            gameManager.RestarIngrediente();
            
            Destroy(other.gameObject); //Destruye el vaso
            gameManager.blue = true;
            gameManager.RespawnBottle();
            
            newGlassColor = new Color(0, 0, 1, 1);
            glassRenderer.material.SetColor("_Color", newGlassColor);
            //gameManager.Prueba();

            //Compare(); //Corrobora si terminamos el pedido
            //spawnBottleManager.Respawn();
        }
        if (other.gameObject.CompareTag("Bottle2"))
        {
            //glassType.glassList.Add(botleName);
            //dif = glassType.drinkList.Except(glassType.glassList).ToList();
            //thisGlass.Add(botleName); //Añade el nombre del vaso
            thisGlass.Add(bottleName);

            dif = glassType.drinkList.Except(thisGlass).ToList(); //corrobora las diferencias que existen ahora entre lo que deberia tener y lo que tiene
            foreach (var item in dif)
            {
                Debug.Log(item);
            }
            //Destroy(other.gameObject);

            gameManager.RestarIngrediente();
            Destroy(other.gameObject); //Destruye el vaso
            gameManager.red = true;
            gameManager.RespawnBottle();

            
            newGlassColor = new Color(1, 0, 0, 1);
            glassRenderer.material.SetColor("_Color", newGlassColor);
            //gameManager.Prueba();
            //Compare(); //Corrobora si terminamos el pedido
        }
        if (other.gameObject.CompareTag("Bottle3")) 
        {
            //thisGlass.Add(botleName);
            thisGlass.Add(bottleName);
            dif = glassType.drinkList.Except(thisGlass).ToList();
            foreach (var item in dif)
            {
                Debug.Log(item);
            }

            gameManager.RestarIngrediente();
            Destroy(other.gameObject); //Destruye el vaso
            gameManager.green = true;
            gameManager.RespawnBottle();

            newGlassColor = new Color(120, 171, 57, 1);
            glassRenderer.material.SetColor("_Color", newGlassColor);
            //gameManager.Prueba();
            //Compare();
        }
    }


    public void ResetGlass()
    {
        if (timer == true) //Se quedo sin tiempo
        {
            /*
            thisGlass.Clear();
            glassType.drinkList.Clear();
            */
            ChangeGlassValues();
            timeValue = orderType.orderTime; //Contador igualado al tiempo que debe tener la orden
            gameManager.score -= 10;
            timer = false;
            /*
            timeValue = orderType.orderTime; //Contador igualado al tiempo que debe tener la orden
            glassType.drinkList.AddRange(orderType.orderList); //Sumamos las listas de la orden y del objeto vaso
            dif = glassType.drinkList.Except(thisGlass).ToList(); //Se registra lo que debe contener el vaso
            ingredientesFaltantes = orderType.cantidadIngredientesOrden; // igualamos la cantidad de ingredientes que puede poseer con los que la orden nos indica 
             */
        }
        else if (correctPreparation==true)
        {
            ChangeGlassValues();
            timeValue = orderType.orderTime; //Contador igualado al tiempo que debe tener la orden
        }   
    }

    void ChangeGlassValues()
    {
        thisGlass.Clear();
        glassType.drinkList.Clear();
        orderRenderer.material = orderType.orderMat;
        correctPreparation = false;
        //timeValue = orderType.orderTime; //Contador igualado al tiempo que debe tener la orden
        glassType.drinkList.AddRange(orderType.orderList); //Sumamos las listas de la orden y del objeto vaso
        dif = glassType.drinkList.Except(thisGlass).ToList(); //Se registra lo que debe contener el vaso
        ingredientesFaltantes = orderType.cantidadIngredientesOrden; // igualamos la cantidad de ingredientes que puede poseer con los que la orden nos indica 
    }

}
