using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssetsInputController;

public class Inventory : MonoBehaviour
{
    public bool inventoryEnabled;

    public GameObject inventory;
    private AssetInput _AssetInput;

    private int AllSlots;
    private int EnabledSlots;
    public GameObject[] slot;
    public GameObject SlotHolder;
    public GameObject PauseMenu;
    public GameObject VolumePause;
    public bool inPause;
    public bool interact;

    public enum ObjectType {bishopDoor, CastleDoor, KingDoor}
    public ObjectType TypeDoor;
    public InteractiveObject Door;
    public Slot slotKey;
    public ComprobacionLlave TakeKey;




    void Start()
    {
        _AssetInput = FindObjectOfType<AssetInput>();
        AllSlots = SlotHolder.transform.childCount;
        

        slot = new GameObject[AllSlots];

        for (int i = 0; i < AllSlots; i++)
        {
            slot[i] = SlotHolder.transform.GetChild(i).gameObject; 
            
            if(slot[i].GetComponent<Slot>().item == null)
            {
                slot[i].GetComponent<Slot>().empty = true;
            }
        }
    }

    
    void Update()
    {
        if(VolumePause == null)
        {
            AsignarVolume();
        }

        if (_AssetInput.pause)
        {
            Cursor.lockState = CursorLockMode.None;
            inPause = true;
            _AssetInput.pause = false;
        }

        if (!interact && !inPause)
        {
            VolumePause.SetActive(false);
            PauseMenu.SetActive(false);
            //Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
        }
        else
        {
            Cursor.visible = true;
            //Cursor.lockState = CursorLockMode.None;
            if (inPause)
            {
                VolumePause.SetActive(true);
                PauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
            if (interact)
            {
                VolumePause.SetActive(true);
                Time.timeScale = 0;
            }
        }

        if (inventoryEnabled)
        {
            inventory.SetActive(true);
        }
        else
        {
            inventory.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            GameObject itemPickedUp = other.gameObject;

            Item item = itemPickedUp.GetComponent<Item>();

            AddItem(itemPickedUp, item.ID, item.Type, item.Description, item.icon, item.ImageItem);
        }
    }

    public void AddItem(GameObject itemObject, int itemID, string itemType, string itemDescription, Sprite itemIcon, Texture imageItem)
    {
        for (int i = 0; i < AllSlots; i++)
        {
            if (slot[i].GetComponent<Slot>().empty)
            {
                itemObject.GetComponent<Item>().pickedUp = true;
                slot[i].GetComponent<Slot>().item = itemObject;
                slot[i].GetComponent<Slot>().ID = itemID;
                slot[i].GetComponent<Slot>().Type = itemType;
                slot[i].GetComponent<Slot>().Description = itemDescription;
                slot[i].GetComponent<Slot>().icon = itemIcon;
                slot[i].GetComponent<Slot>().ImageItem = imageItem;

                itemObject.transform.parent = slot[i].transform;
                itemObject.SetActive(false);

                slot[i].GetComponent<Slot>().UpdateSlot();

                if (itemType == "BishopKey")
                    TakeKey.LLaveArfil = true;
                if (itemType == "CastleKey")
                    TakeKey.LLaveTorre = true;
                if (itemType == "KingKey")
                    TakeKey.LLaveRey = true;

                slot[i].GetComponent<Slot>().ItemActive.SetActive(true);
                slot[i].GetComponent<Slot>().empty = false;
                return;
            }
            
        }
    }

    public void AsignarVolume()
    {
        VolumePause = AsignarComponentes.instance.VolumePause;
    }
}
