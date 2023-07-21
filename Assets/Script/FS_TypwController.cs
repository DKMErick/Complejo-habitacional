using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FS_TypwController : MonoBehaviour
{
    public int Entry;
    public int Exit;

    SFX_Footsteps footstep;

    private void Start()
    {
        footstep = FindObjectOfType<SFX_Footsteps>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
            footstep.GroundType = Entry;

    }

    private void OnTriggerExit(Collider other)
    {
        footstep.GroundType = Exit;
    }
}
