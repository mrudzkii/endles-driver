using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skryptDrogi : MonoBehaviour
{
    public float speed;
    public GameObject player;
    float z;
    skrecanie skrecanie;

    void FixedUpdate()
    {
        speed = player.GetComponent<skrecanie>().speed;
        z = gameObject.transform.position.z;
        gameObject.transform.position = new Vector3(0, 0, z - speed * Time.deltaTime);
        if (z < -40.0f)
            Destroy(gameObject);
    }
}
