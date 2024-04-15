using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{

    public GameObject gracz;
    public float procent;

    void FixedUpdate()
    {
        gameObject.transform.position = new Vector3(gracz.transform.position.x * procent*0.01f, gameObject.transform.position.y, gameObject.transform.position.z);
    }
}
