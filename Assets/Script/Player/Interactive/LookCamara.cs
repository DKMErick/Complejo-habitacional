using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookCamara : MonoBehaviour
{
    public Transform camara;

    private void Start()
    {
        camara = AsignarComponentes.instance.camaraPlayer.transform;
        
    }
    void Update()
    {
        Vector3 lookDirection = camara.position - transform.position;

        Quaternion rotation = Quaternion.LookRotation(lookDirection);

        transform.rotation = rotation;
    }
}
