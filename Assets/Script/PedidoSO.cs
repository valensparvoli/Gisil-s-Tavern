using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Order", menuName = "Order")]
public class PedidoSO : ScriptableObject
{
    public List<string> orderList;
    public float orderTime;
    public int cantidadIngredientesOrden;

    public Material orderMat;
}
