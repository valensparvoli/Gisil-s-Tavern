using UnityEngine;
using UnityEngine.UI;

public class ITimerScene : MonoBehaviour
{
    //[SerializeField] private float initialTimer;

    public float initialTimer;
    public bool Counting => counting;
    public bool OutOfTime => timer <= 0;
    private bool counting;
    [SerializeField] private Slider slider;
    private float timer;
    [SerializeField] private LevelController lvlControler;
    [SerializeField] private GameManager gameManager;
    public bool change;

    private void Start() 
    {
        slider = GetComponentInChildren<Slider>(true);
        if (slider) slider.maxValue = initialTimer;
        ResetTimer();
        StartTimer();
    }

    private void Update()
    {
        if (counting && timer > 0)
        {
            timer -= Time.deltaTime;
            if (slider) slider.value = timer;
            if (timer <= 0)
            {
                PauseTimer();
                Debug.Log($"Nos quedamos sin tiempo...");
                change = true;
               
                // QUE PASA SI SE TERMINA EL TIEMPO.
            }
        }
    }

    public void StartTimer() => counting = true;

    public void ResetTimer()
    {
        timer = initialTimer;
        slider.maxValue = initialTimer;
    }

    //public void ResetTimer() => timer = initialTimer; 
    public void PauseTimer() => counting = false;
    public void StopTimer() { PauseTimer(); ResetTimer(); }
    public void ToggleTimer() => counting = !counting;
}
