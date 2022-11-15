using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public void ReiniciarVida()
    {
        GameManager.alive = true;
        GameManager.lifes = 3;
        GameManager.shield = 100f;
    }

    public void CargarEscena(int escena)
    {

        SceneManager.LoadScene(escena);
    }

    public void SalirDelJuego()
    {
        Application.Quit();
    }

}
