using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoNaSkrzyzowaniu : MonoBehaviour
{
    public bool czyKolizja1 = false, czyKolizja2 = false;
    bool czySpawnowac = true;
    public Transform droga;
    public GameObject auto, klon;
    public float speed, defaultspeed, acceleration;

    void przyspiesz()
    {
        if (speed < defaultspeed)
            speed += acceleration * Time.deltaTime;
    }
    
    void FixedUpdate()
    {
        if (!(czyKolizja1 || czyKolizja2) || gameObject.transform.position.x > -11.0f)
            przyspiesz();
        else
            speed = 0;
        if(gameObject.transform.position.x > 0 && czySpawnowac)
        {
            czySpawnowac = false;
            klon = Instantiate(auto, new Vector3(Random.Range(-40, -25), gameObject.transform.position.y, gameObject.transform.position.z), gameObject.transform.rotation, droga);
            klon.GetComponent<autoNaSkrzyzowaniu>().droga = gameObject.GetComponent<autoNaSkrzyzowaniu>().droga;
            klon.GetComponent<autoNaSkrzyzowaniu>().czyKolizja1 = false;
            klon.GetComponent<autoNaSkrzyzowaniu>().czyKolizja2 = false;
        }
        gameObject.transform.position = new Vector3(gameObject.transform.position.x + speed * Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.tag == "NadjezdzajaceAuto")
            czyKolizja1 = true;
        else if (trigger.tag == "NadjezdzajaceAuto2")
            czyKolizja2 = true;
    }

    void OnTriggerExit(Collider trigger)
    {
        if (trigger.tag == "NadjezdzajaceAuto")
            czyKolizja1 = false;
        else if (trigger.tag == "NadjezdzajaceAuto2")
            czyKolizja2 = false;
    }
}
