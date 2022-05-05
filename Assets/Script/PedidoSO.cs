using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Order", menuName = "Order")]
public class PedidoSO : ScriptableObject
{
    public List<string> orderList;
    public int orderTime;
    public int cantidadIngredientesOrden;
}
