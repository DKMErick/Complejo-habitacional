using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerButons : MonoBehaviour
{
    public PlayerData playerData;
    public PlayerInGame player;
    public SaveSystem save;

    public void SaveGame()
    {
        playerData.life = player.life;
        playerData.position = player.position;
        playerData.progressPercentage = player.progressPercentage;
        //playerData.inventory = player.inventory;
        //playerData.completedPuzzles = player.completedPuzzles;

        save.SaveGame(playerData.life, playerData.position, playerData.progressPercentage);
    }
  

    public void LoadGame()
    {
        SaveData saveData = save.LoadGame();

        if (saveData != null)
        {
            // Load the game data and apply it to the game state
            player.life = saveData.playerLife;
            //player.inventory = saveData.inventoryItems[];
            player.position = saveData.playerPosition;
            player.progressPercentage = saveData.gameProgress;
            //player.completedPuzzles = saveData.completedPuzzles;

            //// Proceed to the game scene
            //SceneManager.LoadScene("GameScene");
        }
    }
}
