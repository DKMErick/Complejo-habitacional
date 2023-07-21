using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioImage : MonoBehaviour
{
    public GameObject ImageCamera;
    public GameObject ImageWASD;
    public GameObject ImageM2;

    public void Desactive1()
    {
        ImageCamera.SetActive(false);
        ImageWASD.SetActive(true);
    }

    public void Desactive2()
    {
        ImageWASD.SetActive(false);
        ImageM2.SetActive(true);
    }

    public void DesactiveFinal()
    {
        ImageM2.SetActive(false);
    }
}
