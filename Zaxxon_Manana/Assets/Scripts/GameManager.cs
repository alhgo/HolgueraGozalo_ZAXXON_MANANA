using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject nave;
    // Start is called before the first frame update
    void Start()
    {
        for(int n = 0; n<20;n++)
        {
            GameObject instanciaNave = Instantiate(nave);

            instanciaNave.GetComponent<PruebasPrefab>().navePar = true; 
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
