using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GlassPrueba glass;
    public List<PedidoSO> typeOrderList;
    bool changeOrder;

    //Timer
    public GameObject restartCanvas;
    [SerializeField] Text generalScore;

    //ScorePlayer
    public int score;
    public Text scoreText;

    //Blue Respawn
    public bool blue= false;
    public GameObject blueBottle;
    public Transform blueOriginalTransform;

    //Red Respawn
    public bool red = false;
    public GameObject redBottle;
    public Transform redOriginalTransform;

    //Green Respawn
    public bool green = false;
    public GameObject greenBottle;
    public Transform greenOriginalTransform;

    //Yellow Respawn
    public bool yellow = false;
    public GameObject yellowBottle;
    public Transform yellowOriginalTransform;

    //Black Respawn
    public bool black = false;
    public GameObject blackBottle;
    public Transform blackOriginalTransform;

    public Animator spritePuntaje;
    [SerializeField] ITimerScene generalTimer;
    [SerializeField] int levelIndex;
    public bool canChangeScene;
    [SerializeField] GameObject lvlScene;
    [SerializeField] GameObject postLevelScenePass;
    [SerializeField] GameObject postLevelSceneRetry;
    private void Start()
    {
        ScoreUpdate();
        ScoreCheecking();
    }
    
    public PedidoSO GetRandomOrder(List<PedidoSO>listToRandomize) //Randomiza un numero de las lista de las posibles ordenes 
    {
        int randomNum = Random.Range(0, typeOrderList.Count);
        PedidoSO newOrder = listToRandomize[randomNum];
        return newOrder;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            spritePuntaje.Play("+15");
        }
        if (generalTimer.change == true)
        {
            NextLevelCorroboration();
            //lvlScene.SetActive(false);
        }

    }

    /*
    public void RestartEscene()
    {
        //SceneManager.LoadScene("Nivel1");
        Time.timeScale = 1;
        timeValue = 40;
        Cursor.lockState = CursorLockMode.Locked;
    }
    */

    public void TesteoVaso() //Corroboracion que se hace de si lo entregado esta correctamente preparado. Es llamado desde el btn
    {
        if (glass.dif.Count <= 0 )
        {
            glass.calidadOrden = 1;
            Debug.Log("Son iguales");
            changeOrder = true;
            
            ChangeOrder();
            glass.ResetGlass();
            score += 15;
            spritePuntaje.Play("+15");
            ScoreUpdate();
            ScoreCheecking();
            glass.AssignValues();
            //glass1.orderType= GetRandomOrder(typeOrderList); 
            //GetRandomOrder(typeOrderList);
        }
        else
        {
            glass.calidadOrden = 0;
            Debug.Log("No son iguales");
            changeOrder = true;
            ChangeOrder();
            glass.ResetGlass();
            score -= 10;
            ScoreUpdate();
            ScoreCheecking();
            glass.AssignValues();
        }

    }
    public void RespawnBottle() //Funcion que respawnea botellas, es llamada unicamente desde el glass
    {
        if (blue)
        {
            blue = false;
            Instantiate(blueBottle, blueOriginalTransform.transform.position, blueOriginalTransform.rotation);
        }
        else if (red)
        {
            red = false;
            Instantiate(redBottle, redOriginalTransform.transform.position, redOriginalTransform.rotation);
        }
        else if (green)
        {
            green = false;
            Instantiate(greenBottle, greenOriginalTransform.transform.position, greenOriginalTransform.transform.rotation);
        }
        else if (yellow)
        {
            yellow = false;
            Instantiate(yellowBottle, yellowOriginalTransform.transform.position, yellowOriginalTransform.transform.rotation);
        }
        else if (black)
        {
            black = false;
            Instantiate(blackBottle, blackOriginalTransform.transform.position, blackOriginalTransform.transform.rotation);
        }

    }
    public void DescartarYNuevaOrden()
    {
        changeOrder = true;
        ChangeOrder();
        glass.ResetGlass();
        score -= 10;
        ScoreUpdate();
    }

    void ScoreUpdate()
    {
        scoreText.text = score.ToString();
    }

    public void ChangeOrder() //Cambia la orden del vaso, haciendo que el pedido cambie 
    {
        if (!changeOrder)      
            return;
        
        glass.orderType = GetRandomOrder(typeOrderList);
        changeOrder = false;
    }

    public void RestarIngrediente() //Resta los ingredientes del vaso
    {
        glass.ingredientesFaltantes -= 1;
    }

    private void ScoreCheecking()
    {
        if (score <= 90)
        {
            canChangeScene = true;
        }
    }

    public void NextLevelCorroboration()
    {
        switch (levelIndex)
        {
            case 1:
                if (score <=90)
                {
                    lvlScene.SetActive(false);
                    postLevelScenePass.SetActive(true);
                }
                else
                {
                    lvlScene.SetActive(false);
                    postLevelSceneRetry.SetActive(true);
                }
                break;
            case 2:
                if (score >= 90)
                {

                }
                break;
                
        }




    }

    private void SaveData()
    {

    }
    private void LoadData()
    {

    }
}
