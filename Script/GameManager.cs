using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool juegoIniciado;
    public int puntaje;
    public Text textoPuntaje;
    public Text puntajeMaximoTexto;

    public void Awake()
    {
        puntajeMaximoTexto.text = "Mejor Puntaje: " + ObtenerPuntajeMaximo().ToString();
    }
    public void Iniciarjuego()
    {
        juegoIniciado = true;
        FindObjectOfType<Ruta>().IniciarConstruccion();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Iniciarjuego();
        }
    }

    public void FinalizarJuego()
    {
        SceneManager.LoadScene(0);
    }

    public void AumentarPuntaje()
    {
        puntaje++;
        textoPuntaje.text = puntaje.ToString();

        if(puntaje > ObtenerPuntajeMaximo())
        {
            PlayerPrefs.SetInt("PuntajeMaximo", puntaje);
            puntajeMaximoTexto.text = "Mejor Puntaje: " + puntaje.ToString();
        }
    }

    public int ObtenerPuntajeMaximo()
    {
        int i = PlayerPrefs.GetInt("PuntajeMaximo");
        return i;
    }
}
