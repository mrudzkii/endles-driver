using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using TMPro;

public class skrecanie : MonoBehaviour
{
    public float velocity, acceleration, vmax;
    public float speed, speednormal, accelerationz, speedmax;
    float pozx /*currentMousex = 0, firstMousex = 0*/;
    Vector2 currentMouse, firstMouse;
    int kierunek;
    public RectTransform canvas;
    public bool czySkrecac, czyWcisniety;
    public bool czyStart;
    Touch touch;

    public GameObject powodPrzegranej;

    public int punkty = 0;
    public int highscore;
    public GameObject highscoreTxt, playButton, title, punktyTxt, continueButton, noThanks, odliczanieTxt;

    private void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", highscore);
        highscoreTxt.GetComponent<TextMeshProUGUI>().text = "Best: " + highscore.ToString();
        highscoreTxt.SetActive(true);
        continueButton.SetActive(false);
        noThanks.SetActive(false);
        odliczanieTxt.SetActive(false);
        Application.targetFrameRate = 300;
        velocity = 0;
        punktyTxt.GetComponent<TextMeshProUGUI>().text = punkty.ToString();
        punktyTxt.SetActive(false);
        speed = 15;
        speednormal = 15;
        czyStart = false;
        Debug.Log(canvas.sizeDelta.x.ToString());
        Debug.Log(canvas.sizeDelta.y.ToString());
    }

    public void rozpocznij()
    {
        speed = 20;
        speednormal = 20;
        czyStart = true;
        highscoreTxt.SetActive(false);
        playButton.SetActive(false);
        title.SetActive(false);
        punktyTxt.SetActive(true);
    }

    void zwolnij()
    {
        if (speed > 0)
            speed -= accelerationz * Time.deltaTime * 2;
        else if (speed < 0) speed = 0;
    }

    void wyrownaj()
    {
        if (speed < speednormal - 0.1f)
            speed += accelerationz * Time.deltaTime;
        else if (speed > speednormal + 0.1f)
            speed -= accelerationz * Time.deltaTime;
    }

    void przyspiesz()
    {
        if(speed < speedmax)
            speed += accelerationz * Time.deltaTime;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log(Input.mousePosition);
            //firstMousex = Input.mousePosition.x;
            firstMouse = Input.mousePosition;
            czyWcisniety = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            skonczSkrecac();
            czyWcisniety = false;
            wyrownaj();
        }

        if(Input.GetMouseButton(0))
        {
            currentMouse = Input.mousePosition;
        }

        if (czyStart && czyWcisniety && currentMouse.x < firstMouse.x - 0.05f * canvas.sizeDelta.x /*&& Mathf.Abs((currentMouse.y - firstMouse.y) / (currentMouse.x - firstMouse.x)) <= 1*/)
            zacznijSkretLewo();
        else if (czyStart && czyWcisniety && currentMouse.x > firstMouse.x + 0.05f * canvas.sizeDelta.x)
            zacznijSkretPrawo();
        else if(Mathf.Abs(currentMouse.x - 0.05f) < firstMouse.x)
        {
            skonczSkrecac();
        }

        if (czyStart && czyWcisniety && Mathf.Abs((currentMouse.y - firstMouse.y) / (currentMouse.x - firstMouse.x)) > 1 && currentMouse.y < firstMouse.y)
        {
            //skonczSkrecac();
            zwolnij();
        }
        else if (czyStart && czyWcisniety && Mathf.Abs((currentMouse.y - firstMouse.y) / (currentMouse.x - firstMouse.x)) > 1 && currentMouse.y > firstMouse.y)
        {
            //skonczSkrecac();
            przyspiesz();
        }
        else
        {
            //skonczSkrecac();
            wyrownaj();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
            zacznijSkretPrawo();

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            skonczSkrecac();

        if (czySkrecac)
        {
            Skret();
        }
    }

    public void zacznijSkretLewo()
    {
        czySkrecac = true;
        kierunek = -1;
    }
    public void zacznijSkretPrawo()
    {
        czySkrecac = true;
        kierunek = 1;
    }

    public void skonczSkrecac()
    {
        czySkrecac = false;
        velocity = 0;
    }

    private void OnTriggerExit(Collider collider)
    {
        if(collider.tag == "Add Point")
        {
            punkty++;
            punktyTxt.GetComponent<TextMeshProUGUI>().text = punkty.ToString();
            if(punkty > highscore)
            {
                highscore = punkty;
                PlayerPrefs.SetInt("highscore", highscore);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.collider.tag == "Enemy")
        {
            powodPrzegranej = collision.gameObject;
            Time.timeScale = 0;
            Debug.Log("Koniec");
            continueButton.SetActive(true);
            noThanks.SetActive(true);
        }
    }

    public void Skret()
    {
        if(velocity < vmax*Mathf.Min(1, Mathf.Abs(currentMouse.x-firstMouse.x)/(0.25f*canvas.sizeDelta.x)))
            velocity += acceleration * Time.deltaTime * (speed/speedmax) * Mathf.Abs((currentMouse.x - firstMouse.x) / (0.25f * canvas.sizeDelta.x));
        pozx = gameObject.transform.position.x;
        if(Mathf.Abs(pozx + kierunek * velocity * Time.deltaTime / 2) < 5.4f)
            pozx += kierunek * velocity * Time.deltaTime;
        gameObject.transform.position = new Vector3(pozx, gameObject.transform.position.y, gameObject.transform.position.z);
    }
}
