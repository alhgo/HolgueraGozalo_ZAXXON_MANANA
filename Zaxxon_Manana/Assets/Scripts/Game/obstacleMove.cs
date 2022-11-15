using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleMove : MonoBehaviour
{

    [SerializeField] GameObject nave;
    [SerializeField] PlayerManager naveObj;

    float speed;
    Vector3 despl = Vector3.back; //Vectro normalizado de valores 0,0,-1

    float posZ;
    // Start is called before the first frame update
    void Start()
    {
        //print(gameObject.tag);
        nave = GameObject.Find("NavePrefab");
        naveObj = nave.GetComponent<PlayerManager>();

       

    }

    // Update is called once per frame
    void Update()
    {
        Mover();
        
        Destruir();

    }

    void Mover()
    {
        speed = naveObj.speed;
        if(gameObject.tag == "PowerUp")
        {
            speed = speed * 0.2f;
        }
        transform.Translate(despl * speed * Time.deltaTime);
    }

    void Destruir()
    {
        posZ = transform.position.z;
        if (posZ < -10f)
        {
            Destroy(gameObject);
        }

    }
}
