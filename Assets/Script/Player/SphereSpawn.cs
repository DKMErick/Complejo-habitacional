using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawn : MonoBehaviour
{
    GameObject SpawnControl;
    public bool InitialSpawn;
    PlayerSpawn _playerSpawn;
    void Start()
    {
        SpawnControl = this.gameObject;
        _playerSpawn = FindObjectOfType<PlayerSpawn>();
    }

    void Update()
    {
        if (!InitialSpawn)
        {
            _playerSpawn.Iniciar();
            SpawnControl.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        InitialSpawn = true;
    }
}
