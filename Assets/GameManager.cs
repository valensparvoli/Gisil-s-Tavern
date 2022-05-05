using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GlassPrueba glass1;
    public List<PedidoSO> typeOrderList;
    bool changeOrder;

    //ScorePlayer
    public int score=10;
    public Text scoreText;
    public Text timerText;

    // Timer
    bool firstGlassTimmer;
    bool secondGlassTimer;
    bool thirdGlassTimmer;

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
    public void Prueba() //Corroboracion que se hace de si lo entregado esta correctamente preparado. Es llamado desde el btn
    {

        if (glass1.dif.Count == 0)
        {
            Debug.Log("Son iguales");
            changeOrder = true;
            glass1.correctPreparation = true;
            ChangeOrder();
            glass1.ResetGlass();
            score += 15;
            ScoreUpdate();
            
            //glass1.orderType= GetRandomOrder(typeOrderList); 
            //GetRandomOrder(typeOrderList);
        }
        else
        {
            Debug.Log("No son iguales");
            changeOrder = true;
            ChangeOrder();
            glass1.ResetGlass();
            score -= 10;
            ScoreUpdate();
        }


        /*
        Debug.Log("Ingreso en prueba");
        if (glass1.thisGlass.Equals(glass1.orderType.orderList))
        {
            Debug.Log("Iguales");
        } else
        {
            Debug.Log("No son iguales");
        }
        */
    }
    public void RespawnBottle() //Funcion que respawnea botellas, es llamada unicamente desde el glass
    {
        if (blue == true)
        {
            blue = false;
            Instantiate(blueBottle, blueOriginalTransform.transform.position, blueOriginalTransform.rotation);
        } else if (red == true)
        {
            red = false;
            Instantiate(redBottle, redOriginalTransform.transform.position, redOriginalTransform.rotation);
        } else if (green == true)
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
        if (changeOrder == true)
        {
            glass1.orderType = GetRandomOrder(typeOrderList);
            changeOrder = false;
        } 
        
    }

    public void RestarIngrediente() //Resta los ingredientes del vaso
    {
        glass1.ingredientesFaltantes -= 1;
    }
}
