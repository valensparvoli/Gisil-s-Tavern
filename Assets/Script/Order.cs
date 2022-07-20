using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    public PedidoSO orderType;
    

    private void Start()
    {
        ;
        Debug.Log(orderType.orderList.Count);
    }
}
