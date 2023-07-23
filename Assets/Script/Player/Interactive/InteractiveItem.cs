using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveItem : MonoBehaviour
{
    public enum ObjectType { Item }
    public ObjectType itemType;
    public bool Key;
    public bool PieceChess;
    public bool LlaveFinal;
    public AudioSource recoger;
    public Inventory _inventory;
    public SceneManager01 llaves;
    public GameObject TemaFinal;

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
                    {
                        llaves.LlaveRey = true;
                        if(LlaveFinal)
                            TemaFinal.SetActive(true);
                    } 
                    else if (item.Type == "Llave Torre")
                    {
                        llaves.LlaveTorre = true;
                        recoger.Play();
                    }
                    else if (item.Type == "Llave Alfil")
                    {
                        recoger.Play();
                        llaves.LlaveAlfil = true;
                    }
                    else if (item.Type == "Llave generador")
                    {
                        recoger.Play();
                        llaves.LlaveGenerador = true;
                    }
                }

                if (PieceChess)
                {
                    if (item.Type == "Pieza Caballo")
                    {
                        recoger.Play();
                        llaves.PiezaCaballo = true;
                    }
                    else if (item.Type == "Pieza Alfil")
                    {
                        recoger.Play();
                        llaves.PiezaAlfil = true;
                    }
                    else if (item.Type == "Pieza Reina")
                    {
                        recoger.Play();
                        llaves.PiezaReina = true;
                    }

                }

                break;
            default:
                break;
        }
    }
}
