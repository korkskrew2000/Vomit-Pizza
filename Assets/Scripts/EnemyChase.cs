using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform playerPos;
    public float moveSpeed;



    void Update()
    {
            transform.LookAt(playerPos);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
}
