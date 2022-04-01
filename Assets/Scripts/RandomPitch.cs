using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPitch : MonoBehaviour
{
    AudioSource audiosourc;


    void Start()
    {
        audiosourc = GetComponent<AudioSource>();
        audiosourc.pitch = (Random.Range(0.5f, 1.3f));
    }

}
