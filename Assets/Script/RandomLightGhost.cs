using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLightGhost : MonoBehaviour
{
    private float Timer;
    private float FinalTimer = 0.07f;
    public GameObject Lighting;
    private int SwitchOff;

    public void LightOff()
    {
        Timer += Time.deltaTime;
        if(Timer >= FinalTimer)
        {
            SwitchOff = Random.Range(0, 2);
            Timer = 0;
        }

        switch (SwitchOff)
        {
            case 0:
                Lighting.SetActive(false);
                break;
            case 1:
                Lighting.SetActive(true);
                break;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Ghost")
        {
            LightOff();
        }
    }
}
