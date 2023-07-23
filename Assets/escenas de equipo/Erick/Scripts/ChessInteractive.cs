using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssetsInputController;


public class ChessInteractive : MonoBehaviour
{
    [SerializeField] GameObject panelLock = null;
    public Inventory _inventory;
    public FPSController flashlightPlayer;
    public GameObject CanvasInteractive;
    public SceneManager01 Pieces;
    public GameObject PiezaCaballo;
    public GameObject PiezaAlfil;
    public GameObject PiezaReina;

    public enum ObjetType { Chess, }
    public ObjetType lockType;

    [Header("Controlador de puzzle")]
    [SerializeField] GameObject camaraChess = null;
    AssetInput _AssetInput;


    private void Awake()
    {
        _inventory = FindObjectOfType<Inventory>();
        flashlightPlayer = FindObjectOfType<FPSController>();
        _AssetInput = FindObjectOfType<AssetInput>();
    }

    private void Update()
    {
        if (Pieces.PiezaCaballo)
            PiezaCaballo.SetActive(true);
        if (Pieces.PiezaReina)
            PiezaReina.SetActive(true);

        if (_AssetInput.closePuzzle)
        {
            CerrarCanvasPuzzle();
            _AssetInput.closePuzzle = false;
        }
        else
            return;
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
        _inventory.inPuzzle = true;
        camaraChess.SetActive(true);
        flashlightPlayer.FlashlightOn = false;
        CanvasInteractive.SetActive(false);

    }
    public void CerrarCanvasPuzzle()
    {
        camaraChess.SetActive(false);
        flashlightPlayer.FlashlightOn = true;
        CanvasInteractive.SetActive(true);
        _inventory.inPuzzle = false;
    }

    public void PuzzleCompletado()
    {
        camaraChess.SetActive(false);
        flashlightPlayer.FlashlightOn = true;
        CanvasInteractive.SetActive(false);
        //Time.timeScale = 1;
        _inventory.interact = false;
    }
}
