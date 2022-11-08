using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.lifes = 3;
        GameManager.shield = 100f;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
