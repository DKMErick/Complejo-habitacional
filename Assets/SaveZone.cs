using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveZone : MonoBehaviour
{
    public SaveSystem saveData;
    public float playerLife;
    public Vector3 playerPosition;
    public float GameProgress;

    void Start()
    {
        saveData = FindObjectOfType<SaveSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerLife = 10.5f;
            playerPosition = other.transform.position;
            GameProgress = 26.5f;

            saveData.SaveGame(playerLife, playerPosition, GameProgress);
        }
    }
}
