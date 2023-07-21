using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_Footsteps : MonoBehaviour
{
    public AudioSource[] footsteps;

    public AudioSource[] GroundSound;
    public AudioSource[] GrassSound;
    public AudioSource[] WaterSound;
    public AudioSource[] WoodSound;
    public AudioSource[] CeramicSound;
    public AudioSource[] ConcreteSound;

    public int GroundType;
    public int InitialType;
    private void Start()
    {
        GroundType = InitialType;
    }

    public void Update()
    {
        switch (GroundType)
        {
            case 0:
                footsteps[0] = GroundSound[0];
                footsteps[1] = GroundSound[1];
                footsteps[2] = GroundSound[2];
                footsteps[3] = GroundSound[3];
                footsteps[4] = GroundSound[4];
                break;
            case 1:
                footsteps[0] = GrassSound[0];
                footsteps[1] = GrassSound[1];
                footsteps[2] = GrassSound[2];
                footsteps[3] = GrassSound[3];
                footsteps[4] = GrassSound[4];
                break;
            case 2:
                footsteps[0] = WaterSound[0];
                footsteps[1] = WaterSound[1];
                footsteps[2] = WaterSound[2];
                footsteps[3] = WaterSound[3];
                footsteps[4] = WaterSound[4];
                break;
            case 3:
                footsteps[0] = WoodSound[0];
                footsteps[1] = WoodSound[1];
                footsteps[2] = WoodSound[2];
                footsteps[3] = WoodSound[3];
                footsteps[4] = WoodSound[4];
                break;
            case 4:
                footsteps[0] = CeramicSound[0];
                footsteps[1] = CeramicSound[1];
                footsteps[2] = CeramicSound[2];
                footsteps[3] = CeramicSound[3];
                footsteps[4] = CeramicSound[4];
                break;
            case 5:
                footsteps[0] = ConcreteSound[0];
                footsteps[1] = ConcreteSound[1];
                footsteps[2] = ConcreteSound[2];
                footsteps[3] = ConcreteSound[3];
                footsteps[4] = ConcreteSound[4];
                break;

        }
    }
}
