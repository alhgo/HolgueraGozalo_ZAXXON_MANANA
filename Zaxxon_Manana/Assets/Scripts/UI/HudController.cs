using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{

    [SerializeField] Image imageLifes;
    [SerializeField] Sprite[] lifeSprite;

    [SerializeField] GameObject gameOverMenu;

    [SerializeField] Button btnRetry;

    //Barra de energía
    [SerializeField] Slider sliderShield;
    [SerializeField] Text textShield;

    //Velocidad
    [SerializeField] Text textSpeed;


    //Tiempo y distancia
    [SerializeField] Text textoTiempo;
    [SerializeField] Text textoDistancia;
    float distancia;
    float intervaloCehckDistance = 0.2f;

    //PlayerManager
    [SerializeField] PlayerManager playerManager;

    private void Awake()
    {
        gameOverMenu.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {

        imageLifes.sprite = lifeSprite[GameManager.lifes];

        sliderShield.value = GameManager.shield;
        textShield.text = GameManager.shield.ToString();

        //Distancia
        distancia = 0;
        StartCoroutine("UpdateDistance");


    }

    // Update is called once per frame
    void Update()
    {
        sliderShield.value = GameManager.shield;

        textoTiempo.text = Mathf.Floor( Time.time ) + " seg.";

        float speedKmts = (playerManager.speed * 3600) / 1000;
        textSpeed.text = Mathf.Round(speedKmts).ToString();

    }



    public void UpdateLifes()
    {
        if(GameManager.lifes >= 0)
            imageLifes.sprite = lifeSprite[GameManager.lifes];
    }

    public void ActivarGameOver()
    {
        Invoke("MostrarMenu", 2f);
    }

    void MostrarMenu()
    {
        gameOverMenu.SetActive(true);
        btnRetry.Select();
    }

    public void UpdateShield()
    {

        float shieldRound = Mathf.Round(sliderShield.value * 100) / 100;
        print(shieldRound);
        textShield.text = shieldRound.ToString();
    }

    public void UpdateShieldFromPlayerManager()
    {
        sliderShield.value = GameManager.shield;
        textShield.text = GameManager.shield.ToString();
    }

    IEnumerator UpdateDistance()
    {
        while(true)
        {
            //Calculo la distancia recorrida
            distancia += playerManager.speed * intervaloCehckDistance;
            float distanciaRedondeado = Mathf.Floor(distancia * 100) / 100;
            textoDistancia.text = distanciaRedondeado + " mts.";


            yield return new WaitForSeconds(intervaloCehckDistance);

        }
    }


}
