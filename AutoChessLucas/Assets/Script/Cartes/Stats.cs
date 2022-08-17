using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int stat;
    [SerializeField] private float taillePixel = .5f/8;


    void Start()
    {
        ActualisationStat();
    }

    public void ActualisationStat()
    {
        transform.localScale = new Vector3(stat, 1, 1);
        transform.position = new Vector3(transform.position.x + (taillePixel * (stat-1)/2), transform.position.y,transform.position.z);
    }
}
