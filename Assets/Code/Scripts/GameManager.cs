using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Librer�a para cambiar entre escenas
using TMPro; //Librer�a para usar los TextMeshPro

public class GameManager : MonoBehaviour
{
    //Referencia para guardar la direcci�n del disco
    Vector2 direction;

    //Referencia al disco
    public GameObject disk;

    //Referencia de las palas
    public GameObject playerLeft, playerRight;

    //Referencia para el texto del ganador
    public GameObject winPanel;

    //Referencias a las porter�as
    public GameObject goalLeft, goalRight;

    //Referencia Texto del cartel de ganar
    public TextMeshProUGUI winText;

    public void GoalScored() //M�todo para hacer lo que ocurre al marcar un punto
    {
        //Ponemos el disco al marcar un gol en la posici�n de origen
        disk.transform.position = Vector2.zero; //Vector2.zero == new Vector2(0,0)

        //Aqu� guardamos la velocidad en x que llevaba el disco e invertimos su signo

        direction = new Vector2(-disk.GetComponent<Rigidbody2D>().velocity.x, 0);

        //Paramos el disco
        disk.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        //Ponemos a los jugadores en sus posiciones de origen
        playerLeft.transform.position = new Vector2(-7.1f, 0);
        playerRight.transform.position = new Vector2(7.1f, 0);

        //Usando Invoke esperamos X segundos antes de llamar a un m�todo
        Invoke("LaunchDisk", 2.0f); //Le decimos el m�todo que quiero invocar y el tiempo que tiene que pasar en segundos hasta que se invoque
    }

    //M�todo para hacer que el disco se lance
    void LaunchDisk()
    {
        disk.GetComponent<Rigidbody2D>().velocity = direction;
    }

    //M�todo para ir a la pantalla de t�tulo
    public void GoMenu()
    {
        //Vamos a la escena de t�tulo
        SceneManager.LoadScene("MainMenu");
    }

    public void WinGame()
    {
        //SetActive sirve para activar o desactivar objetos
        winPanel.SetActive(true);

        //Si la informaci�n de la puntuaci�n de la porter�a es mayor que 9
        if (goalRight.GetComponent<GoalZone>().score > 9)
            winText.text = "El jugador rojo ha ganado!";
        else if(goalLeft.GetComponent<GoalZone>().score > 9)
            winText.text = "El jugador azul ha ganado!";

        //Esperamos un tiempo antes de ir a la pantalla del t�tulo
        Invoke("Go Menu", 2f);
    }
}
