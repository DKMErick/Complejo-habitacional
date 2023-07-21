using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using AssetsInputController;

public class CambioDeEscena : MonoBehaviour
{
    public GameObject puntoInicial;
    public GameObject pj;
    public string scene;
    AssetInput _AssetInput;
    void Start()
    {
        pj = GameObject.FindGameObjectWithTag("Player");
        puntoInicial = GameObject.FindGameObjectWithTag("PuntoInicial");
        _AssetInput = FindObjectOfType<AssetInput>();
        MoverAPuntoInicial();
    }

    private void Update()
    {
        if (_AssetInput.cambio)
        {
            CambioEscena();
            _AssetInput.cambio = false;
        }
    }

    public void MoverAPuntoInicial()
    {
        pj.transform.position = puntoInicial.transform.position;
    }

    public void CambioEscena()
    {
        SceneManager.LoadScene(scene);
    }
}
