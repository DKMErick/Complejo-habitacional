using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerrarInfoItems : MonoBehaviour
{
    public float Timer;
    public GameObject PanelInfo;
    public bool Activado;

    void Update()
    {
        if (Activado)
        {
            Timer += 1 * Time.deltaTime;
        }

        if(Timer >= 2)
        {
            PanelInfo.SetActive(false);
            Activado = false;
            Timer = 0;
        }
    }
}
