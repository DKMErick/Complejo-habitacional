using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class InteractiveObject : MonoBehaviour
{

    GameObject point;
    [Header("Asignar")]
    [SerializeField] GameObject panelinfo = null;
    [SerializeField] GameObject panelLock = null;
    public enum ObjectType { Door, CloseDoor,LockedDoor, Document, Lock, SchaferHouse, bishopDoor}
    public ObjectType type;

    [Header("Cambio de Escena")]
    public string nombreDeEscena;

    [Header("Controlador de puerta")]
    public bool isDoorOpen;
    public float doorAngleOpen = 95f;
    public float doorAngleClosed = 0.0f;
    public float smooth = 3.0f;
    [SerializeField] TMP_Text tmpPuerta = null;
    [SerializeField] GameObject tmpPuertaGO = null;
    public string textoPuerta;
    public bool tieneTexto;
    bool activarTexto;
    public float time;
    public AudioSource sonido;

    [Header("Texto de los Documentos")]
    public Image spriteCanvas = null;
    public TMP_Text textoCanvas = null;
    public Sprite documento = null;
    [TextArea (6,12)]
    public string textoDoc;

    [Header("Controlador Canvas")]
    [SerializeField] GameObject camaraLock = null;
    public GameObject textoInteractuar = null;

    public bool tengoLlave;

    [Header("Puertas con Llave de forma")]
    public bool abrir;
    ComprobacionLlave KeyScript;
    public GameObject AnimationOpen;

    private void Awake()
    {
        point = GameObject.Find("Point");
        KeyScript = FindObjectOfType<ComprobacionLlave>();
    }
    public void Interact()
    {
        switch (type)
        {
            case ObjectType.Door:
                if (isDoorOpen)
                {
                    Debug.Log("La puerta se esta cerrando");
                    isDoorOpen = false;
                }
                else
                {
                    Debug.Log("La puerta se esta abriendo");
                    isDoorOpen = true;
                    //sonido.Play();
                }
                if (tieneTexto)
                {
                    activarTexto = true;
                }


                break;
            case ObjectType.CloseDoor:
                Debug.Log("necesitas una llave");
                if (tengoLlave)
                {
                    type = ObjectType.Door;
                    tieneTexto = false;
                }
                else if (tieneTexto)
                {
                    activarTexto = true;
                    //sonido.Play();
                }

                break;
            case ObjectType.LockedDoor:
                Debug.Log("No se puede abrir");
                if (tieneTexto)
                {
                    activarTexto = true;
                    sonido.Play();
                }

                break;
            case ObjectType.Document:
                Debug.Log("Leyendo el documento");
                OpenDocument();

                break;
            case ObjectType.Lock:
                OpenLock();

                break;
            case ObjectType.SchaferHouse:
                EnterHouse();

                break;
            case ObjectType.bishopDoor:
                Debug.Log("Necesitas la llave de arfil");
                if (KeyScript.LLaveArfil)
                {
                    AnimationOpen.SetActive(true);
                    tieneTexto = false;
                }
                else
                {
                    if (tieneTexto)
                    {
                        activarTexto = true;
                        //sonido.Play();
                    }
                }
                
                break;
            default:
                break;
        }
    }
    public void OpenDocument()
    {
        Cursor.lockState = CursorLockMode.None;
        point.SetActive(false);
        panelinfo.SetActive(true);
        spriteCanvas.sprite = documento;
        textoCanvas.text = textoDoc;
        Time.timeScale = 0; 

    }    
    public void OpenLock()
    {
        Cursor.lockState = CursorLockMode.None;
        point.SetActive(false);
        panelLock.SetActive(true);
        Time.timeScale = 0;
        camaraLock.SetActive(true);
        //textoInteractuar.SetActive(false);

    }
    public void CerrarCanvas()
    {
        point.SetActive(true);
        panelinfo.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1; 

    }    
    public void CerrarCanvasLock()
    {
        point.SetActive(true);
        panelLock.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1; 
        camaraLock.SetActive(false);

    }

    public void EnterHouse()
    {
        LevelLoader.nextLevel = nombreDeEscena;
        SceneManager.LoadScene("Pantalla de Carga");
    }

    private void Update()
    {
        AbrirPuerta();
        if (activarTexto)
        {
            time += 1 * Time.deltaTime;

        }
        ColocarTextoPuerta();
    }

    public void ChangeType()
    {
        type = ObjectType.Door;
        AnimationOpen.SetActive(false);
    }
    public void AbrirPuerta()
    {
        if (isDoorOpen)
        {

            Quaternion targetRotation = Quaternion.Euler(0, 0, doorAngleOpen);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
        }
        else
        {

            Quaternion targetRotation = Quaternion.Euler(0, 0, doorAngleClosed);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
        }
    }
    public void ColocarTextoPuerta()
    {
        if (activarTexto)
        {
            tmpPuertaGO.SetActive(true);
            tmpPuerta.text = textoPuerta;

            if (time > 2f)
            {
                tmpPuertaGO.SetActive(false);
                time = 0f;
                activarTexto = false;
            }

        }
    }

}
