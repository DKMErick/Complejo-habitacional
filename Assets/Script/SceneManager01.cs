using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Key manager", menuName = "Key Manager")]
public class SceneManager01 : ScriptableObject
{
    public bool LlaveRey;
    public bool LlaveAlfil;
    public bool LlaveTorre;
    public bool LlaveGenerador;

    public bool PiezaAlfil;
    public bool PiezaReina;
    public bool PiezaCaballo;

    public bool GeneratorOn = true;
}
