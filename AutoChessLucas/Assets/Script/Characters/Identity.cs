using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Identity : MonoBehaviour
{

    private Animator anim;
    public RuntimeAnimatorController runtimeAnim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        anim.runtimeAnimatorController = runtimeAnim;
        if(runtimeAnim != null)
        {

            Debug.Log(runtimeAnim.name == this.name);
        }
    }

}
