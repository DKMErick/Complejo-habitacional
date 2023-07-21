using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ID;
    public string Type;
    public string Description;
    public Sprite icon;
    public Texture ImageItem;

    [HideInInspector]
    public bool pickedUp;

    [HideInInspector]
    public bool Equiped;

    private void Update()
    {
        if (Equiped)
        {

        }
    }

    public void ItemUsage()
    {
        if(Type == "Key")
        {
            Equiped = true;
        }
    }
}
