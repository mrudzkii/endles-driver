using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carSpawner : MonoBehaviour
{
    public GameObject poprzednie, auto, gracz;

    float ile;

    private void Start()
    {
        ile = Random.Range(60, 130);
    }

    void FixedUpdate()
    {
        if (poprzednie.transform.position.z < 250 - ile)
        {
            ile = Random.Range(60, 130);
            poprzednie = Instantiate(auto, new Vector3(-3.43f, .44f, 250f), new Quaternion(0, 180, 0, 0));
            poprzednie.GetComponent<autoZnaprzeciwka>().gracz = gracz;
        }
    }
}
