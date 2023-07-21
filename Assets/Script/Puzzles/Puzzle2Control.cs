using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using AssetsInputController;

public class Puzzle2Control : MonoBehaviour
{
    public GameObject SelectObject;
    private AssetInput _AssetInput;
    public Camera cam;
    public Vector3 mouse;
    InteractiveChess _interactiveChess;
    public float elevacion;
    public float posiciónInicial;

    public float distance;

    public Pedestal pedestal1;
    public Pedestal pedestal2;
    public Pedestal pedestal3;

    public bool PuzzleResuelto;

    void Start()
    {
        _AssetInput = FindObjectOfType<AssetInput>();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        _interactiveChess = GetComponent<InteractiveChess>();
    }

    void Update()
    {
        bool Take = _AssetInput.puzzle;

        mouse = Mouse.current.position.ReadValue();

        #region Puzzle resuelto
        if (pedestal1.Conseguido && pedestal2.Conseguido && pedestal3.Conseguido)
        {
            PuzzleResuelto = true;
        }   
        else
            PuzzleResuelto = false;
        #endregion

        if (Take)
        {
            if(SelectObject == null)
            {
                RaycastHit hit = CastRay();

                if(hit.collider != null)
                {
                    if (hit.collider.CompareTag("Drag"))
                    {
                        Debug.Log("objeto recogible");
                        SelectObject = hit.collider.gameObject;
                        Cursor.visible = false;
                    }
                    else
                    {
                        SelectObject = null;
                    }
                }

            }
            else
            {
                Vector3 position = new Vector3(mouse.x, mouse.y, cam.WorldToScreenPoint(SelectObject.transform.position).z);
                Vector3 worldPosition = cam.ScreenToWorldPoint(position);
                SelectObject.transform.position = new Vector3(worldPosition.x, elevacion, worldPosition.z);
            }
        }

        if(SelectObject != null)
        {
            Vector3 position = new Vector3(mouse.x, mouse.y, cam.WorldToScreenPoint(SelectObject.transform.position).z);
            Vector3 worldPosition = cam.ScreenToWorldPoint(position);
            SelectObject.transform.position = new Vector3(worldPosition.x, posiciónInicial, worldPosition.z);

            SelectObject = null;
            Cursor.visible = true;
        }
    }

    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(
            mouse.x,
            mouse.y,
            cam.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(
            mouse.x,
            mouse.y,
            cam.nearClipPlane);
        Vector3 worldMousePosFar = cam.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = cam.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit, distance);
        Debug.DrawRay(worldMousePosNear, worldMousePosFar - worldMousePosNear, Color.red);

        return hit;
    }

    public void Complete()
    {
        if (PuzzleResuelto)
        {
            _interactiveChess.anim.SetBool("Open", true);
        }
    }
}
