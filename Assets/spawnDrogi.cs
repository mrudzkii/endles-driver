using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnDrogi : MonoBehaviour
{
    public GameObject[] drogi;
    public GameObject gracz;
    public bool czySpawnowac = true;
    public float predkoscAut;
    int ktory;
    public int czySkrzyzowanie;

    /*void Start()
    {
        czySpawnowac = true;
    }*/

    void FixedUpdate()
    {
        if (gameObject.transform.position.z > 250) czySpawnowac = true;
        if(gameObject.transform.position.z <= 250 && czySpawnowac) 
        {
            czySpawnowac = false;
            GameObject klon;
            czySkrzyzowanie = Random.Range(1, 10);
            Debug.Log(czySkrzyzowanie.ToString());
            if (czySkrzyzowanie == 1 && ktory != 0 && gracz.GetComponent<skrecanie>().czyStart)
            { 
                ktory = 0;
                Debug.Log("kutas penis");
            }
            else
                ktory = Random.Range(1, drogi.Length);
            klon = Instantiate(drogi[ktory], new Vector3(0, 0, gameObject.transform.position.z+23.6f), new Quaternion());
            klon.GetComponent<spawnDrogi>().czySpawnowac = true;
            klon.GetComponent<skryptDrogi>().player = gameObject.GetComponent<skryptDrogi>().player;
            klon.GetComponent<spawnDrogi>().ktory = ktory;
            klon.GetComponent<spawnDrogi>().gracz = gracz;
            klon.name = "droga";
        }
    }
}
