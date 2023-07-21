using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cancelAnim : MonoBehaviour
{
    public InteractiveKey Key;
    public GameObject Candado;

    public void CameraOff()
    {
        Key.CerrarCanvasPuzzle();
        Candado.SetActive(false);
    }
}
