using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private void Awake()
    {
        var DontDestroyGameObject = FindObjectsOfType<DontDestroy>();
        if(DontDestroyGameObject.Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }


    void Update()
    {
        
    }
}
