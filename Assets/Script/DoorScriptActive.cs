using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScriptActive : MonoBehaviour
{
    public InteractiveDoor Script;
    void Start()
    {
        Script = GetComponentInChildren<InteractiveDoor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Script.enabled == false)
        {
            Script.enabled = true;
        }
    }
}
