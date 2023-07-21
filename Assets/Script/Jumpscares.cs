using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpscares : MonoBehaviour
{
    public GameObject objeto;
    public GameObject objetoInterior;
    public GameObject padre;
    public bool isHouse;
    public void Activar()
    {
        objeto.SetActive(true);
    }

    public void objetoI()
    {
        objetoInterior.SetActive(true);
    }
    public void desactivate()
    {
        padre.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Activar();

            if (isHouse)
            {
                Destroy(this.gameObject, 1f);
            }
            
        }
    }
}
