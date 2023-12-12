using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //Para acceder a los TextMeshPro

public class GoalZone : MonoBehaviour
{
    //Referencia para acceder al marcador de puntos
    public TextMeshProUGUI scoreText;

    //Variable para guardar los puntos marcados en esa porter�a 
    int score;

     private void Awake() //Antes de que empiece el juego
     {
        //Ponemos la puntuaci�n a 0
        score = 0;
        //Cambiamos el texto de la puntuaci�n al valor que tenga en ese momento el score
        scoreText.text = score.ToString();

        //Para transformar un int en un string hay 3 maneras
        //scoreText.text = score + ""; Le sumo un string vac�o a ese int, luego ya ser� todo un string
        //scoreText.text = score.ToString(); transformo(cast) del int al string;
        //scoreText.text = "Score: " + score;
     }

    private void OnTriggerEnter2D(Collider2D collision) //M�todo que detecta cuando algo entra en el collider
    {
        //Solo aquellos GameObjects etiquetados como disco que hayan entrado en el trigger
        if (collision.CompareTag("Disk"))
        {
            score++;

            scoreText.text = score.ToString();
        }
    }
}
