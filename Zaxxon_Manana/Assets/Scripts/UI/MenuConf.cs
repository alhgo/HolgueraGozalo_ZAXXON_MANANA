using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuConf : MonoBehaviour
{

    [SerializeField] Slider sliderMusic;
    [SerializeField] Slider sliderSFX;

    [SerializeField] Text textMusic;

    [SerializeField] GameObject[] skinsArray;

    // Start is called before the first frame update
    void Start()
    {

        sliderMusic.value = GameManager.volumeMusic;
        textMusic.text = GameManager.volumeMusic.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        skinsArray[0].transform.Rotate(Vector3.up * Time.deltaTime * 60f);
        skinsArray[1].transform.Rotate(Vector3.up * Time.deltaTime * 60f);
    }

    public void UpdateMusicVolume()
    {
        textMusic.text = sliderMusic.value.ToString();
        GameManager.volumeMusic = (int)sliderMusic.value;
        PlayerPrefs.SetInt("V_MUSIC", (int)sliderMusic.value);
    }

    public void ChooseSkin(int skin)
    {
        GameManager.skin = skin;
        if(skin == 0)
        {
            skinsArray[1].SetActive(false);
            skinsArray[0].SetActive(true);
        }
        else if(skin == 1)
        {
            skinsArray[0].SetActive(false);
            skinsArray[1].SetActive(true);
        }
    }
}
