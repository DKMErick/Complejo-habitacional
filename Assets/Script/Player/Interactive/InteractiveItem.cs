using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveItem : MonoBehaviour
{
    public enum ObjectType { Item }
    public ObjectType itemType;
    public bool Key;
    public bool PieceChess;
    public Inventory _inventory;
    public SceneManager01 llaves;

    private void Start()
    {
        _inventory = FindObjectOfType<Inventory>();
    }
    public void Interact()
    {
        switch (itemType)
        {
            case ObjectType.Item:
                Item item = gameObject.GetComponent<Item>();
                _inventory.AddItem(gameObject,item.ID, item.Type, item.Description, item.icon, item.ImageItem);

                if (Key)
                {
                    if (item.Type == "Llave Rey")
                        llaves.LlaveRey = true;
                    else if (item.Type == "Llave Torre")
                        llaves.LlaveTorre = true;
                    else if (item.Type == "Llave Alfil")
                        llaves.LlaveAlfil = true;
                    else if (item.Type == "Llave generador")
                        llaves.LlaveGenerador = true;
                }

                if (PieceChess)
                {
                    if (item.Type == "Pieza Caballo")
                        llaves.PiezaCaballo = true;
                    else if (item.Type == "Pieza Alfil")
                        llaves.PiezaAlfil = true;
                    else if (item.Type == "Pieza Reina")
                        llaves.PiezaReina = true;
                }

                break;
            default:
                break;
        }
    }
}
