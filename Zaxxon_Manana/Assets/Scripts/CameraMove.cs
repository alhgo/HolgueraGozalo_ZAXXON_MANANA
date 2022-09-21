using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Transform nave;
    [SerializeField] float offsetZ; 
    [SerializeField] float offsetY;

    //Variables para el movimiento suavizado
    Vector3 currentPos;
    [SerializeField] float smoothMoveVelocity = 0.01F;
    private Vector3 velocity = Vector3.zero;




    // Start is called before the first frame update
    void Start()
    {
        offsetZ = 10f;
        offsetY = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = nave.position;

        currentPos = Vector3.SmoothDamp(currentPos, targetPos, ref
velocity, smoothMoveVelocity);
        transform.Translate(currentPos * Time.deltaTime);

        /*

        

        transform.position = newPos;

        */

        //transform.LookAt(nave);

        //print(nave.position);
    }
}
