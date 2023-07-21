using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using AssetsInputController;

public class FPSController : MonoBehaviour
{
    private CharacterController _characterController;
    private AssetInput _AssetInput;
    private Vector3 _scalePlayer;
    private Transform _tranformPlayer;
    public GameObject Flashligh;
    public Inventory _inventory;


    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float crouchSpeed;
    [SerializeField] private float crouchHeigh;
    [SerializeField] private float normalHeigh;
    private float gravity = 9.8f;

    public bool FlashlightOn;
    public bool crouch;
    public bool InitialSpawn;
    private Vector2 movement;
    

    [Header("pasos")]
    public bool isMove;
    SFX_Footsteps FootstepsScript;
    public AudioSource[] pasos;
    public int numeroPasos;
    public float contadorPasos;
    public float contMaxWalk;
    public float contMaxCrouch;
    public float contMaxRun;


    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _AssetInput = GetComponent<AssetInput>();
        _scalePlayer = new Vector3(1, 1, 1);
        _tranformPlayer = this.transform;
        FootstepsScript = GetComponent<SFX_Footsteps>();
        _inventory = FindObjectOfType<Inventory>();
    }
    void Start()
    {
        _inventory.AsignarVolume();
    }
    private void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
            
        #region Flashlight controller
        if (_AssetInput.flashlight)
        {
            FlashlightOn = !FlashlightOn;
            _AssetInput.flashlight = false;
        }

        if (FlashlightOn)
            Flashligh.SetActive(true);
        else
            Flashligh.SetActive(false);
        #endregion
        #region tipo de paso
        pasos[0] = FootstepsScript.footsteps[0];
        pasos[1] = FootstepsScript.footsteps[1];
        pasos[2] = FootstepsScript.footsteps[2];
        pasos[3] = FootstepsScript.footsteps[3];
        pasos[4] = FootstepsScript.footsteps[4];
        #endregion
    }
    public void Move()
    {
        Vector3 move = transform.forward * movement.y + transform.right * movement.x;
        move.Normalize();
        move.y -= gravity;

        if(movement.y > 0 || movement.y < 0 || movement.x > 0 || movement.x < 0)
        {
            PasosSound();
        }

        if (_AssetInput.crouch)
        {
            crouch = !crouch;
            _AssetInput.crouch = false;
        }

        float speed = _AssetInput.run ? runSpeed : walkSpeed;

        if (crouch)
        {
            _scalePlayer.y = crouchHeigh;
            _tranformPlayer.localScale = new Vector3(1,_scalePlayer.y,1);
            speed = crouchSpeed;
        }
        else
        {

            _scalePlayer.y = normalHeigh;
            _tranformPlayer.localScale = new Vector3(1, _scalePlayer.y,1);
           
            
        }

        _characterController.Move(move * speed * Time.deltaTime);


    }

    public void PasosSound()
    {
        contadorPasos += Time.deltaTime;

        #region Tipo de suelo

        #endregion

        #region caminando
        if (!crouch)
        {
            if (contadorPasos >= contMaxWalk)
            {
                numeroPasos = Random.Range(0, 5);
                pasos[numeroPasos].Play();
                contadorPasos = 0;
            }
        }

        #endregion

        #region corriendo
        if (_AssetInput.run)
        {
            if (contadorPasos >= contMaxRun)
            {
                numeroPasos = Random.Range(0, numeroPasos + 1);
                pasos[numeroPasos].Play();
                contadorPasos = 0;
            }
        }

        #endregion

        #region agachado
        if (crouch)
        {
            if (contadorPasos >= contMaxCrouch)
            {
                numeroPasos = Random.Range(0, numeroPasos + 1);
                pasos[numeroPasos].Play();
                contadorPasos = 0;
            }
        }

        #endregion
    }


}
