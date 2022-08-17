using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canva : MonoBehaviour
{
    public GameObject manager;
    void Start()
    {
        manager = GameObject.FindWithTag("LevelManager");
        manager.GetComponent<Main>().canvaListe.Add(this.gameObject);

    }
}
