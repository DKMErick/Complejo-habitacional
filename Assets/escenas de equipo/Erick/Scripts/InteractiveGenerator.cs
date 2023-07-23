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
    sonidoGen _sonidoGen;

    public GameObject LoopSound;

    public bool TimeWait;
    public float Timer;

    public GameObject KeyOn;
    public GameObject KeyOff;
    public GameObject SoundOffTheme;
    public GameObject ScreamersLucesApagadas;
    public GameObject ScreamersLucesEncendidas;
    public enum ObjetType {GeneratorOn, GeneratorOff}
    public ObjetType lockType;

    AssetInput _AssetInput;


    private void Awake()
    {
        _AssetInput = FindObjectOfType<AssetInput>();
        _sonidoGen = GetComponentInChildren<sonidoGen>();
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

        if (lockType == ObjetType.GeneratorOn)
        {
            LoopSound.SetActive(true);
            KeyOn.SetActive(true);
            KeyOff.SetActive(false);
            SoundOffTheme.SetActive(false);
            ScreamersLucesApagadas.SetActive(false);
            ScreamersLucesEncendidas.SetActive(true);
        }
        else if(lockType == ObjetType.GeneratorOff)
        {
            LoopSound.SetActive(false);
            KeyOn.SetActive(false);
            KeyOff.SetActive(true);
            SoundOffTheme.SetActive(true);
            ScreamersLucesApagadas.SetActive(true);
            ScreamersLucesEncendidas.SetActive(false);
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

    public void Entry()
    {
        if(lockType == ObjetType.GeneratorOn)
        {
            Loop.Play();
        }
    }
}
