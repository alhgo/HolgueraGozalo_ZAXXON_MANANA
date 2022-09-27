using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleMove : MonoBehaviour
{
    float speed;
    Vector3 despl = new Vector3(0f, 0f, -1f);
    // Start is called before the first frame update
    void Start()
    {
        speed = 30f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(despl * speed * Time.deltaTime);
    }
}
