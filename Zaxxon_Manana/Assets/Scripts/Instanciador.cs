using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciador : MonoBehaviour
{
    [SerializeField] GameObject obst1;
    [SerializeField] Transform instPos;

    //Intervalo de la corrutina
    float intervalo;
    float distanciaEntreObstaculos;
    float speed;

    //Variables de instanciación
    float randomRangeX = 40f;

    float randomX;
    // Start is called before the first frame update
    void Start()
    {
        intervalo = 2f;
        StartCoroutine("Iniciar");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CrearObstaculo()
    {
        randomX = Random.Range(-randomRangeX, randomRangeX);
        Vector3 randomPos = new Vector3(randomX, instPos.position.y, instPos.position.z);
        Instantiate(obst1, randomPos, Quaternion.identity);
    }

    IEnumerator Iniciar()
    {


        while(true)
        {

            CrearObstaculo();
            yield return new WaitForSeconds(intervalo);
            

        }
    }
}
