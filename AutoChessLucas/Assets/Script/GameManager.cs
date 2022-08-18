using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Card[] allCards = new Card[44];
    private void Awake()
    {
        Instance = this;

    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
