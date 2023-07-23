using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SillaActivadores : MonoBehaviour
{
    public bool ActivadorScreamer;
    public bool ActivadorCollider;

    public GameObject ColliderDeScreamer;
    public Silla _Silla;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (ActivadorCollider)
            {
                ColliderDeScreamer.SetActive(true);
            }

            if (ActivadorScreamer)
            {
                _Silla.AnimationScreamer();
            }
        }
    }
}
