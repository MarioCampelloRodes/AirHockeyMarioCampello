using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRacketMovement : MonoBehaviour
{
    //Velocidad de la raqueta
    public float racketSpeed = 10f;

    public Rigidbody2D rb; // Esto nos permite acceder al Rigidbody del jugador, lo cual nos permite cambiar su velocidad

    // Start is called before the first frame update
    void Start()
    {
        //Así inicializaríamos el rigidbody desde código
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate() //Para que la longitud de cada frame en segundos mida lo mismo, y así el movimiento sea suavizado
    {
        //Obtenemos el valor del eje asignado, que me devuelve 1 si pulso arriba, -1 si pulso abajo y 0 si no pulso
        float verticalMovement = Input.GetAxis("Vertical");
        
        //Va al componente RigidBody y le aplicamos una velocidad, que es un Vector2 donde en este caso no lo movemos en Y, solo en Y
        rb.velocity = new Vector2(0f, verticalMovement) * racketSpeed; //Multiplicamos la velocidad por la variable racketSpeed
    }
}
