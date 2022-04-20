using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public static int orderValue = 110;
    public static int plateValue = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (plateValue == orderValue)
            {
                Debug.Log("Correcta");
            }
            else
            {
                Debug.Log("Incorrecta");
            }
        }
    }
}
