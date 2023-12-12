using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float diskSpeed = 20f;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //El disco empieza con una velocidad que lo empuja a la derecha

        rb.velocity = Vector2.right * diskSpeed; //Equivale a: new Vector2(1, 0)
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     * El objeto collision del paréntesis contiene la información del choque
     * En particular, nos interesa saber cuando choca contra una pala
     * - collision.gameObject: tiene información del objeto contra el cual ha colisionado la pala
     * - collision.transform.position: tiene información de la posición de la pala
     * - collision.collider: tiene información del collider de la pala
     */

    /*
     * Es un método de Unity que detecta colisión entre 2 game objects
     * Al chocar un objeto con otro, le pasa su Colisión por parámetro
    */
    private void OnCollisionEnter2D(Collision2D collision) //El parámetro collision es el que ha chocado contra el disco
    {
        //Si el disco colisiona con la pala izquierda
        if(collision.gameObject.name == "PlayerLeft")
        {
            //Obtenemos el factor de golpeo, le pasamos la posición del disco, la posición de la pala, y lo que mide de alto el collider de la pala (es decir, lo que mide la pala)
            float yF = HitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.y);

            /* Le damos una nueva dirección al disco
             * En este caso con una X a la derecha
             * Y nuestro factor de golpeo calculado
             * Normalizado todo el vector a 1 para que la bola no acelere
             */

            Vector2 direction = new Vector2(1, yF).normalized; //hacemos que no acelere en su movimiento diagonal
            //Le decimos al disco que salga con esa velocidad previamente calculada
            rb.velocity = direction * diskSpeed;
        }
        if (collision.gameObject.name == "PlayerRight")
        {
            //Obtenemos el factor de golpeo, le pasamos la posición del disco, la posición de la pala, y lo que mide de alto el collider de la pala (es decir, lo que mide la pala)
            float yF = HitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.y);

            /* Le damos una nueva dirección al disco
             * En este caso con una X a la derecha
             * Y nuestro factor de golpeo calculado
             * Normalizado todo el vector a 1 para que la bola no acelere
             */

            Vector2 direction = new Vector2(-1, yF).normalized; //hacemos que no acelere en su movimiento diagonal
            //Le decimos al disco que salga con esa velocidad previamente calculada
            rb.velocity = direction * diskSpeed;
        }


    }

    /*
     * 1: el disco choca contra la parte superior de la pala
     * 0: el dico choca contra el centro
     * -1: el disco choca contra la parte inferior
     */

    /* Es un método de tipo 3. En este caso le pasamos 3 parámetros
     * - posición actual del disco
     * - posición actual de la pala
     * - altura de la pala
     * Y el método tal y como lo indicamos nos devuelve una variable de tipo float
     */

    private float HitFactor(Vector2 diskPosition, Vector2 racketPosition, float racketHeight)
    {
        return ((diskPosition.y - racketPosition.y) / racketHeight);
    }
}
