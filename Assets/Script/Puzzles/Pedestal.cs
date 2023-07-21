using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestal : MonoBehaviour
{
    public int PiezaCorrecta;
    public bool Conseguido;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Drag"))
        {
            if(other.GetComponent<Pieza>().numeroPieza == PiezaCorrecta)
            {
                Conseguido = true;
            }
            else
            {
                Conseguido = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Conseguido = false;
    }
}
