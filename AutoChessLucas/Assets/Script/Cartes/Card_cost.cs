using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_cost : MonoBehaviour
{
    [SerializeField] private List<Sprite> couts;
    public int cost;
    private SpriteRenderer spriteR;
    void Start()
    {
        spriteR = GetComponent<SpriteRenderer>();
        spriteR.sprite = couts[cost];
    }

    
}
