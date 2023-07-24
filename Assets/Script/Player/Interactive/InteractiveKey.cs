using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveKey : MonoBehaviour
{
    GameObject point;
    [SerializeField] GameObject panelLock = null;
    Inventory _inventory;
    
    public enum ObjetType { CodeLock,  }
    public ObjetType lockType;

    [Header("Controlador de puzzle")]
    [SerializeField] GameObject camaraCandado = null;


    private void Awake()
    {
        point = GameObject.Find("Point");
        panelLock = AsignarComponentes.instance.panelLock;
        _inventory = FindObjectOfType<Inventory>();
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
        point.SetActive(false);
        panelLock.SetActive(true);
        camaraCandado.SetActive(true);
        _inventory.InBox = true;
    }
    public void CerrarCanvasPuzzle()
    {
        point.SetActive(true);
        panelLock.SetActive(false);
        camaraCandado.SetActive(false);
        _inventory.InBox = false;
    }

    public void CorrectKey()
    {
        _inventory.CerrarDoc();
    }
}
