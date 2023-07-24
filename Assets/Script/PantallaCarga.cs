using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PantallaCarga : MonoBehaviour
{
    [TextArea(2,6)]
    public string[] Mensajes;
    public int numeroMensaje;
    public TextMeshProUGUI Texto;
    public string escena;

    public void CambiarMensaje()
    {
        numeroMensaje = Random.Range(0, Mensajes.Length + 1);

        Texto.text = Mensajes[numeroMensaje];
    }

    public void CambioEscena()
    {
        SceneManager.LoadScene(escena);
    }
}
