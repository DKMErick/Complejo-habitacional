using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silla : MonoBehaviour
{
    AudioSource Sonido;
    Animator Anim;

    private void Start()
    {
        Sonido = GetComponent<AudioSource>();
        Anim = GetComponent<Animator>();
    }

    public void PlaySound()
    {
        Sonido.Play();
    }

    public void AnimationScreamer()
    {
        Anim.SetBool("Active", true);
    }




}
