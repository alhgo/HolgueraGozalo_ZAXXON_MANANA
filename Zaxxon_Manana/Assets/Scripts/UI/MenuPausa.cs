using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPausa : MonoBehaviour
{

    InputActions inputActions;

    [SerializeField] Button button;

    private void Awake()
    {
        inputActions = new InputActions();

        //inputActions.Player.Move.performed += ctx => lStick = ctx.ReadValue<Vector2>() ;
        //inputActions.Player.Move.canceled += _ => lStick = Vector2.zero;

        inputActions.Game.AnyKey.started += _ => LanzarJuego();
    }

    void LanzarJuego()
    {

        print("Pulsada cualquier tecla");
        SceneManager.LoadScene(1);
    }

    // Start is called before the first frame update
    void Start()
    {
        button.Select();
    }

    // Update is called once per frame
    void Update()
    {
        
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
