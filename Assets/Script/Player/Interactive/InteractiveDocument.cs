using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class InteractiveDocument : MonoBehaviour
{
    GameObject point;
    [Header("asignar")]
    [SerializeField] GameObject panelInfo = null;
    [SerializeField] GameObject panelFoto = null;

    public enum ObjectType { Document, Photo }
    public ObjectType DocumentType;

    [Header("Texto en Documentos")]
    public Image imagenDocCanvas = null;
    public TMP_Text textoDocCanvas = null;
    public Sprite renderDocumento = null;
    [TextArea(6, 12)]
    public string textoDoc;

    [Header("Texto Fotos")]
    public Image imagenPhotoCanvas = null;
    public TMP_Text textoPhotoCanvas = null;
    public Sprite renderPhoto = null;
    [TextArea(3, 6)]
    public string textPhoto;

    Inventory _inventory;

    private void Start()
    {
        point = GameObject.Find("Point");
        panelInfo = AsignarComponentes.instance.panelDoc;
        imagenDocCanvas = AsignarComponentes.instance.imagenDoc.GetComponent<Image>();
        textoDocCanvas = AsignarComponentes.instance.textoDoc.GetComponent<TMP_Text>();
        _inventory = FindObjectOfType<Inventory>();
    }

    public void Interact()
    {
        switch (DocumentType)
        {
            case ObjectType.Document:
                OpenDocument();

                break;
            case ObjectType.Photo:
                OpenPhoto();

                break;
            default:
                break;
        }
    }
    public void OpenDocument()
    {
        Cursor.lockState = CursorLockMode.None;
        point.SetActive(false);
        panelInfo.SetActive(true);
        imagenDocCanvas.sprite = renderDocumento;
        textoDocCanvas.text = textoDoc;
        _inventory.interact = true;
    }
    public void OpenPhoto()
    {
        Cursor.lockState = CursorLockMode.None;
        point.SetActive(false);
        panelFoto.SetActive(true);
        imagenPhotoCanvas.sprite = renderPhoto;
        textoPhotoCanvas.text = textPhoto;
        _inventory.interact = true;
    }
    public void CerrarCanvasInfo()
    {
        Cursor.lockState = CursorLockMode.Locked;
        point.SetActive(true);
        panelInfo.SetActive(false);
        _inventory.interact = false;
    }
    public void CerrarCanvasPhoto()
    {
        Cursor.lockState = CursorLockMode.Locked;
        point.SetActive(true);
        panelFoto.SetActive(false);
        _inventory.interact = false;
    }
}
