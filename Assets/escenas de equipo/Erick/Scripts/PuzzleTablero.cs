using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using AssetsInputController;

public class PuzzleTablero : MonoBehaviour
{
    public GameObject SelectObject;
    private AssetInput _AssetInput;
    public Camera cam;
    public Vector3 mouse;
    public Animator anim;
    public float elevacion;

    public float TimeActive;
    public float FinalTime = 1f;

    public float distance;

    public Pedestal pedestal1;
    public Pedestal pedestal2;
    public Pedestal pedestal3;

    public bool PuzzleResuelto;

    void Start()
    {
        _AssetInput = FindObjectOfType<AssetInput>();
        anim = GetComponentInParent<Animator>();
    }

    void Update()
    {
        bool Take = _AssetInput.puzzle;

        mouse = Mouse.current.position.ReadValue();

        #region Puzzle resuelto
        if (pedestal1.Conseguido && pedestal2.Conseguido && pedestal3.Conseguido)
            PuzzleResuelto = true;
        else
        {
            PuzzleResuelto = false;
            TimeActive = 0;
        }
            

        if (PuzzleResuelto && !Take)
        {
            TimeActive += 1 * Time.deltaTime;
        }
        if(TimeActive >= FinalTime)
        {
            Complete();
        }
        #endregion

        RaycastHit hit = CastRay();

        if (hit.collider.CompareTag("Drag"))
        {
            Debug.Log("objeto recogible");
            SelectObject = hit.collider.gameObject;
            Cursor.visible = false;
        }

        if (Take)
        {
            Vector3 position = new Vector3(mouse.x, mouse.y, cam.WorldToScreenPoint(SelectObject.transform.position).z);
            Vector3 worldPosition = cam.ScreenToWorldPoint(position);
            SelectObject.transform.position = new Vector3(worldPosition.x, SelectObject.transform.position.y + elevacion, worldPosition.z);
        }

        if (!Take)
        {
            //SelectObject.transform.position = new Vector3(SelectObject.transform.position.x, SelectObject.transform.position.y, SelectObject.transform.position.z);

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
            anim.SetBool("Open", true);
        }
    }
}