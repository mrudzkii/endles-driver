using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wTymSamymKierunkuSpawner : MonoBehaviour
{
    public GameObject poprzednie, auto, gracz;

    float ile;

    private void Start()
    {
        ile = Random.Range(45, 90);
    }

    void FixedUpdate()
    {
        if (poprzednie.transform.position.z < 250 - ile)
        {
            ile = Random.Range(45, 90);
            poprzednie = Instantiate(auto, new Vector3(3.43f, .44f, 250f), new Quaternion());
            poprzednie.GetComponent<AutoWTeSamaStrone>().gracz = gracz;
        }
    }

}
