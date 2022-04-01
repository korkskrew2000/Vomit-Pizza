using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RnadomBlink : MonoBehaviour
{

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Blink());
    }

    public IEnumerator Blink() {
        int wait = Random.Range(1, 9);
        yield return new WaitForSeconds(wait);
        anim.SetBool("blink", true);
        yield return new WaitForSeconds(0.1f);
        anim.SetBool("blink", false);
    }

}
