using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndIntro : MonoBehaviour
{

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void EndIntros()
    {
        anim.SetBool("end", true);
    }
}
