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
    public int scoreToAdd;
    public Text scoreText;

    //Blue Respawn
    public bool blue = false;
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
    public int levelIndex;
    public bool canChangeScene;
    [SerializeField] GameObject lvlScene;
    [SerializeField] GameObject postLevelScenePass;
    [SerializeField] GameObject postLevelSceneRetry;
    private void Start()
    {
        ScoreUpdate();
        lvlScene.SetActive(true);
        postLevelScenePass.SetActive(false);
        postLevelSceneRetry.SetActive(false);
    }

    public PedidoSO GetRandomOrder(List<PedidoSO> listToRandomize) //Randomiza un numero de las lista de las posibles ordenes 
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
        if (Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene(levelIndex + 1);
        }
        if (generalTimer.change == true)
        {
            NextLevelCorroboration();
        }
        if (score < -1)
        {
            score = 0;
        }

    }
    public void TesteoVaso()
    {
        if (glass.hasTime == true)
        {
            if (glass.dif.Count <= 0) 
            {
                glass.calidadOrden = 1;
                Debug.Log("Son iguales");
                changeOrder = true;
                ChangeOrder();
                glass.ResetGlass();
                score += 15;
                spritePuntaje.Play("+15");
                ScoreUpdate();
                glass.AssignValues();
            }
            else
            {
                glass.calidadOrden = 0;
                Debug.Log("No son iguales");
                changeOrder = true;
                ChangeOrder();
                glass.ResetGlass();
                score -= 10;
                ScoreCheck();
                ScoreUpdate();
                glass.AssignValues();
            }
        } 
        else
        {
            glass.calidadOrden = 0;
            Debug.Log("No son iguales");
            changeOrder = true;
            ChangeOrder();
            glass.ResetGlass();
            score -= 10;
            ScoreCheck();
            ScoreUpdate();
            glass.AssignValues();
        }
        

    }
    public void RespawnBottle() 
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

    public void ChangeOrder() 
    {
        if (!changeOrder)
            return;

        glass.orderType = GetRandomOrder(typeOrderList);
        changeOrder = false;
    }

    public void RestarIngrediente()
    {
        glass.ingredientesFaltantes -= 1;
    }
    public void NextLevelCorroboration()
    {
        switch (levelIndex)
        {
            case 1:
                if (score >= 60)
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
                if (score <= 90)
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
            case 3:
                if (score <= 130)
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
            case 4:
                if (score <= 150)
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

        }

    } 
    private void ScoreCheck()
    {
        if (score < 0)
        {
            score = 0;
        }

    }

}
