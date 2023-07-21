using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaExterior : MonoBehaviour
{
    public float Contador;
    public float ContadorFinal = 600f;
    public int PlayMusic;
    public int MusicNumber;
    public AudioSource[] music;

    public AudioSource MusicaATocar;

    public AudioSource Poste1;
    public AudioSource Poste2;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        #region ControladorMusica
        if(MusicNumber > 2)
        {
            MusicNumber = 0;
        }
        #endregion
        if (PlayMusic == 0)
        {
            Poste1.clip = music[MusicNumber].clip;
            Poste2.clip = music[MusicNumber].clip;
            Poste1.Play();
            Poste2.Play();
            PlayMusic++;
        }

        Contador += 1 * Time.deltaTime;

        if (Contador >= ContadorFinal)
        {
            PlayMusic = Random.Range(0, 2);
            Contador = 0;
            MusicNumber++;
        }
    }

    public void CancionATocar()
    {
        MusicNumber = Random.Range(0, music.Length + 1);
    }
}
