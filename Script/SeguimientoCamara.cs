using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguimientoCamara : MonoBehaviour
{

    public Transform objetivo;
    private Vector3 diferencia;


    // Start is called before the first frame update
    void Awake()
    {

        diferencia = transform.position - objetivo.position;
        
    }

    private void LateUpdate()
    {
        transform.position = objetivo.position + diferencia;
    }


}
