using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;


public class GlassPrueba : MonoBehaviour
{
    [SerializeField] public PedidoSO orderType; //No se si al suabas en otr script
    public GlassSO glassType; //Guarda el SO del vaso
    public List<string> thisGlass; // Lista de lo que contiene ese vaso
    public List<string> dif; //Lista que guarda las diferencias entre vasos
    public int ingredientesFaltantes;
    public GameManager gameManager;
    public DescarteBTN descarteBtn;
    [HideInInspector] public bool correctPreparation;

    public GameObject order;
    public Renderer orderRenderer;
    [SerializeField] GameObject liquidObj;
    [SerializeField] Renderer liquidRenderer;
    public Material blue;
    public Material red;
    public Material yellow;
    public Material black;
    public Material green;

    //Timer
    public float timeValue;
    public bool timer;

    public bool canDeliver = true;
    // public SpawnBottleManager spawnBottleManager;

    [SerializeField]
    private GameObject glass; //Referencia al vaso en cuestion  
    private Renderer glassRenderer; //referencia al mesh render del vaso
    private Color newGlassColor; // referencia al color que ira tomando el vaso


    //Animaciones
    public Animator glassAnimator;
    public Animation descarteAnim;

    //public Image sliderBar;
    /* --------------------------------------Timer
    public Slider sliderBarTime;
    public float gameTime;
    [SerializeField] float time;
    public bool stopTimer;

    public Canvas UITimerCanvas;
    ----------------------------------------------------
    */

    //Sound
    public AudioSource source;
    public AudioClip vasoDeslizando;
    public AudioClip satisfaccion;


    //Variable encargada de la calidad de la orden
    public int calidadOrden = 0;

    // public Coroutine _timer;

    public ITimer iTimer;




    public void descarteAnimation()
    {
        glassAnimator.Play("descarteAnim");
    }

    public void entregaAnimation()
    {
        glassAnimator.Play("entregarAnim");
        source.clip = vasoDeslizando;
        source.Play();
    }

    private void Awake()
    {
        /*
        glassType.drinkList.Clear(); //Limpiamos la lista para no generar problemas 
        ingredientesFaltantes= orderType.cantidadIngredientesOrden; // igualamos la cantidad de ingredientes que puede poseer con los que la orden nos indica 
        */
        AssignValues();
    }


    private void Start()
    {
        /*
        glassType.drinkList.AddRange(orderType.orderList); //Sumamos las listas de la orden y del objeto vaso
        gameTime = orderType.orderTime; //Contador igualado al tiempo que debe tener la orden
        dif = glassType.drinkList.Except(thisGlass).ToList(); //Se registra lo que debe contener el vaso
        glassRenderer = glass.GetComponent<Renderer>();
        orderRenderer = order.GetComponent<Renderer>();
        orderRenderer.material = orderType.orderMat;
        */
        /*
        stopTimer = false;

        sliderBarTime.maxValue = gameTime;
        sliderBarTime.value = gameTime;
        */

        //AssignValues();


        //_timer = StartCoroutine(Timer()); ---------------Corrutina
        //StartCoroutine("Timer"); ---------------Corrutina
        glassRenderer = glass.GetComponent<Renderer>();
        orderRenderer = order.GetComponent<Renderer>();
        liquidRenderer = liquidObj.GetComponent<Renderer>();

    }

    public void AssignValues()
    {
        thisGlass.Clear();
        glassType.drinkList.Clear(); //Limpiamos la lista para no generar problemas 
        ingredientesFaltantes = orderType.cantidadIngredientesOrden; // igualamos la cantidad de ingredientes que puede poseer con los que la orden nos indica 
        glassType.drinkList.AddRange(orderType.orderList); //Sumamos las listas de la orden y del objeto vaso
        //gameTime = orderType.orderTime; //Contador igualado al tiempo que debe tener la orden
        iTimer.initialTimer = orderType.orderTime;
        iTimer.ResetTimer();
        iTimer.StartTimer();
        //time = orderType.orderTime;
        dif = glassType.drinkList.Except(thisGlass).ToList(); //Se registra lo que debe contener el vaso
        orderRenderer.material = orderType.orderMat;
        /*
        stopTimer = false;
        sliderBarTime.maxValue = gameTime;
        sliderBarTime.value = gameTime;
        */
        calidadOrden = 0;
    }


    private void Update()
    {
        if (dif.Count == 0)
        {
            liquidObj.GetComponent<MeshRenderer>().material = orderType.liquidMat;
        }
        /*
        if(timeValue> 0 && !timer)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            descarteBtn.hasTime = false;
            timer = true;
        }
        */
        /*
        time = gameTime - Time.deltaTime * 100;
        
        if (time <= 0) 
        {
            stopTimer = true;
        }

        if(stopTimer== false)
        {
            sliderBarTime.value = time;
        }
        */
        /*
        if (gameTime <= 0)
        {
            stopTimer = true;
        }
        if (stopTimer == false)
        {
            sliderBarTime.value = gameTime;
            //StopCoroutine(_timer);
            StopCoroutine("Timer");
        }
        */
    }

