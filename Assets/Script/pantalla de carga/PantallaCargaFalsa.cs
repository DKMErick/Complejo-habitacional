using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PantallaCargaFalsa : MonoBehaviour
{
    public Animator anim;
    public GameObject ScreenCharge;
    public GameObject PanelCharge;
    public Slider slider;
    public float valueSlider;
    public float Timer;
    public bool OnCharge;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

        if (Timer >= 1f)
        {
            valueSlider = Random.Range(0.05f, 0.1f);
            slider.value += valueSlider;
            Timer = 0;
        }

        if (slider.value >= 1)
        {
            slider.value = 0;
            OnCharge = false;
            PanelCharge.SetActive(false);
            FadeOut();
        }

        if (OnCharge)
        {
            Timer += 1 * Time.deltaTime;
            
        }
    }
    public void FadeIn()
    {
        ScreenCharge.SetActive(true);
        anim.SetBool("FadeIn", true);
    }

    public void Screen()
    {
        PanelCharge.SetActive(true);
        OnCharge = true;
    }

    public void FadeOut()
    {
        anim.SetBool("FadeIn", false);
    }

    public void CloseScreen()
    {
        ScreenCharge.SetActive(false);
    }
}
