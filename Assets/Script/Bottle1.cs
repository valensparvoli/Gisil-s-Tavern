using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle1 : MonoBehaviour
{
    /*
    public BottleSO typeBottle;
    public Transform posOriginal;
    */

    private Vector3 basePosition;
    private Quaternion baseRotation;

    private void Awake()
    {
        basePosition = transform.position;
        baseRotation = transform.rotation;
    }


    public void RestartPosition()
    {
        transform.SetPositionAndRotation(basePosition, baseRotation);
    }
}
