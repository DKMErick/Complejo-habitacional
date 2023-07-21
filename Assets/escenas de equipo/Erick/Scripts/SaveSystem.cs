using UnityEngine;
using System.IO;
using System.Collections.Generic;

[System.Serializable]
public class SaveData
{
    public float playerLife;
    public List<string> inventoryItems;
    public Vector3 playerPosition;
    public float gameProgress;
    public List<bool> completedPuzzles;
}

public class SaveSystem : MonoBehaviour
{
    private string savePath;

    private void Awake()
    {
        savePath = Path.Combine(Application.persistentDataPath, "saveData.json");
        DontDestroyOnLoad(this);
    }

    public void SaveGame(float playerLife, Vector3 playerPosition, float gameProgress)
    {
        SaveData saveData = new SaveData();
        saveData.playerLife = playerLife;
        //saveData.inventoryItems = inventoryItems;
        saveData.playerPosition = playerPosition;
        saveData.gameProgress = gameProgress;
        //saveData.completedPuzzles = completedPuzzles;

        string jsonData = JsonUtility.ToJson(saveData);
        File.WriteAllText(savePath, jsonData);

        Debug.Log("Game saved!");
    }

    public SaveData LoadGame()
    {
        if (File.Exists(savePath))
        {
            string jsonData = File.ReadAllText(savePath);
            SaveData saveData = JsonUtility.FromJson<SaveData>(jsonData);
            Debug.Log("Game loaded!");
            return saveData;
        }
        else
        {
            Debug.Log("No save file found!");
            return null;
        }
    }
}

public class InteractableObject : MonoBehaviour
{
    private SaveSystem saveSystem;

    private void Start()
    {
        saveSystem = FindObjectOfType<SaveSystem>();
    }

    public void Interact()
    {
        //// Perform interaction logic here

        //// Save the game after interacting
        //saveSystem.SaveGame(playerLife, inventoryItems, playerPosition, gameProgress, completedPuzzles);

        //// Display a message on the screen indicating the game is saving
        //Debug.Log("Saving game...");
    }
}

//public class MainMenu : MonoBehaviour
//{
//    //private SaveSystem saveSystem;

//    //private void Start()
//    //{
//    //    saveSystem = FindObjectOfType<SaveSystem>();
//    //}

//    //public void LoadGame()
//    //{
//    //    SaveData saveData = saveSystem.LoadGame();

//    //    if (saveData != null)
//    //    {
//    //        // Load the game data and apply it to the game state
//    //        playerLife = saveData.playerLife;
//    //        inventoryItems = saveData.inventoryItems;
//    //        playerPosition = saveData.playerPosition;
//    //        gameProgress = saveData.gameProgress;
//    //        completedPuzzles = saveData.completedPuzzles;

//    //        // Proceed to the game scene
//    //        SceneManager.LoadScene("GameScene");
//    //    }
//    //}
//}



