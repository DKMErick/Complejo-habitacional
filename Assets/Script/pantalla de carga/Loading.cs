using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Loading : MonoBehaviour
{
    public float contador;
    public bool iniciarContador;
    string levelToLoad;
    public Slider Slider;


    private void Start()
    {
        levelToLoad = LevelLoader.nextLevel;
        iniciarContador = true;
    }

    private void Update()
    {
        if (iniciarContador)
        {
            contador += Time.deltaTime;
        }

        if(contador >= 0.5f)
        {
            StartCoroutine(MakeTheLoad(levelToLoad));
            iniciarContador = false;
            contador = 0;
        }
    }

    IEnumerator MakeTheLoad(string level)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(level);

        while (!operation.isDone)
        {
            Debug.Log(operation.progress);
            Slider.value = operation.progress;
            yield return null;
        }

        
    }
}
