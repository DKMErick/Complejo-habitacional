using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float sensitivity = 100f;
    private Transform player;
    private Vector2 look;

    [SerializeField] private float minAngle = -60f;
    [SerializeField] private float maxAngle = 60f;
    private float currentAngle = 0f;

    private void Awake()
    {
        player = transform.parent;
    }

    private void OnLook(InputValue value)
    {
        look = value.Get<Vector2>();
    }
    private void Update()
    {
        float mouseX = look.x * sensitivity * Time.deltaTime;
        float mouseY = look.y * sensitivity * Time.deltaTime;

        player.Rotate(Vector3.up * mouseX);

        currentAngle -= mouseY;
        currentAngle = Mathf.Clamp(currentAngle, minAngle, maxAngle);

        //transform.Rotate(Vector3.left * mouseY);
        transform.localEulerAngles = new Vector3(currentAngle, transform.localEulerAngles.y, 0);

        
    }
    private void OnDestroy()
    {
        Cursor.lockState = CursorLockMode.None;
    }

}
