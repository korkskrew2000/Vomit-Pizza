using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
    Animator anim;
    public int kickDamage = 100;

    float kickTime = 0.25f;
    float kickCounter = 0.25f;
    bool isKicking;

    float kickReload = 1f;
    float reloadcount = 1f;
    bool isReloading;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isKicking) {
            kickCounter -= Time.deltaTime;
            if(kickCounter <= 0) {
                isKicking = false;
                anim.SetBool("kicking", false);
            }
        }

        if (isReloading)
            kickReload -= Time.deltaTime;
        if(kickReload <= 0) {
            isReloading = false;
            kickReload = reloadcount;
        }

        if (Input.GetButtonDown("Kick") && !isReloading) {
            kickCounter = kickTime;
            KickAttack();
            isKicking = true;
            isReloading = true;
        }
    }

    void KickAttack() {
        anim.SetBool("kicking", true);
    }
}
