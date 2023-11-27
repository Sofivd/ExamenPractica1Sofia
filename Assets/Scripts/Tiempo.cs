using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tiempo : MonoBehaviour
{
    public float timer = 60f;

    public TextMeshProUGUI textoTiempo;

    public GameObject FinDelJuego;
    void Update()
    {
        timer += Time.deltaTime;
        textoTiempo.text = "Tiempo: " + timer.ToString("f1");

        if(timer == 50)
        {
            Time.timeScale = 0f;
            FinDelJuego.gameObject.SetActive(true);
        }
    }
}
