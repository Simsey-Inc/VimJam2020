using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite[] spriteArray;
    [SerializeField]
    private GameObject[] heartArray;
    [SerializeField]
    private GameObject currentHeart;
    [SerializeField]
    private int currentSprite;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            heartArray[i].GetComponent<SpriteRenderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void ChangeSprite()
    {
        spriteRenderer.sprite = spriteArray[currentSprite];
        currentSprite++;
    }
}
