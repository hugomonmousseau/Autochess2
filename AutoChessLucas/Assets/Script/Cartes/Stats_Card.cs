using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats_Card : MonoBehaviour
{
    public int cost;
    public int atk;
    public int hp;
    public int mvt;
    public string race;
    public int range;
    public GameObject unite;

    //game object
    public GameObject GOCost;
    public GameObject GOAtk;
    public GameObject GOHp;
    public GameObject GOMvt;
    [SerializeField] List<GameObject> ListStats;

    private GameObject managerCarte;
    private GameManager gameManager;

    private void Awake()
    {
        for(int i = 0; i <= gameManager.allCards.Length; i++)
        {
            if(gameManager.allCards[i].name == unite.name)
            {
                GOCost.GetComponent<Card_cost>().cost = gameManager.allCards[i].cost;
                GOAtk.GetComponent<Stats>().stat = gameManager.allCards[i].atk;
                GOHp.GetComponent<Stats>().stat = gameManager.allCards[i].mvt;
                GOMvt.GetComponent<Stats>().stat = gameManager.allCards[i].cost;

                cost = gameManager.allCards[i].cost;
                hp = gameManager.allCards[i].hp;
                mvt = gameManager.allCards[i].mvt;
                atk = gameManager.allCards[i].atk;
                range = gameManager.allCards[i].range;
                race = gameManager.allCards[i].race;

            }
        }

    }
    void Start()
    {
        managerCarte = GameObject.FindWithTag("LevelManager");
        ListStats.Add(GOAtk);
        ListStats.Add(GOHp);
        ListStats.Add(GOMvt);
    }
}
