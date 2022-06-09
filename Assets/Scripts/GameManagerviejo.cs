using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerviejo : MonoBehaviour
{
    void Start()
    {
        //datos.Instancia.OnquitarVida += Comprobarvidas;
        //Datos.Instancia.OntiempoActualizado += ComprobarTiempo;
        //Datos.Instancia.OnrecogerGema += ComprobarGemas;
    }

    private void Comprobarvidas (int vidas)
    {
        if (vidas <= 0)
        {
            Debug.Log("Has perdido, te has quedado sin vidas!!!!!");
            ReiniciarNivel();
        }
    }
    private void ComprobarTiempo(int tiempo)
    {
        if (tiempo <= 0)
        {
            Debug.Log("Has perdido, se ha acabado el tiempo!!!!!");
            ReiniciarNivel();
        }
    }
    private void ComprobarGemas(int gemas)
    {
        if (gemas <= 0)
        {
            Debug.Log("Recogidas todas las gemas -> Pasas de nivel.");
            ReiniciarNivel();
        }
    }
    private void ReiniciarNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
