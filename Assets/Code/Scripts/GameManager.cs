using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Librería para cambiar entre escenas
using TMPro; //Librería para usar los TextMeshPro

public class GameManager : MonoBehaviour
{
    //Referencia para guardar la dirección del disco
    Vector2 direction;

    //Referencia al disco
    public GameObject disk;

    //Referencia de las palas
    public GameObject playerLeft, playerRight;

    //Referencia para el texto del ganador
    public GameObject winPanel;

    //Referencias a las porterías
    public GameObject goalLeft, goalRight;

    //Referencia Texto del cartel de ganar
    public TextMeshProUGUI winText;

    public void GoalScored() //Método para hacer lo que ocurre al marcar un punto
    {
        //Ponemos el disco al marcar un gol en la posición de origen
        disk.transform.position = Vector2.zero; //Vector2.zero == new Vector2(0,0)

        //Aquí guardamos la velocidad en x que llevaba el disco e invertimos su signo

        direction = new Vector2(-disk.GetComponent<Rigidbody2D>().velocity.x, 0);

        //Paramos el disco
        disk.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        //Ponemos a los jugadores en sus posiciones de origen
        playerLeft.transform.position = new Vector2(-7.1f, 0);
        playerRight.transform.position = new Vector2(7.1f, 0);

        //Usando Invoke esperamos X segundos antes de llamar a un método
        Invoke("LaunchDisk", 2.0f); //Le decimos el método que quiero invocar y el tiempo que tiene que pasar en segundos hasta que se invoque
    }

    //Método para hacer que el disco se lance
    void LaunchDisk()
    {
        disk.GetComponent<Rigidbody2D>().velocity = direction;
    }

    //Método para ir a la pantalla de título
    public void GoMenu()
    {
        //Vamos a la escena de título
        SceneManager.LoadScene("MainMenu");
    }

    public void WinGame()
    {
        //SetActive sirve para activar o desactivar objetos
        winPanel.SetActive(true);

        //Si la información de la puntuación de la portería es mayor que 9
        if (goalRight.GetComponent<GoalZone>().score > 9)
            winText.text = "El jugador rojo ha ganado!";
        else if(goalLeft.GetComponent<GoalZone>().score > 9)
            winText.text = "El jugador azul ha ganado!";

        //Esperamos un tiempo antes de ir a la pantalla del título
        Invoke("Go Menu", 2f);
    }
}
