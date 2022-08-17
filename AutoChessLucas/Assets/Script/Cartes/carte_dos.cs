using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carte_dos : MonoBehaviour
{
    private List<float> tailleCarte;
    private float scaleMax = 2f;
    public float delaisMax = 1f;
    private float delais;
    public bool isSclaing = false;
    public GameObject dos;
    private Animator Anim;

    void Start()
    {
        tailleCarte = GetComponent<Déplacement_carte>().tailleCarte;
        delais = delaisMax;
        Anim = dos.GetComponent<Animator>();
    }

    void Update()
    {

        Vector2 Souris = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (!GetComponent<Déplacement_carte>().Selectionnee && (Souris.x > transform.position.x - (tailleCarte[0] / 2) && Souris.x < transform.position.x + (tailleCarte[0] / 2) && Souris.y > transform.position.y - (tailleCarte[1] / 2) && Souris.y < transform.position.y + (tailleCarte[1] / 2)))
        {
            delais -= Time.deltaTime;

        }
        else
        { 
            isSclaing = false;
            delais = delaisMax;
        }

        if (isSclaing && transform.localScale.x < scaleMax) 
        {
            transform.localScale = new Vector3(transform.localScale.x + scaleMax / 100, transform.localScale.x + scaleMax / 100, transform.localScale.x + scaleMax / 100);
        }
        else if (isSclaing && transform.localScale.x >= scaleMax)
        {
            transform.localScale = new Vector3(scaleMax, scaleMax, scaleMax);
        }
        else
        {
            if (transform.localScale.x > 1)
            {
                transform.localScale = new Vector3(transform.localScale.x - scaleMax / 100, transform.localScale.x - scaleMax / 100, transform.localScale.x - scaleMax / 100);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
                
            }
        }
        if (delais <= 0) 
        {
            isSclaing = true;

        }
        if (isSclaing)
        {
            Anim.SetBool("here", true);
        }
        else
        {
            Anim.SetBool("here", false);
        }

    }

}