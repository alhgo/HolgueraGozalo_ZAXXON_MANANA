using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

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

    }
    
    // Start is called before the first frame update
    void Start()
    {
        //Velocidad de deplazamiento por defecto
        speedDespl = 10f;

    }

    // Update is called once per frame
    void Update()
    {
        //Tomo los datos de los joysticks
        //print(lStick);

        //joyV = lStick.y;
        //joyH = lStick.x;

        print(joyH + " - " + joyV);
        //rotation = Input.GetAxis("HorizontalJ2");
        rotation = 0f;

        //print(rotation); //mando a consola el valor para vigilarlo

        //Si bajo, subo la velocidad, si subo la bajo
        float multiplySpeed;
        if(joyV > 0)
        {
            multiplySpeed = joyV * 0.5f;
        }
        else if(joyV < 0)
        {
            multiplySpeed = joyV * 2f;
        }
        else
        {
            multiplySpeed = 0f;
        }


        //MOVIMIETO HORIZONTAL Y VERTICAL, con respecto al mundo
        transform.Translate(Vector3.up * speedDespl * multiplySpeed * Time.deltaTime, Space.World);
        transform.Translate(Vector3.right * speedDespl * joyH * Time.deltaTime, Space.World);

        //Hago que rote la nave cuando me desplazo 
        transform.eulerAngles = new Vector3(joyV * -30f, 0f , joyH * -45f);

        //Este código sería para rotarlo con el stick derecho, pero no es compatible con el anterior
        //transform.Rotate(0f,0f,rotation);

        /*
        Vector3 despl = Vector3.up * speed * Time.deltaTime;

        initPos = initPos + despl;

        transform.position = initPos;
        */


        //transform.eulerAngles = new Vector3(0f, 0f, rotation * -45f);

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
