using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarcarEscena : MonoBehaviour
{
    public void CargarPantalla()
    {
        LevelLoader.nextLevel = "Episodio_01_exterior";
        SceneManager.LoadScene("Pantalla de Carga");
    }
}
