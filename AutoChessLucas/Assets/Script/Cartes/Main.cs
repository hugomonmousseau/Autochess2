using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public int tailleMain;
    [SerializeField] private float decalageX;
    public List<GameObject> boutonListe;
    public List<GameObject> canvaListe;

    void Start(){
    }
    void Update(){

        for (int i = 0; i < boutonListe.Count; i++){
            if(!boutonListe[i].GetComponent<Déplacement_carte>().Selectionnee){
            Vector3 position = new Vector3(Camera.main.transform.position.x - ((i - (float)(boutonListe.Count-1)/2))*decalageX,Camera.main.transform.position.y - 5.75f, -1);
            boutonListe[i].transform.position = position;
            }
            if(i <= canvaListe.Count - 1)
            {

                Vector2 canvaPosition = new Vector2(0, -5.75f);
                canvaListe[i].transform.position = canvaPosition;
            }
            
        }
    }
}
