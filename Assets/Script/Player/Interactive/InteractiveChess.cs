using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssetsInputController;


public class InteractiveChess : MonoBehaviour
{
    GameObject point;
    [SerializeField] GameObject panelLock = null;
    public Animator anim;
    public Inventory _inventory;
    public GameObject CanvasInteract;
    public GameObject Controls;

    public GameObject player;

    public enum ObjetType { Chess, }
    public ObjetType lockType;

    [Header("Controlador de puzzle")]
    [SerializeField] GameObject camaraChess = null;
    public AssetInput _AssetInput;


    private void Awake()
    {
        point = GameObject.Find("Point");
        anim = GetComponent<Animator>();
        _inventory = FindObjectOfType<Inventory>();
    }

    private void Update()
    {
        if (_AssetInput.closePuzzle)
        {
            CerrarCanvasPuzzle();
            _AssetInput.closePuzzle = false;
        }
    }
    public void Interact()
    {
        switch (lockType)
        {
            case ObjetType.Chess:
                OpenChess();

                break;
            default:
                break;
        }
    }
    public void OpenChess()
    {
        _inventory.interact = true;
        player.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        point.SetActive(false);
        //panelLock.SetActive(true);
        CanvasInteract.SetActive(false);
        camaraChess.SetActive(true);
        Controls.SetActive(true);
        Time.timeScale = 0;
    }
    public void CerrarCanvasPuzzle()
    {
        point.SetActive(true);
        player.SetActive(true);
        //panelLock.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        camaraChess.SetActive(false);
        CanvasInteract.SetActive(true);
        Controls.SetActive(false);
        Time.timeScale = 1;
        _AssetInput.closePuzzle = false;
        _inventory.interact = false;
    }
}

