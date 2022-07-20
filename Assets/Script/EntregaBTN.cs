using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntregaBTN : MonoBehaviour
{
    bool entrega = false;
    public GameManager gameManager;
    public GlassPrueba glass;
    public GlassAnimationMan glassAnimation;
    [SerializeField] private AudioSource source;
    private void Start()
    {
        glassAnimation = glassAnimation.GetComponent<GlassAnimationMan>();
    }

    void Update()
    {
        if (entrega == true )
        {
            gameManager.TesteoVaso();
            entrega = false;

            glassAnimation.EntregaAnimation();
        }
    }

    private void OnMouseDown() 
    {
        entrega = true;
        gameManager.glass = glass.GetComponent<GlassPrueba>();
        Debug.Log(gameManager.glass);
        //glass.glassAnimator.SetBool("entregaBool", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            entrega = true;
            gameManager.glass = glass.GetComponent<GlassPrueba>();            
            Debug.Log(gameManager.glass);
            source.Play();
        }
    }
}
