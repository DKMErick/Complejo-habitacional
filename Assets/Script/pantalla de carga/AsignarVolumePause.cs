using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsignarVolumePause : MonoBehaviour
{
    Inventory _inventary;
    void Start()
    {
        _inventary = FindObjectOfType<Inventory>();

        _inventary.AsignarVolume();
    }

}
