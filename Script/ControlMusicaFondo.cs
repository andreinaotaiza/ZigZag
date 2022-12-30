using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMusicaFondo : MonoBehaviour
{
    public static ControlMusicaFondo instancia;
    
    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
        else if(instancia != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
        
}

