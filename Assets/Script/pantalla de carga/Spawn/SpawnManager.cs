using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    public SettingSpawnSO _SettingSpawnSO;

    public Transform spawnPlayer;
    string spawnInicial = "SpawnInicial";
    string spawnPatio = "SpawnDesdePatio";
    string spawnCasaSchafer = "SpawnDesdeCasa";
    string spawnPuertaComplejoHombre = "SpawnDesdeComplejo";


    private void Awake()
    {
        #region Singletone
        // esto basicamente te permite llamar este script desde cualquier otro sin necesidad de referenciarlo
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        #endregion

        #region Controlador del Spawn

        // esto verifica de donde viene preguntando que bool esta activo en el scriptableObject y asigna el spawn correspondiente buscandolo en la escena
        if (_SettingSpawnSO.patio)
        {
            spawnPlayer = GameObject.Find(spawnPatio).transform;
        }
        else if(_SettingSpawnSO.casaSchafer)
        {
            spawnPlayer = GameObject.Find(spawnCasaSchafer).transform;
        }
        else if (_SettingSpawnSO.complejoHombre)
        {
            spawnPlayer = GameObject.Find(spawnPuertaComplejoHombre).transform;
        }
        else
        {
            spawnPlayer = GameObject.Find(spawnInicial).transform;
        }

        #endregion

    }

}
