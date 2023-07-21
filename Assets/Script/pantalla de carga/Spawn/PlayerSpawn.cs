using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{

    public void Iniciar()
    {
        transform.position = SpawnManager.instance.spawnPlayer.position;
    }
}
