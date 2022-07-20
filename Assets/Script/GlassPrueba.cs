using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;


public class GlassPrueba : MonoBehaviour
{
    [SerializeField] public PedidoSO orderType; 
    public GlassSO glassType; 
    public List<string> thisGlass; 
    public List<string> dif; 
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

    [SerializeField]
    private GameObject glass; 
    private Renderer glassRenderer;
    private Color newGlassColor; 
    //Animaciones
    public Animator glassAnimator;
    public GlassAnimationMan animManager;
    //Sound
    public AudioSource source;
    public AudioClip vasoDeslizando;
    public AudioClip satisfaccion;
    //Variable encargada de la calidad de la orden
    public int calidadOrden = 0;
    // public Coroutine _timer;
    public ITimer iTimer;
    public bool hasTime=true;    
    private void Awake()
    {
        AssignValues();
    }
    public void descarteAnimation()
    {
        animManager.DesscarteAnimation();
    }

    public void entregaAnimation()
    {
        animManager.EntregaAnimation();
        source.clip = vasoDeslizando;
        source.Play();
    }
    private void Start()
    {
        glassRenderer = glass.GetComponent<Renderer>();
        orderRenderer = order.GetComponent<Renderer>();
        liquidRenderer = liquidObj.GetComponent<Renderer>();
        animManager = animManager.GetComponent<GlassAnimationMan>();
        iTimer = iTimer.GetComponent<ITimer>();
    }

    public void AssignValues()
    {
        thisGlass.Clear();
        glassType.drinkList.Clear();
        ingredientesFaltantes = orderType.cantidadIngredientesOrden;
        glassType.drinkList.AddRange(orderType.orderList); 
        iTimer.initialTimer = orderType.orderTime;
        iTimer.ResetTimer();
        iTimer.StartTimer();
        dif = glassType.drinkList.Except(thisGlass).ToList(); 
        orderRenderer.material = orderType.orderMat;
        calidadOrden = 0;
    }
    private void Update()
    {
        if (dif.Count == 0)
        {
            liquidObj.GetComponent<MeshRenderer>().material = orderType.liquidMat;
        }
    }
    /*
private void OnTriggerEnter(Collider other)
{
    if (other.gameObject.TryGetComponent<Bottle1>(out Bottle1 bottleName))
    {
        if (other.gameObject.CompareTag("Interact"))
        {
            if (bottleName.bottleName == "Red")
            {
                thisGlass.Add(bottleName.bottleName);
                other.GetComponent<Bottle1>().PlayBottleSound();
                dif = glassType.drinkList.Except(thisGlass).ToList();
                foreach (var item in dif)
                {
                    Debug.Log(item);
                }
                gameManager.RestarIngrediente();
                Destroy(other.gameObject);
                gameManager.blue = true;
                gameManager.RespawnBottle();
                //newGlassColor = new Color(0, 0, 1, 1);
                //glassRenderer.material.SetColor("_Color", newGlassColor);

            }
        }
    }
    //string bottleName = other.GetComponent<Bottle1>().bottleName;
    /*
    if (other.gameObject.CompareTag("Interact"))
    {
        if (bottleName == "Blue")
        {
            thisGlass.Add(bottleName);
            other.GetComponent<Bottle1>().PlayBottleSound();
            dif = glassType.drinkList.Except(thisGlass).ToList();
            foreach (var item in dif)
            {
              Debug.Log(item);
            }
            gameManager.RestarIngrediente();
            Destroy(other.gameObject);
            gameManager.blue = true;
            gameManager.RespawnBottle();
            //newGlassColor = new Color(0, 0, 1, 1);
            //glassRenderer.material.SetColor("_Color", newGlassColor);

        }
        if (bottleName=="Red")
        {
            thisGlass.Add(bottleName);
            dif = glassType.drinkList.Except(thisGlass).ToList();
            foreach (var item in dif)
            {
                Debug.Log(item);
            }
            gameManager.RestarIngrediente();
            Destroy(other.gameObject);
            gameManager.red = true;
            gameManager.RespawnBottle();
            newGlassColor = new Color(1, 0, 0, 1);
            glassRenderer.material.SetColor("_Color", newGlassColor);
            //gameManager.Prueba();
        }
        if (bottleName == "Green") 
        {
            thisGlass.Add(bottleName);
            dif = glassType.drinkList.Except(thisGlass).ToList();
            foreach (var item in dif)
            {
                Debug.Log(item);
            }
            gameManager.RestarIngrediente();
            Destroy(other.gameObject);
            gameManager.green = true;
            gameManager.RespawnBottle();
            newGlassColor = new Color(120, 171, 57, 1);
            glassRenderer.material.SetColor("_Color", newGlassColor);
        }
        if (bottleName == "Yellow")
        {
            thisGlass.Add(bottleName);
            dif = glassType.drinkList.Except(thisGlass).ToList();
            foreach (var item in dif)
            {
                Debug.Log(item);
            }
            gameManager.RestarIngrediente();
            Destroy(other.gameObject);
            gameManager.green = true;
            gameManager.RespawnBottle();
            newGlassColor = new Color(120, 171, 57, 1);
            glassRenderer.material.SetColor("_Color", newGlassColor);
        }
        if (bottleName == "Yellow")
        {
            thisGlass.Add(bottleName);
            dif = glassType.drinkList.Except(thisGlass).ToList();
            foreach (var item in dif)
            {
                Debug.Log(item);
            }
            gameManager.RestarIngrediente();
            Destroy(other.gameObject);
            gameManager.green = true;
            gameManager.RespawnBottle();
            newGlassColor = new Color(120, 171, 57, 1);
            glassRenderer.material.SetColor("_Color", newGlassColor);
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
