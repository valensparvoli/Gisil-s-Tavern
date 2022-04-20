using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{
    [SerializeField]
    private GameObject glass;
    private Renderer glassRenderer;
    private Color newGlassColor;

    void Start()
    {
        glassRenderer = glass.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameFlow.plateValue == 100)
        {
            Debug.Log("entro100");
            newGlassColor = new Color(0, 0, 1, 1);
            glassRenderer.material.SetColor("_Color", newGlassColor);

            
        }else if (GameFlow.plateValue == 10)
        {
            Debug.Log("entro10");
            newGlassColor = new Color(255, 0, 255, 1);
            glassRenderer.material.SetColor("_Color", newGlassColor);
        }
        else if (GameFlow.plateValue == 110)
        {
            Debug.Log("entro110");
            newGlassColor = new Color(255, 0, 0, 1);
            glassRenderer.material.SetColor("_Color", newGlassColor);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Bottle bottle = other.gameObject.GetComponent<Bottle>();

        if (other.gameObject.CompareTag("Bottle1"))
        {
            Debug.Log("Choco");
            GameFlow.plateValue += bottle.drinkValue;
            Debug.Log(GameFlow.plateValue + "" + GameFlow.orderValue);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Bottle2"))
        {
            GameFlow.plateValue += bottle.drinkValue;
            Debug.Log(GameFlow.plateValue + "" + GameFlow.orderValue);
            Destroy(other.gameObject);
        }
    }

}
