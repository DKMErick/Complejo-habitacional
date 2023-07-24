using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    [Header("TextoInfoRecoger")]
    public TMP_Text tmpPuerta;
    public GameObject tmpPuertaGO;
    bool activarTexto;
    public string textoPuerta;
    CerrarInfoItems _ContadorScript;
    float time;

    private void Start()
    {
        _inventory = FindObjectOfType<Inventory>();
        _ContadorScript = FindObjectOfType<CerrarInfoItems>();
    }
    private void Update()
    {
        if (activarTexto)
        {
            time += 1 * Time.deltaTime;
            if (time > 2f)
            {
                tmpPuertaGO.SetActive(false);
                time = 0f;
                activarTexto = false;
            }
        }
    }
    public void Interact()
    {
        switch (itemType)
        {
            case ObjectType.Item:
                Item item = gameObject.GetComponent<Item>();
                _inventory.AddItem(gameObject,item.ID, item.Type, item.Description, item.icon, item.ImageItem);
                activarTexto = true;
                if (Key)
                {
                    if (item.Type == "Llave Rey")
                    {
                        llaves.LlaveRey = true;
                        textoPuerta = "Objeto obtenido: Llave del Rey";
                        ColocarTextoPuerta();
                        if (LlaveFinal)
                            TemaFinal.SetActive(true);
                    } 
                    else if (item.Type == "Llave Torre")
                    {
                        llaves.LlaveTorre = true;
                        textoPuerta = "Objeto obtenido: Llave de la Torre";
                        ColocarTextoPuerta();
                        recoger.Play();  
                    }
                    else if (item.Type == "Llave Alfil")
                    {
                        recoger.Play();
                        textoPuerta = "Objeto obtenido: Llave del Alfil";
                        ColocarTextoPuerta();
                        llaves.LlaveAlfil = true;
                    }
                    else if (item.Type == "Llave generador")
                    {
                        recoger.Play();
                        textoPuerta = "Objeto obtenido: Llave de la sala de generadores";
                        ColocarTextoPuerta();
                        llaves.LlaveGenerador = true;
                    }
                }

                if (PieceChess)
                {
                    if (item.Type == "Pieza Caballo")
                    {
                        recoger.Play();
                        textoPuerta = "Objeto obtenido: Pieza de ajedrez del caballo";
                        ColocarTextoPuerta();
                        llaves.PiezaCaballo = true;
                    }
                    else if (item.Type == "Pieza Alfil")
                    {
                        recoger.Play();
                        textoPuerta = "Objeto obtenido: Pieza de ajedrez del alfil";
                        ColocarTextoPuerta();
                        llaves.PiezaAlfil = true;
                    }
                    else if (item.Type == "Pieza Reina")
                    {
                        recoger.Play();
                        textoPuerta = "Objeto obtenido: Pieza de ajedrez de la reina";
                        ColocarTextoPuerta();
                        llaves.PiezaReina = true;
                    }

                }

                break;
            default:
                break;
        }
    }

    public void ColocarTextoPuerta()
    {
        _ContadorScript.Activado = true;
        tmpPuertaGO.SetActive(true);
        tmpPuerta.text = textoPuerta;
    }
}
