using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot : MonoBehaviour
{
    public GameObject item;
    public int ID;
    public string Type;
    public string Description;
    public Sprite icon;
    public Texture ImageItem;
    public RawImage ImageDescription;
    public GameObject ItemActive;

    public bool empty;
    public TextMeshProUGUI TextDescription;


    public Transform slotIconGameObject;


    public void UpdateSlot()
    {
        slotIconGameObject.GetComponent<Image>().sprite = icon;
    }

    public void UseItem()
    {

    }

    public void DescriptionItem()
    {
        TextDescription.text = "";
        TextDescription.text = Description;
        ImageDescription.texture = ImageItem;
    }
    
    public void EmptyDescription()
    {
        TextDescription.text = "";
    }
}
