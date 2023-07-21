using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivarCam : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;

    public void DesactiveCam()
    {
        cam1.SetActive(false);
        cam2.SetActive(true);
    }
}
