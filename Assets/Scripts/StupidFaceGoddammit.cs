using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StupidFaceGoddammit : MonoBehaviour
{
    
    Animator anim;
    public DialogueSystem diatalk;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (diatalk.currentlyMidSentence == true) {
            anim.SetBool("speaking", true);
        } else {
            anim.SetBool("speaking", false);
        }
    }
}
