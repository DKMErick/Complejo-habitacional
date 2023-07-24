using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssetsInputController;

public class PauseMenuControl : MonoBehaviour
{
    public Inventory inventory;
    public GameObject InventoryPanel;
    public ChessInteractive _chess;
    public InteractiveKey _candado;
    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }


    public void ActivarInventario()
    {
        inventory.inventoryEnabled = !inventory.inventoryEnabled;
    }

    public void Back()
    {
        InventoryPanel.SetActive(false);
    }
    public void CerrarMenu()
    {
        InventoryPanel.SetActive(false);
        _chess.CerrarCanvasPuzzle();
        _candado.CerrarCanvasPuzzle();
        inventory.inPause = false;

        
    }
}
