using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class MovJugador : MonoBehaviour
{
    public float movX, movY;
    public float fuerzadeSalto = 0.5f;

    public bool saltar = false;
    public bool enSuelo = false;

    Rigidbody2D rb;

    SpriteRenderer sprite;

    private Color ColorBase;
    private bool Pausar = false;

    private float TiempoPausado = 2.0f;
    private float TiempoChoque;

    public GameObject ParedesEnemigas;
    public GameObject FinDelJuego;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        ColorBase = sprite.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            saltar = true;
        }

        if (Pausar && Time.time - TiempoChoque >= TiempoPausado)
        {
            ResetColor();
            Pausar = false;
        }

        if (!Pausar)
        {
            movX = Input.GetAxis("Horizontal");
            movY = Input.GetAxis("Vertical");
            Vector2 direccion = new Vector2(movX, movY);
            transform.Translate(direccion * Time.deltaTime * 10);

            if (Input.GetButtonDown("Jump"))
            {
                saltar = true;
            }
        }

        else
        {
            rb.velocity = Vector2.zero;
        }
    }
        public void Pausa()
        {
            Time.timeScale = 1.0f;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log(collision.gameObject.name);
            enSuelo = true;

            if (collision.gameObject.name == "suelo")
            {
                enSuelo = true;
            }

          if(collision.gameObject.CompareTag("Enemigo"))
            {
            sprite.color = Color.red;
            Debug.Log("Has perdido una vida");
            Pausar = true;
            TiempoChoque = Time.time;
            }

          if(collision.gameObject.CompareTag("ParedesEnemigas"))
        {
            sprite.color = Color.red;
            Debug.Log("Has perdido una vida");
            Pausar = true;
            TiempoChoque = Time.time;
        }

     }

    private void FixedUpdate()
    {
        if(saltar && enSuelo)
          {
            rb.AddForce(Vector2.up * fuerzadeSalto, ForceMode2D.Impulse);
            saltar = false;
            enSuelo = false;    
          }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        Destroy(collision.gameObject);

        if(collision.gameObject.CompareTag("Trofeo"))
        {
            Time.timeScale = 0f;
            FinDelJuego.gameObject.SetActive(true);
        }
    }

    private void ResetColor()
    {
        sprite.color = ColorBase;
    }

    public void FinalDelJuego()
    {
        FinDelJuego.gameObject.SetActive(true);
    }

}
