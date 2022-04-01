using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introScroll : MonoBehaviour
{
    public float speed;
    Renderer re;

    // Start is called before the first frame update
    void Start()
    {
        re = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(transform.position.x,Time.time * speed);
        re.material.mainTextureOffset = offset;
    }
}
