using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public Transform launcher;
    public Shoot canShoot;
    public Rigidbody2D projectile;

    public void Update() {
        ShootOnce();
    }

    public void ShootOnce() {
        Instantiate(projectile, launcher.position, launcher.rotation);

    }
}
