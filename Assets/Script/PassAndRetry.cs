using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassAndRetry : MonoBehaviour
{
    [SerializeField] private bool retry;
    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            if (retry == true)
            {
                SceneManager.LoadScene(gameManager.levelIndex);
            } else
            {
                SceneManager.LoadScene(gameManager.levelIndex + 1);
            }
        }
        
    }
}
