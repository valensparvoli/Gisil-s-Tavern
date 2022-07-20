using UnityEngine;
using UnityEngine.UI;

public class ITimer : MonoBehaviour
{
    //[SerializeField] private float initialTimer;

    public float initialTimer;
    public bool Counting => counting;
    public bool OutOfTime => timer <= 0;
    private bool counting;
    [SerializeField] private Slider slider;
    private float timer;
    public GlassPrueba glass;
    public DescarteBTN descartebtn;
    private void Start() 
    {
        
        slider = GetComponentInChildren<Slider>(true);
        if (slider) slider.maxValue = initialTimer;
        //Debug.Log(initialTimer);
        descartebtn = descartebtn.GetComponent<DescarteBTN>();
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
                descartebtn.hasTime = false;
                glass.hasTime = false;

                // QUE PASA SI SE TERMINA EL TIEMPO.
            }
        }
    }

    public void StartTimer() => counting = true;

    public void ResetTimer()
    {
        initialTimer = glass.orderType.orderTime;
        timer = initialTimer;
        slider.maxValue = initialTimer;
        descartebtn.hasTime = true;
        glass.hasTime = true;
    }

    //public void ResetTimer() => timer = initialTimer; 
    public void PauseTimer() => counting = false;
    public void StopTimer() { PauseTimer(); ResetTimer(); }
    public void ToggleTimer() => counting = !counting;
}
