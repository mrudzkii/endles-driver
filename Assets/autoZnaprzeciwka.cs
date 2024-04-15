using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoZnaprzeciwka : MonoBehaviour
{
    float pozz;
    bool zderzenie = false;

    public float predkoscWlasna;
    public GameObject gracz;

    private void Start()
    {
        pozz = gameObject.transform.position.z;
    }

    private void FixedUpdate()
    {
        if (!zderzenie)
        {
            pozz -= gracz.GetComponent<skrecanie>().speed * Time.deltaTime + predkoscWlasna * Time.deltaTime;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, pozz);
        }
        if (gameObject.transform.position.z < -20.0f)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            zderzenie = true;
        }
    }
}
