using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //Velocidad de la nave que leerán los obstáculos
    public float speed;

    //Booleana que me dice si estoy vivo
    public bool alive;

    //¿Ha empezado el juego?
    public bool juegoIniciado = false;

    InputActions inputActions;
    
    //Variable para practicar con vectores
    //Vector3 initPos = Vector3.zero;

    //Variable velocidad de desplazamiento H/V en m/seg
    [SerializeField] float speedDespl = 0f;

    //Variables que recojan el Input
    float joyV;
    float joyH;
    Vector2 lStick;
    //Variable para el stick derecho
    float rotation;

    //Variables para la restriccion de movimiento
    float limiteVertUP = 35f;
    float limiteVertDOWN = 1f;
    float limiteHor = 50f;
    float posY;
    float posX;
    [SerializeField] bool inlimitV = true;
    bool inlimitH;

    //Variables para suavizado en el giro
    public Transform target;
    [SerializeField] float smoothTime = 0.8F;
    private Vector3 velocity = Vector3.zero;

    //Cuerpo del avion que desaparece
    [SerializeField] GameObject cuerpoAvion;

    //Script para actualizar el HUD
    [SerializeField] HudController hudController;

    private void Awake()
    {
        inputActions = new InputActions();

        //inputActions.Player.Move.performed += ctx => lStick = ctx.ReadValue<Vector2>() ;
        //inputActions.Player.Move.canceled += _ => lStick = Vector2.zero;

        inputActions.Player.Disparo.started += _ => Disparar();

        inputActions.Player.JV.performed += ctx => joyV = ctx.ReadValue<float>();
        inputActions.Player.JV.canceled += _ => joyV = 0f;
        inputActions.Player.JH.performed += ctx => joyH = ctx.ReadValue<float>();
        inputActions.Player.JH.canceled += _ => joyH = 0f;
        

        speed = 120f;

        GameManager.lifes = 3;

    }

    void BackTime()
    {
        Time.timeScale = 1f;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        alive = true;

        //Velocidad de deplazamiento por defecto
        speedDespl = 20f;

        //Time.timeScale = 0;

        //Corrutina para acelerar
        StartCoroutine("Acelerar");

        

    }

    // Update is called once per frame
    void Update()
    {
        MoverNave();
        CheckLimits();

    }



    void MoverNave()
    {
        //Tomo mi posición en todo momento
        posX = transform.position.x;
        posY = transform.position.y;

        //print(joyH + " - " + joyV);
        //rotation = Input.GetAxis("HorizontalJ2");
        rotation = 0f;

        //print(rotation); //mando a consola el valor para vigilarlo

        //Si bajo, subo la velocidad, si subo la bajo
        float multiplySpeed;
        if (joyV > 0)
        {
            multiplySpeed = joyV * 0.5f;
        }
        else if (joyV < 0)
        {
            multiplySpeed = joyV * 2f;
        }
        else
        {
            multiplySpeed = 0f;
        }

        



        /*
        if((posY <= limiteVertUP || joyV < 0) && (posY > limiteVertDOWN || joyV > 0))
        {
            inlimitV = true;
        }
        else
        {
            inlimitV = false;
        }
        */


        //MOVIMIETO HORIZONTAL Y VERTICAL, con respecto al mundo
        if (inlimitV == true)
            transform.Translate(Vector3.up * speedDespl * joyV * Time.deltaTime, Space.World);

        if(inlimitH == true)
            transform.Translate(Vector3.right * speedDespl * joyH * Time.deltaTime, Space.World);


        //Hago que rote la nave cuando me desplazo con suavizado

        // Define a target position above and behind the target transform
        Vector3 targetRotation = transform.eulerAngles = new Vector3(joyV * -30f, 0f, joyH * -45f);

        // Smoothly move the camera towards that target position
        //transform.rotation = Vector3.SmoothDamp(transform.rota, targetPosition, ref velocity, smoothTime);

        //transform.eulerAngles = new Vector3(joyV * -30f, 0f, joyH * -45f);
        transform.eulerAngles = Vector3.SmoothDamp(transform.eulerAngles, targetRotation, ref velocity, smoothTime);

        //Este código sería para rotarlo con el stick derecho, pero no es compatible con el anterior
        //transform.Rotate(0f,0f,rotation);

        /*
        Vector3 despl = Vector3.up * speed * Time.deltaTime;

        initPos = initPos + despl;

        transform.position = initPos;
        */


        //transform.eulerAngles = new Vector3(0f, 0f, rotation * -45f);
    }

    void CheckLimits()
    {
        //Compruebo si estoy en el límite vertical
        if (posY > limiteVertUP && joyV > 0)
        {
            inlimitV = false;
        }
        else if (posY < limiteVertDOWN && joyV < 0)
        {
            inlimitV = false;
        }
        else
        {
            inlimitV = true;
        }

        //Comprobar el límite horizontal
        if (posX > limiteHor && joyH > 0)
        {
            inlimitH = false;
        }
        else if (posX < -limiteHor && joyH < 0)
        {
            inlimitH = false;
        }
        else
        {
            inlimitH = true;
        }
    }

    IEnumerator Acelerar()
    {

        while(alive)
        {
            if(speed < 200f)
                speed = speed * 1.1f;

            yield return new WaitForSeconds(1f);

        }


    }

    private void OnTriggerEnter(Collider other)
    {

        GameManager.lifes--;

        hudController.UpdateLifes();

        if(GameManager.lifes == 0)
        {
            speed = 0f;
            cuerpoAvion.SetActive(false);
        }
        
    }

    void Disparar()
    {
        print("PUUUM");
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }


}
