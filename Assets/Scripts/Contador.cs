using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Contador : MonoBehaviour
{
    private int monedas;
    public TextMeshProUGUI monedasTexto;
    void Start()
    {
        monedas = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monedas")
        {
            monedas++;
            monedasTexto.text = "Monedas recolectadas: " + monedas;
            Debug.Log(monedas);
        }
        if(monedas == 3)
        {
            Destroy(GameObject.Find("Puerta"));
        }
    }

}
