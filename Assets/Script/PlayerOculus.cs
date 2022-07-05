using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using static OVRInput;
using Button = UnityEngine.UI.Button;
using IButton = OVRInput.Button;

public class PlayerOculus : MonoBehaviour
{
    [SerializeField] private Transform root;
    private GameObject holdingObject;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)
            || GetDown(IButton.PrimaryHandTrigger, Controller.RTouch))
        {
            if (holdingObject != null)
            {
                holdingObject.transform.SetParent(null);
                holdingObject.GetComponent<Rigidbody>().isKinematic = false;
                holdingObject.GetComponent<Bottle1>().RestartPosition();
                holdingObject = null;
            }
            else
            {
                var colls = Physics.OverlapSphere(root.position, 0.08f).ToList();
                if (colls.Count == 0) return;
                var coll = colls.Find(obj => obj.gameObject.CompareTag("Interact"));

                if (coll == null) return;
                holdingObject = coll.gameObject;

                holdingObject.GetComponent<Rigidbody>().isKinematic = true;
                holdingObject.transform.SetPositionAndRotation(root.position, root.rotation);
                holdingObject.transform.SetParent(root);

            }
        }

        if (Input.GetKeyDown(KeyCode.T)
            || GetDown(IButton.SecondaryHandTrigger, Controller.LTouch))
        {
            if (holdingObject != null)
            {
                holdingObject.transform.SetParent(null);
                holdingObject.GetComponent<Rigidbody>().isKinematic = false;
                holdingObject = null;
            }
            else
            {
                var colls = Physics.OverlapSphere(root.position, 0.08f).ToList();
                if (colls.Count == 0) return;
                var coll = colls.Find(obj => obj.gameObject.CompareTag("Interact"));

                if (coll == null) return;
                holdingObject = coll.gameObject;

                holdingObject.GetComponent<Rigidbody>().isKinematic = true;
                holdingObject.GetComponent<Rigidbody>().detectCollisions = true;
                holdingObject.transform.SetPositionAndRotation(root.position, root.rotation);
                holdingObject.transform.SetParent(root);

            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 0.08f);
    }
}
