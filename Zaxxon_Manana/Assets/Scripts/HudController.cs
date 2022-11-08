using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{

    [SerializeField] Image imageLifes;
    [SerializeField] Sprite[] lifeSprite;


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
        imageLifes.sprite = lifeSprite[GameManager.lifes];
    }
}
