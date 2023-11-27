using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovParedH : MonoBehaviour
{
   
    bool haciaIzquierda;
    void Update()
    {
        if (haciaIzquierda == true)
        {
            transform.Translate(2 * Vector2.left * Time.deltaTime);
        }
        else
        {
            transform.Translate(2 * Vector2.right * Time.deltaTime);

        }

        if (transform.position.x >= -2)
        {
            haciaIzquierda = true;

        }
        else if (transform.position.x <= -5.2f)
        {
            haciaIzquierda = false;
        }
    }
}
