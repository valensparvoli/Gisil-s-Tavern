using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public GlassPrueba glass1;
    public List<PedidoSO> typeOrderList;
    bool changeOrder;

    //BlueRespawn
    public bool blue= false;
    public GameObject blueBottle;
    public Transform blueOriginalTransform;

    //RedRespawn
    public bool red = false;
    public GameObject redBottle;
    public Transform redOriginalTransform;


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
        }
        
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
            ChangeOrder();
            glass1.ResetGlass();
            //glass1.orderType= GetRandomOrder(typeOrderList); 
            //GetRandomOrder(typeOrderList);
        }
        else
        {
            Debug.Log("No son iguales");
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
