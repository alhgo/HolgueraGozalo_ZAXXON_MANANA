using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciador : MonoBehaviour
{
    [SerializeField] GameObject obst1;
    [SerializeField] Transform instPos;

    float randomX;
    // Start is called before the first frame update
    void Start()
    {
        CrearObstaculo();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CrearObstaculo()
    {
        randomX = Random.Range(-20f, 20f);
        Vector3 randomPos = new Vector3(randomX, instPos.position.y, instPos.position.z);
        Instantiate(obst1, randomPos, Quaternion.identity);

        Invoke("CrearObstaculo", 0.3f);
    }
}
