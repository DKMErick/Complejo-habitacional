using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarcarEscena : MonoBehaviour
{
    public string escena;

    public void CargarPantalla()
    {
        SceneManager.LoadScene(escena);
    }
}
