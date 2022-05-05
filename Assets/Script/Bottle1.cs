using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle1 : MonoBehaviour
{
    /*
    public BottleSO typeBottle;
    public Transform posOriginal;
    */

    public string bottleName;

    private Vector3 basePosition;
    private Quaternion baseRotation;
    public PickUpObject pickObject;

    private void Awake()
    {
        basePosition = transform.position;
        baseRotation = transform.rotation;
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Glass"))
        {
            pickObject.DropObject();
            RestartPosition();
        }
    }
    */

    public void RestartPosition()
    {
        transform.SetPositionAndRotation(basePosition, baseRotation);
    }
}
