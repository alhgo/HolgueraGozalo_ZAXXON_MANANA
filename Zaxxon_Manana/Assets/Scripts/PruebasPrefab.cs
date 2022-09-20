using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebasPrefab : MonoBehaviour
{

    [SerializeField] string saludo = "Hola mundo";
    [SerializeField] public bool navePar;

    // Start is called before the first frame update
    void Start()
    {
        print(saludo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
