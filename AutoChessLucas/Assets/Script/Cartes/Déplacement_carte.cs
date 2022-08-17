using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Déplacement_carte : MonoBehaviour
{
    public GameObject manager;
    public bool Selectionnee;
    public List<float> tailleCarte;
    private GameObject carte;
    private GameObject unite;
    private GameObject personnage;
    public GameObject character;
    private bool IsSpawnable;

    void Start()
    {
        manager = GameObject.FindWithTag("LevelManager");
        manager.GetComponent<Main>().boutonListe.Add(this.gameObject);
        unite = GetComponent<CarteManager>().unite;
        carte = GetComponent<CarteManager>().carte;
        personnage = GetComponent<CarteManager>().personnage;

        unite.SetActive(false);

        //visuels
        for (int i = 0; i < manager.GetComponent<CharactersID>().ListRuntimeAnim.Count; i++)
        {
            if (manager.GetComponent<CharactersID>().ListRuntimeAnim[i].name == unite.name)
            {
                personnage.GetComponent<Identity>().runtimeAnim = manager.GetComponent<CharactersID>().ListRuntimeAnim[i];
                unite.GetComponent<Identity>().runtimeAnim = manager.GetComponent<CharactersID>().ListRuntimeAnim[i];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        //Selection
        Vector2 Souris = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && (Souris.x > transform.position.x - (tailleCarte[0]/2) && Souris.x < transform.position.x + (tailleCarte[0]/2) && Souris.y > transform.position.y - (tailleCarte[1]/2) && Souris.y < transform.position.y + (tailleCarte[1]/2))){
            Selectionnee = true;
        }
        if (Input.GetMouseButtonUp(0) && Selectionnee && IsSpawnable)
        {
            GameObject SpawnedCharacter = Instantiate(character,unite.transform.position,Quaternion.identity);
            for (int i = 0; i < manager.GetComponent<CharactersID>().ListRuntimeAnim.Count; i++)
            {
                if(manager.GetComponent<CharactersID>().ListRuntimeAnim[i].name == unite.name)
                {
                    SpawnedCharacter.GetComponent<Identity>().runtimeAnim = manager.GetComponent<CharactersID>().ListRuntimeAnim[i];
                }
            }

            Selectionnee = false;
        }
        else if(Input.GetMouseButtonUp(0) && Selectionnee)
        {
            Selectionnee = false;
        }
        if (Selectionnee){
            transform.position = new Vector3 (Souris.x,Souris.y,-4.5f);
            unite.transform.position = new Vector3((int)transform.position.x - .5f,(int)transform.position.y - .5f,unite.transform.position.z);
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //spawn zone
        if(collision.gameObject.layer == 7 && Selectionnee){
            unite.SetActive(true);
            carte.SetActive(false);
            IsSpawnable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //spawn zone
        if(collision.gameObject.layer == 7){
            carte.SetActive(true);
            unite.SetActive(false);
            IsSpawnable = false;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 vecteurDroite = transform.TransformDirection(Vector3.right) * tailleCarte[0]/2;
        Gizmos.DrawRay(transform.position, vecteurDroite);
        
        Vector3 vecteurHaut = transform.TransformDirection(Vector3.up) * tailleCarte[1]/2;
        Gizmos.DrawRay(transform.position, vecteurHaut);
    }


}
