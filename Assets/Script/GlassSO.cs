using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New glass", menuName = "Glass")]
public class GlassSO : ScriptableObject
{
    //public int drinkValue;
    public List<string> drinkList;
    public int cantidadIngredientesSO;
    public PedidoSO order;
}
