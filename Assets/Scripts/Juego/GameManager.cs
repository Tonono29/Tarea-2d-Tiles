using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton & DDOL
    public static GameManager Instancia { get; private set; }
    private void Awake()
    {
        if (Instancia != null)
        {
            Destroy(gameObject);
        }
        Instancia = this;
        DontDestroyOnLoad(this);
    }
    #endregion
    public bool GameOver { get; private set; }
    public int NivelActual { get; private set; }

    private void Start()
    {
        Datos.Instancia.OnTiempoRestanteActualizado += ComprobarTiempoRestante;
        Datos.Instancia.OnVidasActualizadas += ComrpobarVidas;
        Datos.Instancia.OnGemasActualizadas += ComprobarGemas;
    }

    public void ComprobarTiempoRestante(int tiempoRestante)
    {
        if (tiempoRestante <= 0)
        {
            MostrarResultados(true);
        }
    }

    public void ComrpobarVidas(int vidas, bool decrementadas)
    {
        if (vidas <= 0)
        {
            Audio.Instancia.PlayMuerte();
            MostrarResultados(true);
        }
        else if (decrementadas)
        {
            Audio.Instancia.PlayMuerte();
            ReiniciarNivel();
        }
    }

    public void ComprobarGemas(int gemas)
    {
        if (gemas <= 0)
        {
            MostrarResultados(false);
        }
    }

    public void MostrarMenu()
    {
        SceneManager.LoadScene("Menu");
        Audio.Instancia.PlayIntroduccion();
    }

    private void MostrarResultados(bool gameOver)
    {
        GameOver = gameOver;
        SceneManager.LoadScene("Resultados");
        Audio.Instancia.PlayIntroduccion();
    }

    public void ReiniciarNivel()
    {
        SceneManager.LoadScene(NivelActual);
        Datos.Instancia.EstablecerValores();
        Audio.Instancia.PlayNivel();
    }

    public void Jugar()
    {
        NivelActual = 1;
        SceneManager.LoadScene(NivelActual);
        Datos.Instancia.ReiniciarValores();
        Audio.Instancia.PlayNivel();
    }

    public void MostrarSiguienteNivel()
    {
        SceneManager.LoadScene(++NivelActual);
        Datos.Instancia.EstablecerValores();
        Audio.Instancia.PlayNivel();
    }
    
    public void Salir()
    {
        Application.Quit();
    }

}