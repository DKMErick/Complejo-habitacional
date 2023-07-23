using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class InteractiveDoor : MonoBehaviour
{
    public enum ObjectType { Door, CloseDoor, LockedDoor, TransitionDoor, BishopDoor, CastleDoor, KingDoor, GeneratorRoom}
    public ObjectType doorType;

    [Header("Controlador de puerta")]
    public bool isDoorOpen;
    public float doorAngleOpen = 95f;
    public float doorAngleClosed = 0.0f;
    public float smooth = 3.0f;

    [Header("Texto Puerta")]
    [SerializeField] TMP_Text tmpPuerta = null;
    [SerializeField] GameObject tmpPuertaGO = null;
    public bool tieneTexto;
    bool activarTexto;
    public string textoPuerta;
    float time;

    [Header("Sonidos de la Puerta")]
    public AudioSource sonidoFinal;
    public AudioSource SonidoCerrada;
    public AudioSource SonidoCerrandoPuerta;
    public AudioSource SonidoAbierta;
    public AudioSource SonidoBloqueada; 

    [Header("Cambio de escena")]
    public string nombreDeEscena;

    [Header("Puertas con Llaves de Formas")]
    public bool abrir;
    public SceneManager01 keyScript;
    public Animator animationOpen;
    public bool IsDoble;
    public InteractiveDoor secondDoor;

    private void Start()
    {
        tmpPuerta = AsignarComponentes.instance.textoPuerta.GetComponent<TMP_Text>();
        tmpPuertaGO = AsignarComponentes.instance.textoPuerta;
        animationOpen = GetComponent<Animator>();
    }
    public void Interact()
    {
        switch (doorType)
        {
            case ObjectType.Door:
                
                if (isDoorOpen)
                {
                    sonidoFinal = SonidoCerrandoPuerta;
                    isDoorOpen = false;
                }
                else
                {
                    isDoorOpen = true;
                    sonidoFinal = SonidoAbierta;
                }
                if (tieneTexto)
                {
                    activarTexto = true;
                }
                sonidoFinal.Play();
                break;
            case ObjectType.CloseDoor:
                sonidoFinal = SonidoCerrada;
                if (tieneTexto)
                {
                    
                    activarTexto = true;
                    sonidoFinal.Play();
                }

                break;
            case ObjectType.LockedDoor:
                sonidoFinal = SonidoBloqueada;
                if (tieneTexto)
                {
                    
                    activarTexto = true;
                    sonidoFinal.Play();
                }

                break;
            case ObjectType.TransitionDoor:
                ChangeScene();

                break;
            case ObjectType.BishopDoor:
                if (keyScript.LlaveAlfil)
                {
                    animationOpen.SetBool("IsOpen", true);
                    tieneTexto = false;
                }
                else
                {
                    sonidoFinal = SonidoCerrada;
                    if (tieneTexto)
                    {
                        
                        activarTexto = true;
                        sonidoFinal.Play();
                    }
                }

                break;
            case ObjectType.CastleDoor:
                if (keyScript.LlaveTorre)
                {
                    animationOpen.SetBool("IsOpen", true);
                    tieneTexto = false;
                }
                else
                {
                    sonidoFinal = SonidoCerrada;
                    if (tieneTexto)
                    {
                        
                        activarTexto = true;
                        sonidoFinal.Play();
                    }
                }
                break;
            case ObjectType.KingDoor:
                if (keyScript.LlaveRey)
                {
                    animationOpen.SetBool("IsOpen", true);
                    tieneTexto = false;
                }
                else
                {
                    sonidoFinal = SonidoCerrada;
                    if (tieneTexto)
                    {
                        
                        activarTexto = true;
                        sonidoFinal.Play();
                    }
                }
                break;
            case ObjectType.GeneratorRoom:
                if (keyScript.LlaveGenerador)
                {
                    animationOpen.SetBool("IsOpen", true);
                    tieneTexto = false;
                }
                else
                {
                    sonidoFinal = SonidoCerrada;
                    if (tieneTexto)
                    {
                        
                        activarTexto = true;
                        sonidoFinal.Play();
                    }
                }
                break;

            default:
                break;
        }
    }
    public void ChangeScene()
    {
        //LevelLoader.nextLevel = nombreDeEscena;
        SceneManager.LoadScene(nombreDeEscena);
        
    }
    private void Update()
    {
        AbrirPuerta();
        ColocarTextoPuerta();
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
            time += 1 * Time.deltaTime;
            tmpPuertaGO.SetActive(true);
            tmpPuerta.text = textoPuerta;

            if(time > 2f)
            {
                tmpPuertaGO.SetActive(false);
                time = 0f;
                activarTexto = false;
            }
        }
    }
    public void ChangeType()
    {
        doorType = ObjectType.Door;
        if (IsDoble)
        {
            secondDoor.ChangeType();
        }
    }

}