    /* -------------------------Corrutinas
    public void StartTimer()
    {
        _timer = StartCoroutine(Timer());
        StartCoroutine("Timer");
    }

    public void StopTimer()
    {
        StopCoroutine("Timer");
        //StopCoroutine(_timer);
    }

    IEnumerator Timer()
    {
        while (gameTime >= 0)
        {
            yield return new WaitForSeconds(1);
            gameTime -= 1f;
        }
    }
    ------------------------------------------------------------------
    */
    /*
    private void OnTriggerEnter(Collider other)
    {
        //string botleName = other.name;
        string bottleName = other.GetComponent<Bottle1>().bottleName;

        //if (other.gameObject.CompareTag("Bottle1"))
        if (other.gameObject.CompareTag("Interact"))
        {
            if (bottleName == "Blue")
            {
            Debug.Log("INGRESO");
            //glassType.glassList.Add(botleName);
            //thisGlass.Add(botleName); //Añade el nombre del vaso
            thisGlass.Add(bottleName);
            other.GetComponent<Bottle1>().PlayBottleSound();
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
            if (bottleName=="Red")
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
            if (bottleName == "Green") 
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
        
    }
    */
    private void OnCollisionEnter(Collision collision)
    {
        //string botleName = other.name;
        string bottleName = collision.gameObject.GetComponent<Bottle1>().bottleName;

        //if (other.gameObject.CompareTag("Bottle1"))
        if (collision.gameObject.CompareTag("Interact"))
        {
            collision.gameObject.GetComponent<Bottle1>().PlayBottleSound();
            if (bottleName == "Blue")
            {
                Debug.Log("INGRESO");
                //glassType.glassList.Add(botleName);
                //thisGlass.Add(botleName); //Añade el nombre del vaso
                thisGlass.Add(bottleName);
                collision.gameObject.GetComponent<Bottle1>().PlayBottleSound();
                //dif =glassType.drinkList.Except(glassType.glassList).ToList();
                dif = glassType.drinkList.Except(thisGlass).ToList(); //corrobora las diferencias que existen ahora entre lo que deberia tener y lo que tiene
                foreach (var item in dif)
                {
                    Debug.Log(item);
                }

                //ingredientesFaltantes -= 1;
                gameManager.RestarIngrediente();


                Destroy(collision.gameObject); //Destruye el vaso
                gameManager.blue = true;
                gameManager.RespawnBottle();

                //newGlassColor = new Color(0, 0, 1, 1);
                //newLiquidColor = blue;
                //liquidObj.GetComponent<MeshRenderer>().material = blue;
                liquidObj.GetComponent<MeshRenderer>().material = collision.gameObject.GetComponent<Bottle1>().bottleMat;
                //gameManager.Prueba();

                //Compare(); //Corrobora si terminamos el pedido
                //spawnBottleManager.Respawn();
            }
            if (bottleName == "Red")
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
                Destroy(collision.gameObject); //Destruye el vaso
                gameManager.red = true;
                gameManager.RespawnBottle();
                liquidObj.GetComponent<MeshRenderer>().material = collision.gameObject.GetComponent<Bottle1>().bottleMat;

            }
            if (bottleName == "Green")
            {
                //thisGlass.Add(botleName);
                thisGlass.Add(bottleName);
                dif = glassType.drinkList.Except(thisGlass).ToList();
                foreach (var item in dif)
                {
                    Debug.Log(item);
                }

                gameManager.RestarIngrediente();
                Destroy(collision.gameObject); //Destruye el vaso
                gameManager.green = true;
                gameManager.RespawnBottle();
            }
            if (bottleName == "Yellow")
            {
                //thisGlass.Add(botleName);
                thisGlass.Add(bottleName);
                dif = glassType.drinkList.Except(thisGlass).ToList();
                foreach (var item in dif)
                {
                    Debug.Log(item);
                }

                gameManager.RestarIngrediente();
                Destroy(collision.gameObject); //Destruye el vaso
                gameManager.yellow = true;
                gameManager.RespawnBottle();
                liquidObj.GetComponent<MeshRenderer>().material = collision.gameObject.GetComponent<Bottle1>().bottleMat;
            }
            if (bottleName == "Black")
            {
                //thisGlass.Add(botleName);
                thisGlass.Add(bottleName);
                dif = glassType.drinkList.Except(thisGlass).ToList();
                foreach (var item in dif)
                {
                    Debug.Log(item);
                }

                gameManager.RestarIngrediente();
                Destroy(collision.gameObject); //Destruye el vaso
                gameManager.black = true;
                gameManager.RespawnBottle();
                liquidObj.GetComponent<MeshRenderer>().material = collision.gameObject.GetComponent<Bottle1>().bottleMat;
            }
        }

    }

    public void ResetGlass()
    {
        switch (calidadOrden)
        {
            case 1:
                Debug.Log("1");
                break;
            case 0:
                Debug.Log("0");
                break;
        }

    }

    public void ResetGlassValuesDescarte()
    {
        thisGlass.Clear();

    }

    void ChangeGlassValues()
    {
        thisGlass.Clear();
        glassType.drinkList.Clear();
        orderRenderer.material = orderType.orderMat;
        correctPreparation = false;


        glassType.drinkList.AddRange(orderType.orderList); //Sumamos las listas de la orden y del objeto vaso
        dif = glassType.drinkList.Except(thisGlass).ToList(); //Se registra lo que debe contener el vaso
        ingredientesFaltantes = orderType.cantidadIngredientesOrden; // igualamos la cantidad de ingredientes que puede poseer con los que la orden nos indica 

    }

}
