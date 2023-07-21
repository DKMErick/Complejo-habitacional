using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsignarComponentes : MonoBehaviour
{
    public static AsignarComponentes instance;
    public GameObject textoPuerta;
    public GameObject camaraPlayer;
    public GameObject panelLock;
    public GameObject panelDoc;
    public GameObject imagenDoc;
    public GameObject textoDoc;
    public GameObject VolumePause;



    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
