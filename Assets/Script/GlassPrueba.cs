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
    public float timeValue;
    public bool timer;
    public bool canDeliver = true;
    [SerializeField]
    private GameObject glass; 
    private Renderer glassRenderer;
    private Color newGlassColor; 
    public Animator glassAnimator;
    public GlassAnimationMan animManager;
    public AudioSource source;
    public AudioClip vasoDeslizando;
    public AudioClip satisfaccion;
    public int calidadOrden = 0;
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
    private void OnCollisionEnter(Collision collision)
    {
        string bottleName = collision.gameObject.GetComponent<Bottle1>().bottleName;
        if (collision.gameObject.CompareTag("Interact"))
        {
            collision.gameObject.GetComponent<Bottle1>().PlayBottleSound();
            if (bottleName == "Blue")
            {
                Debug.Log("INGRESO");
                thisGlass.Add(bottleName);
                collision.gameObject.GetComponent<Bottle1>().PlayBottleSound();
                dif = glassType.drinkList.Except(thisGlass).ToList();
                foreach (var item in dif)
                {
                    Debug.Log(item);
                }
                gameManager.RestarIngrediente();
                Destroy(collision.gameObject);
                gameManager.blue = true;
                gameManager.RespawnBottle();
                liquidObj.GetComponent<MeshRenderer>().material = collision.gameObject.GetComponent<Bottle1>().bottleMat;
            }
            if (bottleName == "Red")
            {
                thisGlass.Add(bottleName);
                dif = glassType.drinkList.Except(thisGlass).ToList();
                foreach (var item in dif)
                {
                    Debug.Log(item);
                }
                gameManager.RestarIngrediente();
                Destroy(collision.gameObject);
                gameManager.red = true;
                gameManager.RespawnBottle();
                liquidObj.GetComponent<MeshRenderer>().material = collision.gameObject.GetComponent<Bottle1>().bottleMat;
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
                Destroy(collision.gameObject);
                gameManager.green = true;
                gameManager.RespawnBottle();
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
                Destroy(collision.gameObject);
                gameManager.yellow = true;
                gameManager.RespawnBottle();
                liquidObj.GetComponent<MeshRenderer>().material = collision.gameObject.GetComponent<Bottle1>().bottleMat;
            }
            if (bottleName == "Black")
            {
                thisGlass.Add(bottleName);
                dif = glassType.drinkList.Except(thisGlass).ToList();
                foreach (var item in dif)
                {
                    Debug.Log(item);
                }
                gameManager.RestarIngrediente();
                Destroy(collision.gameObject);
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
}
