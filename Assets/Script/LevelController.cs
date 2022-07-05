using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelController : MonoBehaviour
{
    [SerializeField] bool Menu;
    [SerializeField] GameObject playerStats;

   
    
    void LoadNivel1()
    {
        SceneManager.LoadScene("Nivel1");
    }

    void LoadNivel2()
    {
        SceneManager.LoadScene("Nivel2");
        DontDestroyOnLoad(playerStats);
    }

    public void LoadFinalScene()
    {
        SceneManager.LoadScene("FinalScene");
        DontDestroyOnLoad(playerStats);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            if (Menu == true)
            {
                LoadNivel1();
            }
        }
    }
}
