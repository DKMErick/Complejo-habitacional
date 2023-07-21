using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveKey : MonoBehaviour
{
    GameObject point;
    [SerializeField] GameObject panelLock = null;   
    
    public enum ObjetType { CodeLock,  }
    public ObjetType lockType;

    [Header("Controlador de puzzle")]
    [SerializeField] GameObject camaraCandado = null;


    private void Awake()
    {
        point = GameObject.Find("Point");
        panelLock = AsignarComponentes.instance.panelLock;
    }
    public void Interact()
    {
        switch (lockType)
        {
            case ObjetType.CodeLock:
                Openlock();

                break;
            default:
                break;
        }
    }
    public void Openlock()
    {
        Cursor.lockState = CursorLockMode.None;
        point.SetActive(false);
        panelLock.SetActive(true);
        camaraCandado.SetActive(true);
        Time.timeScale = 0;
    }
    public void CerrarCanvasPuzzle()
    {
        Cursor.lockState = CursorLockMode.Locked;
        point.SetActive(true);
        panelLock.SetActive(false);
        camaraCandado.SetActive(false);
        Time.timeScale = 1;
    }

    public void CorrectKey()
    {
        Time.timeScale = 1;
    }
}
