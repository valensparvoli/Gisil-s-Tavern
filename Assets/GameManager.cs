using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GlassPrueba glass1;
    public List<PedidoSO> typeOrderList;
    bool changeOrder;

    //Timer
    float timeValue = 4000;
    public GameObject restartCanvas;
    [SerializeField] Text generalScore;
    [SerializeField] Text generalTimer;

    //ScorePlayer
    public int score=10;
    public Text scoreText;
    public Text timerText;

    //Blue Respawn
    public bool blue= false;
    public GameObject blueBottle;
    public Transform blueOriginalTransform;

    //Red Respawn
    public bool red = false;
    public GameObject redBottle;
    public Transform redOriginalTransform;

    //Green Respawn
    public bool green = false;
    public GameObject greenBottle;
    public Transform greenOriginalTransform;

    private void Update()
    {
        timerText.text = glass1.timeValue.ToString();
        /*
        if (glass1.timeValue <= 0)
        {
            
        }
        */
        generalTimer.text = timeValue.ToString();
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            Time.timeScale = 0;
            timeValue = 0;
            Cursor.lockState = CursorLockMode.Confined;
            restartCanvas.SetActive(true);
        }
    }
    private void Start()
    {
        ScoreUpdate();
    }
    
    public PedidoSO GetRandomOrder(List<PedidoSO>listToRandomize) //Randomiza un numero de las lista de las posibles ordenes 
    {
        int randomNum = Random.Range(0, typeOrderList.Count);
        PedidoSO newOrder = listToRandomize[randomNum];
        return newOrder;
    }

    public void RestartEscene()
    {
        SceneManager.LoadScene("Nivel1");
        Time.timeScale = 1;
        timeValue = 40;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void TesteoVaso() //Corroboracion que se hace de si lo entregado esta correctamente preparado. Es llamado desde el btn
    {
        
        if (glass1.dif.Count <= 0 )
        {
            glass1.calidadOrden = 1;
            Debug.Log("Son iguales");
            changeOrder = true;
            
            ChangeOrder();
            glass1.ResetGlass();
            score += 15;
            ScoreUpdate();
            glass1.AssignValues();
            //glass1.orderType= GetRandomOrder(typeOrderList); 
            //GetRandomOrder(typeOrderList);
        }
        else
        {
            glass1.calidadOrden = 0;
            Debug.Log("No son iguales");
            changeOrder = true;
            ChangeOrder();
            glass1.ResetGlass();
            score -= 10;
            ScoreUpdate();
            glass1.AssignValues();
        }

    }
    public void RespawnBottle() //Funcion que respawnea botellas, es llamada unicamente desde el glass
    {
        if (blue)
        {
            blue = false;
            Instantiate(blueBottle, blueOriginalTransform.transform.position, blueOriginalTransform.rotation);
        }
        else if (red)
        {
            red = false;
            Instantiate(redBottle, redOriginalTransform.transform.position, redOriginalTransform.rotation);
        }
        else if (green)
        {
            green = false;
            Instantiate(greenBottle, greenOriginalTransform.transform.position, greenOriginalTransform.transform.rotation);
        }

    }
    public void DescartarYNuevaOrden()
    {
        changeOrder = true;
        ChangeOrder();
        glass1.ResetGlass();
        score -= 10;
        ScoreUpdate();
    }

    void ScoreUpdate()
    {
        scoreText.text = score.ToString();
    }

    public void ChangeOrder() //Cambia la orden del vaso, haciendo que el pedido cambie 
    {
        if (!changeOrder)      
            return;
        
        glass1.orderType = GetRandomOrder(typeOrderList);
        changeOrder = false;
    }

    public void RestarIngrediente() //Resta los ingredientes del vaso
    {
        glass1.ingredientesFaltantes -= 1;
    }
}
