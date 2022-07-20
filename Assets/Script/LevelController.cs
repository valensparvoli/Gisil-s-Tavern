using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelController : MonoBehaviour
{
    [SerializeField] bool Menu;
    [SerializeField] bool Retry;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            if (Menu == true)
            {
                SceneManager.LoadScene(1);
            }
            if (Retry == true)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
