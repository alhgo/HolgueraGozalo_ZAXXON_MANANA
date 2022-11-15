using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciador : MonoBehaviour
{
    [SerializeField] GameObject[] obst;
    [SerializeField] Transform instPos;

    [SerializeField] PlayerManager playerManager;

    //Intervalo de la corrutina
    float intervalo;
    float distanciaEntreObstaculos;
    float speed;

    //Variables para las columnas iniciales
    float nObstIni;
    float distPrimer = 350f;
    float distIntermedia;

    //Variables de instanciación
    float randomRangeX = 40f;
    float randomRangeY = 20f;

    //Posiciones aleatorias de los obstáculos
    float randomX;
    float randomY;
    // Start is called before the first frame update
    void Start()
    {
        distanciaEntreObstaculos = 80f;
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
        //print(nObstIni);

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
        //Elijo un elemento del array de obstaculos al azar
        int randomObst = Random.Range(0, obst.Length);
        //print(obst[randomObst].name);
        //Si el obstaculo es el 2 o el 3 posición random en Y, si no Y = 0;
        if(obst[randomObst].name == "Obstacle2" || obst[randomObst].name == "Obstacle3" )
        {
            randomY = Random.Range(1, randomRangeY);
        }
        else
        {
            randomY = instPos.position.y;
        }
        //Pongo la posición random en X
        randomX = Random.Range(-randomRangeX, randomRangeX);

        Vector3 randomPos = new Vector3(randomX, randomY, posZ);
        

        Instantiate(obst[randomObst], randomPos, Quaternion.identity);
    }

    IEnumerator Iniciar()
    {


        while(true)
        {

            CrearObstaculo(transform.position.z);
            //print(intervalo);
            yield return new WaitForSeconds(intervalo);
            

        }
    }
}
