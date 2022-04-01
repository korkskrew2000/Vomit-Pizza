using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    Animator anim;
    public int shootDamage = 100;

    public bool shoot;
    float shootTime = 0.25f;
    float shootCounter = .25f;
    bool isShooting;

    float shootReload = 1f;
    float shootClock = 1f;
    bool isReloading;

    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update() {
        if (isShooting) {
            shootTime -= Time.deltaTime;
            if (shootCounter <= 0) {
                isShooting = false;
                shoot = false;
                anim.SetBool("shooting", false);
            }
        }

        if (isReloading)
            anim.SetBool("shooting", false);
        shootReload -= Time.deltaTime;
        if (shootReload <= 0) {
            isReloading = false;
            shootReload = shootClock;
        }

        if (Input.GetButtonDown("Shoot") && !isReloading) {
            shootCounter = shootTime;
            ShootAttack();
            isShooting = true;
            isReloading = true;
        }
    }

    void ShootAttack() {
        shoot = true;
        anim.SetBool("shooting", true);
    }
}
