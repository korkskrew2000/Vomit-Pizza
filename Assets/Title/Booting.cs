using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booting : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IntroThing());
    }

    IEnumerator IntroThing() {
        anim.SetBool("Start", true);
        yield return new WaitForSeconds(3);
        anim.SetBool("Second", true);
        yield return new WaitForSeconds(6);
        anim.SetBool("Third", true);
    }
}
