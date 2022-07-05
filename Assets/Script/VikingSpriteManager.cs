using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VikingSpriteManager : MonoBehaviour
{
    public GameObject vikingSprite;
    public VikingSpriteSO viking;
    //public List<GameObject> vikingSprites;
    //public Transform transform;
    public Animator animator;
    //public List<Sprite> vikingSprites;
    public List<VikingSpriteSO> vikingSprites;
    [SerializeField] bool changeSprite;

    public VikingSpriteSO GetRandomSprite(List<VikingSpriteSO> spritesToRandomize)
    {
        int randomNum = Random.Range(0, vikingSprites.Count);
        //Sprite newSprite = spritesToRandomize[randomNum];
        VikingSpriteSO newViking = spritesToRandomize[randomNum];
        return newViking;
    }
    
    public void ChangeSprite()
    {
        
        if (!changeSprite)
            return;
        
        Debug.Log("hola");
        viking = GetRandomSprite(vikingSprites);
        ChangeImage();
        changeSprite = false;
    }

    void ChangeImage()
    {
        vikingSprite.GetComponent<SpriteRenderer>().sprite = viking.vikingWaiting;
    }

    void HappyImage()
    {
        vikingSprite.GetComponent<SpriteRenderer>().sprite = viking.vikingHappy;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Glass"))
        {
            Debug.Log("EntroVaso");
            HappyImage();
        }
    }

    void ChangeAnimation()
    {
        animator.Play("ChangeSprite");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Glass"))
        {
            ChangeAnimation();
            changeSprite = true;
            ChangeSprite();
        }
    }


}
