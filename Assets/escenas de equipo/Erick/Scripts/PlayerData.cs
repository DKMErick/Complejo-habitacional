using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float life;
    public string[] inventory;
    public Vector3 position;
    public float progressPercentage;
    public bool[] completedPuzzles;
}
