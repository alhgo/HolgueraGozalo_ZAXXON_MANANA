using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuConf : MonoBehaviour
{

    [SerializeField] Slider sliderMusic;
    [SerializeField] Slider sliderSFX;

    [SerializeField] Text textMusic;

    // Start is called before the first frame update
    void Start()
    {

        sliderMusic.value = GameManager.volumeMusic;
        textMusic.text = GameManager.volumeMusic.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateMusicVolume()
    {
        textMusic.text = sliderMusic.value.ToString();
        GameManager.volumeMusic = (int)sliderMusic.value;
        PlayerPrefs.SetInt("V_MUSIC", (int)sliderMusic.value);
    }
}
