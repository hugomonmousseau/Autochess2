using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats_Card : MonoBehaviour
{
    public int cost;
    public int atk;
    public int hp;
    public int mvt;

    //game object
    public GameObject GOCost;
    public GameObject GOAtk;
    public GameObject GOHp;
    public GameObject GOMvt;
    [SerializeField] List<GameObject> ListStats;

    private GameObject managerCarte;

    private void Awake()
    {
        GOCost.GetComponent<Card_cost>().cost = cost;
        GOAtk.GetComponent<Stats>().stat = atk;
        GOHp.GetComponent<Stats>().stat = hp;
        GOMvt.GetComponent<Stats>().stat = mvt;

    }
    void Start()
    {
        managerCarte = GameObject.FindWithTag("LevelManager");
        ListStats.Add(GOAtk);
        ListStats.Add(GOHp);
        ListStats.Add(GOMvt);
    }
}
