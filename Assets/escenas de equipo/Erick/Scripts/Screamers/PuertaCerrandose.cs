using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaCerrandose : MonoBehaviour
{
    public InteractiveDoor _door;

    public bool ActivadorScreamer;
    public bool ActivadorCollider;

    public bool door;
    public bool Inicio;

    public GameObject ScreamerSound;
    public GameObject ColliderScreamer;
    public GameObject ColliderActivador;
    public GameObject TemaInicial;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (ActivadorScreamer)
            {
                ScreamerSound.SetActive(true);
            }
            if (ActivadorCollider)
            {
                ColliderScreamer.SetActive(true);
                if (door)
                {
                    _door.isDoorOpen = false;
                    _door.sonidoFinal = _door.SonidoCerrandoPuerta;
                    _door.sonidoFinal.Play();
                    _door.AbrirPuerta();
                }
            }
            if (Inicio)
            {
                TemaInicial.SetActive(true);
            }

            Destroy(this, 2f);

        }
    }
}
