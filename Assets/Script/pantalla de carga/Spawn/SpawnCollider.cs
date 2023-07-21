using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollider : MonoBehaviour
{
    public SettingSpawnSO _SettingSpawn;

    public enum Transicion { Patio, CasaSchafer, ComplejoHombre}
    public Transicion _Transicion;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            switch (_Transicion)
            {
                case Transicion.Patio:
                    _SettingSpawn.patio = true;
                    _SettingSpawn.casaSchafer = false;
                    _SettingSpawn.complejoHombre = false;

                    break;
                case Transicion.CasaSchafer:
                    _SettingSpawn.patio = false;
                    _SettingSpawn.casaSchafer = true;
                    _SettingSpawn.complejoHombre = false;

                    break;
                case Transicion.ComplejoHombre:
                    _SettingSpawn.patio = false;
                    _SettingSpawn.casaSchafer = false;
                    _SettingSpawn.complejoHombre = true;

                    break;
                default:
                    break;
            }

        }
    }
}
