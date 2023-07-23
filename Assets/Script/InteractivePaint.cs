using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class InteractivePaint : MonoBehaviour
{
    public enum ObjectType { Paint,}
    public ObjectType Paint_;

    [Header("Texto Puerta")]
    [SerializeField] TMP_Text tmpPuerta = null;
    [SerializeField] GameObject tmpPuertaGO = null;
    public bool tieneTexto;
    bool activarTexto;
    public string textoPuerta;
    float time;



    private void Start()
    {
        tmpPuerta = AsignarComponentes.instance.textoPuerta.GetComponent<TMP_Text>();
        tmpPuertaGO = AsignarComponentes.instance.textoPuerta;


    }
    public void Interact()
    {
        switch (Paint_)
        {
            case ObjectType.Paint:
                if (tieneTexto)
                {
                    activarTexto = true;
                }

                break;

            default:
                break;
        }
    }
    private void Update()
    {
        ColocarTextoPuerta();
    }
    public void ColocarTextoPuerta()
    {
        if (activarTexto)
        {
            time += 1 * Time.deltaTime;
            tmpPuertaGO.SetActive(true);
            tmpPuerta.text = textoPuerta;

            if (time > 3.5f)
            {
                tmpPuertaGO.SetActive(false);
                time = 0f;
                activarTexto = false;
            }
        }
    }

}
