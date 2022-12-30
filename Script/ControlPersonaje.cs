using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPersonaje : MonoBehaviour
{
    private Rigidbody rb;
    private bool caminarDerecho = true;
    public Transform comienzoRayo;
    private Animator animator;
    private GameManager gameManager;
    public GameObject efectoCristal;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CambiarDireccion();


        }

        RaycastHit contacto;
        
        if(!Physics.Raycast(comienzoRayo.position, -transform.up, out contacto, Mathf.Infinity))
        {
            animator.SetTrigger("Cayendo");
        }

        if(transform.position.y < -2)
        {
            gameManager.FinalizarJuego();
        }
    }

    private void FixedUpdate()
    {
        if (!gameManager.juegoIniciado) 
        {
            return;
        }
        else
        {
            animator.SetTrigger("ComenzoJuego");   
        }
            
            
        rb.transform.position = transform.position + transform.forward * 2 * Time.deltaTime;

        
    }

    private void CambiarDireccion()
    {
        if (!gameManager.juegoIniciado)
        {
            return;
        }

        caminarDerecho = !caminarDerecho;

        if (caminarDerecho)
        {
            transform.rotation = Quaternion.Euler(0, 45, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, -45, 0);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Cristal")
        {
            
            gameManager.AumentarPuntaje();
            GameObject g = Instantiate(efectoCristal, comienzoRayo.transform.position, Quaternion.identity);
            Destroy(g, 2);
            Destroy(other.gameObject);
        }
    }



}

