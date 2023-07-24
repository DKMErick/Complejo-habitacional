using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador_candado : MonoBehaviour
{
    public Transform Rueda1;
    public Transform Rueda2;
    public Transform Rueda3;

    public int digito1;
    public int digito2;
    public int digito3;

    private int digitoCorrecto1 = 5;
    private int digitoCorrecto2 = 2;
    private int digitoCorrecto3 = 2
        ;

    public bool numero1;
    public bool numero2;
    public bool numero3;

    public bool candadoAbierto;

    public float rotacionY_1;
    public float rotacionY_2;
    public float rotacionY_3;

    public Animator anim;
    public InteractiveKey KeyControl;


    void Update()
    {
        #region limitador digitos
        if (digito1 > 9)
        {
            digito1 = 0;
        }
        if (digito2 > 9)
        {
            digito2 = 0;
        }
        if (digito3 > 9)
        {
            digito3 = 0;
        }
        #endregion

        claveCorrecta();
    }

    public void claveCorrecta()
    {
        #region digitos
        if (digito1 == digitoCorrecto1)
        {
            numero1 = true;
        }
        else
        {
            numero1 = false;
        }

        if (digito2 == digitoCorrecto2)
        {
            numero2 = true;
        }
        else
        {
            numero2 = false;
        }

        if (digito3 == digitoCorrecto3)
        {
            numero3 = true;
        }
        else
        {
            numero3 = false;
        }
        #endregion

        if (numero1 && numero2 && numero3)
        {
            candadoAbierto = true;
        }
        else
        {
            candadoAbierto = false;
        }

        if (candadoAbierto)
        {
            anim.SetBool("open", true);
        }
        else
        {
            anim.SetBool("open", false);
        }
    }

    public void Digitador1()
    {
        rotacionY_1 += 36f;
        Rueda1.localRotation = Quaternion.Euler(Rueda1.rotation.x, rotacionY_1, Rueda1.rotation.z);
        digito1++;
    }

    public void Digitador2()
    {
        rotacionY_2 += 36f;
        Rueda2.localRotation = Quaternion.Euler(Rueda2.rotation.x, rotacionY_2, Rueda2.rotation.z);
        digito2++;
    }

    public void Digitador3()
    {
        rotacionY_3 += 36f;
        Rueda3.localRotation = Quaternion.Euler(Rueda3.rotation.x, rotacionY_3, Rueda3.rotation.z);
        digito3++;
    }
}
