using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFlashlight : MonoBehaviour
{
    public float distance;
    FPSController _fpsController;
    public GameObject LightStrong;
    public GameObject LightSlow;
    public LayerMask mask;
    public bool ChangeLight;

    private void Start()
    {
        _fpsController = FindObjectOfType<FPSController>();
    }
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance, mask))
        {
            Debug.Log("Ha chocado");
            ChangeLight = true;
        }
        else
        {
            ChangeLight = false;
        }

        if (ChangeLight)
        {
            if (_fpsController.FlashlightOn)
            {
                LightStrong.SetActive(false);
                LightSlow.SetActive(true);
            }
        }
        else
        {
            if (_fpsController.FlashlightOn)
            {
                LightStrong.SetActive(true);
                LightSlow.SetActive(false);
            }
        }
    }

}
