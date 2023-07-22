using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonidoGen : MonoBehaviour
{
    public GameObject SonidoGenerador;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SonidoGenerador.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        SonidoGenerador.SetActive(false);
    }
}
