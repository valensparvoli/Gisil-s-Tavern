using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private Transform cameraPosition; //Referencia a la camara dentro del player
    private void Update()
    {
        transform.position = cameraPosition.position; //Actualiza constantemente la posicion de la camara
    }
}
