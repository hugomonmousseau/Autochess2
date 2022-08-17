using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deplacement : MonoBehaviour
{
    private Vector3 PointDOrigine;
    private Vector3 LastSourisCoo;
    void Update()
    {        
        
        if (Input.GetMouseButtonDown(1)){
            PointDOrigine = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(1) && Camera.main.ScreenToWorldPoint(Input.mousePosition) != LastSourisCoo){
            Vector3 Difference = PointDOrigine - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.transform.position += Difference;
        }
        LastSourisCoo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
