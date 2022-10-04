using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciador : MonoBehaviour
{
    [SerializeField] GameObject obst1;
    [SerializeField] Transform instPos;

    [SerializeField] PlayerManager playerManager;

    //Intervalo de la corrutina
    float intervalo;
    float distanciaEntreObstaculos;
    float speed;

    //Variables para las columnas iniciales
    float nObstIni;
    float distPrimer = 50f;
    float distIntermedia;

    //Variables de instanciación
    float randomRangeX = 40f;

    float randomX;
    // Start is called before the first frame update
    void Start()
    {
        distanciaEntreObstaculos = 20f;
        speed = playerManager.speed;
        intervalo = distanciaEntreObstaculos / speed;
        //intervalo = 1f;
        StartCoroutine("Iniciar");

        CrearIniciales();
        
    }

    void CrearIniciales()
    {
        distIntermedia = transform.position.z - distPrimer;
        nObstIni = Mathf.Floor( distIntermedia / distanciaEntreObstaculos);
        print(nObstIni);

        float posZ = distPrimer;
        for (int n = 0; n < nObstIni; n++)
        {
            
            CrearObstaculo(posZ);
            posZ += distanciaEntreObstaculos;
        }

        /*
        float posZ = 60f;

        for(int n = 0; n < 100; n++)
        {
            CrearObstaculo(posZ);
            posZ += 10f;
        }
        */

    }

    // Update is called once per frame
    void Update()
    {
        speed = playerManager.speed;
        intervalo = distanciaEntreObstaculos / speed;
    }

    void CrearObstaculo(float posZ)
    {
        randomX = Random.Range(-randomRangeX, randomRangeX);
        Vector3 randomPos = new Vector3(randomX, instPos.position.y, posZ);
        Instantiate(obst1, randomPos, Quaternion.identity);
    }

    IEnumerator Iniciar()
    {


        while(true)
        {

            CrearObstaculo(transform.position.z);
            print(intervalo);
            yield return new WaitForSeconds(intervalo);
            

        }
    }
}
