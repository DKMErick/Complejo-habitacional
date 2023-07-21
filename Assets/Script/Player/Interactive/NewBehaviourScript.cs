using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject imagenql;


    private void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            imagenql.SetActive(true);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            imagenql.SetActive(false);

        }
    }
}
