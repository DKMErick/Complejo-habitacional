using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssetsInputController;

public class InteractiveGenerator : MonoBehaviour
{
    public GameObject LightsOn;
    public GameObject LightsOff;

    public GameObject LightSceneOn;
    public GameObject LightSceneOff;

    public AudioSource On;
    public AudioSource Off;

    public AudioSource Loop;

    public bool TimeWait;
    public float Timer;
    public enum ObjetType {GeneratorOn, GeneratorOff}
    public ObjetType lockType;

    AssetInput _AssetInput;


    private void Awake()
    {
        _AssetInput = FindObjectOfType<AssetInput>();
    }

    private void Update()
    {
        if (TimeWait)
        {
            Timer += 1 * Time.deltaTime;
        }

        if(Timer >= 6.5f)
        {
            TimeWait = false;
            Timer = 0;
            Loop.Play();
        }
    }
    public void Interact()
    {
        switch (lockType)
        {
            case ObjetType.GeneratorOn:
                GeneratorOff_();

                break;
            case ObjetType.GeneratorOff:
                GeneratorOn_();
                break;
            default:
                break;
        }
    }
    public void GeneratorOff_()
    {
        LightsOn.SetActive(false);
        LightsOff.SetActive(true);
        On.Stop();
        Loop.Stop();
        Off.Play();
        LightSceneOn.SetActive(false);
        LightSceneOff.SetActive(true);
        lockType = ObjetType.GeneratorOff;
    }
    public void GeneratorOn_()
    {
        LightsOn.SetActive(true);
        LightsOff.SetActive(false);
        TimeWait = true;
        On.Play();
        LightSceneOn.SetActive(true);
        LightSceneOff.SetActive(false);
        lockType = ObjetType.GeneratorOn;
    }
}
