using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    //Raycast
    public float pickUpRange = 5; //Rango para levantar objetos
    private GameObject heldObj; //el objeto que sera levantado
    public Transform holdParent; //referencia al lugar donde ira mientras lo levantamos
    public float moveForce = 250; //Fuerza con la que mueve el objeto

    public Bottle1 bottle;

    void Start()
    {
        heldObj = null;
    }

    // Update is called once per frame
    void Update()
    {
        //Linea dibujada para entender hacia donde realiza el raycast. Es solo de prueba
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 5;
        Debug.DrawRay(transform.position, forward, Color.red);

        //Raycast
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObj == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
                {
                    PickupObject(hit.transform.gameObject);
                    ChangeBottleScript(hit.transform.gameObject);
                }
            }
            else
            {
                DropObject();
                bottle.RestartPosition();
            }

        }


        if (heldObj != null)
        {
            MoveObject();
        }
    }
    void MoveObject()
    {
        if (Vector3.Distance(heldObj.transform.position, holdParent.position) > 0.1f)
        {
            Vector3 moveDirection = (holdParent.position - heldObj.transform.position);
            heldObj.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
        }
    }

    void PickupObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
            objRig.useGravity = false;
            objRig.drag = 10;

            objRig.transform.parent = holdParent;
            heldObj = pickObj;
        }
    }

    public void DropObject()
    {
        Rigidbody heldRig = heldObj.GetComponent<Rigidbody>();
        heldRig.useGravity = true;
        heldRig.drag = 1;

        heldObj.transform.parent = null;
        heldObj = null;
    }

    public void ChangeBottleScript(GameObject pickObj)
    {
        if (pickObj.GetComponent<Bottle1>())
        {
            bottle = pickObj.GetComponent<Bottle1>();
        }
    }

}
