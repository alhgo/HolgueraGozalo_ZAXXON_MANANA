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

    private void Awake()
    {
        gameOverMenu.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        

        imageLifes.sprite = lifeSprite[GameManager.lifes];
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
