using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssetsInputController;

public class Selected : MonoBehaviour
{
    AssetInput _assetInput;
    LayerMask mask;
    public float distance = 1.5f;
    public GameObject click = null;

    void Start()
    {
        mask = LayerMask.GetMask("Raycast Detect");
        _assetInput = GetComponent<AssetInput>();
    }

    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance, mask))
        {
            if (hit.collider.tag == "InteractiveDoor")
            {
                click = hit.transform.GetComponent<Asignar>().click;
                click.SetActive(true);

                if (_assetInput.interactuar)
                {
                    hit.transform.GetComponent<InteractiveDoor>().Interact();
                    _assetInput.interactuar = false;
                }
            }
            if (hit.collider.tag == "Puzzle")
            {
                click = hit.transform.GetComponent<Asignar>().click;
                click.SetActive(true);

                if (_assetInput.interactuar)
                {
                    hit.transform.GetComponent<InteractiveKey>().Interact();
                    _assetInput.interactuar = false;
                }
            }
            if (hit.collider.tag == "InteractiveDocument")
            {
                click = hit.transform.GetComponent<Asignar>().click;
                click.SetActive(true);

                if (_assetInput.interactuar)
                {
                    hit.transform.GetComponent<InteractiveDocument>().Interact();
                    _assetInput.interactuar = false;
                }
            }
            if (hit.collider.tag == "Item")
            {
                click = hit.transform.GetComponent<Asignar>().click;
                click.SetActive(true);

                if (_assetInput.interactuar)
                {
                    hit.transform.GetComponent<InteractiveItem>().Interact();
                    _assetInput.interactuar = false;
                }
            }
            if (hit.collider.tag == "Chess")
            {
                click = hit.transform.GetComponent<Asignar>().click;
                click.SetActive(true);

                if (_assetInput.interactuar)
                {
                    hit.transform.GetComponent<ChessInteractive>().Interact();
                    _assetInput.interactuar = false;
                }
            }
            if (hit.collider.tag == "Paint")
            {
                click = hit.transform.GetComponent<Asignar>().click;
                click.SetActive(true);

                if (_assetInput.interactuar)
                {
                    hit.transform.GetComponent<InteractivePaint>().Interact();
                    _assetInput.interactuar = false;
                }
            }
            if (hit.collider.tag == "Generador")
            {
                click = hit.transform.GetComponent<Asignar>().click;
                click.SetActive(true);

                if (_assetInput.interactuar)
                {
                    hit.transform.GetComponent<InteractiveGenerator>().Interact();
                    _assetInput.interactuar = false;
                }
            }
        }
        else
        {
            click.SetActive(false);
        }
    }
    
}
