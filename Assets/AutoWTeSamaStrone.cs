using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoWTeSamaStrone : MonoBehaviour
{
    float pozz;

    public float predkoscWlasna;
    public GameObject gracz;

    private void Start()
    {
        pozz = gameObject.transform.position.z;
    }

    private void FixedUpdate()
    {
        pozz -= gracz.GetComponent<skrecanie>().speed * Time.deltaTime - predkoscWlasna * Time.deltaTime;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, pozz);
        if (gameObject.transform.position.z < -11.0f)
            Destroy(gameObject);
    }
}
