using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LDgenerator : MonoBehaviour
{
    [SerializeField] private int _nombreTuile;
    [SerializeField] private float _DécalageX = .5f;
    [SerializeField] private bool __LigneDouble;
    public GameObject _Tuile;
    public Sprite TuileSupp;
    public Sprite TuileInf;
    [SerializeField] private GameObject Empty;

    [ContextMenu("Generator")]
    void BackgroudGenerator()
    {

        GameObject LigneInf = Instantiate(Empty);
        GameObject LigneSupp = Instantiate(Empty);
        LigneSupp.name = "Ligne Suppériereure";
        LigneInf.name = "Ligne Inférieure";

        for (int i = 0; i < _nombreTuile; i++)
        {
            Vector3 position = new Vector3(transform.position.x + .5f + _DécalageX * i, transform.position.y- .5f, transform.position.z);
            GameObject background = Instantiate(_Tuile, position, Quaternion.Euler(0, 0, 0));
            background.GetComponent<SpriteRenderer>().sprite = TuileInf;
            background.transform.SetParent(LigneInf.transform);

            if (__LigneDouble)
            {
                GameObject backgroundSup = Instantiate(_Tuile, new Vector3(transform.position.x + .5f + _DécalageX * i, transform.position.y + .5f, transform.position.z), Quaternion.Euler(0, 0, 0));
                backgroundSup.transform.SetParent(LigneSupp.transform);
                backgroundSup.GetComponent<SpriteRenderer>().sprite = TuileSupp;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(Vector3.right) * _nombreTuile;
        Vector3 diagonale = transform.TransformDirection((Vector3.down + Vector3.right) * Mathf.Sqrt(2)) * ((float)2/3);


        Gizmos.DrawRay(transform.position, direction);
        Gizmos.DrawRay(new Vector2(transform.position.x,transform.position.y - 1), direction);

        for (int i = 0; i < _nombreTuile; i++)
        {
            Gizmos.DrawRay(new Vector2(transform.position.x + i, transform.position.y), diagonale);
        }
    }
    
}
