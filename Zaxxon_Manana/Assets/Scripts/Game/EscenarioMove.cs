using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscenarioMove : MonoBehaviour
{

    PlayerManager playerManager;

    [SerializeField] GameObject escenarioPrefab;

    float speed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameObject.Find("NavePrefab").GetComponent<PlayerManager>();

    }

    // Update is called once per frame
    void Update()
    {
        speed = playerManager.speed;
        transform.Translate(Vector3.back * Time.deltaTime * speed);
        if(transform.position.z <= -200f)
        {

            Instantiate(escenarioPrefab, new Vector3(0f, 0f, 400f), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
