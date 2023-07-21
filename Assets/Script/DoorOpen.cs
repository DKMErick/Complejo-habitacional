using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public InteractiveDoor _interactiveDoor;

    public void AnimationOpen()
    {
        _interactiveDoor.ChangeType();
    }
}
