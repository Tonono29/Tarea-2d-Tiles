using System.Collections;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI puntos;
    [SerializeField] private TextMeshProUGUI tiempo;
    [SerializeField] private TextMeshProUGUI vidas;
    [SerializeField] private TextMeshProUGUI gemas;
    [SerializeField] private float retardoAnimacionPuntos = 0.1f;

    private void Start()
    {
        Datos.Instancia.OnTiempoRestanteActualizado += ActualizarTiempoRestante;
        Datos.Instancia.OnPuntosActualizados += ActualizarPuntos;
        Datos.Instancia.OnVidasActualizadas += ActualizarVidas;
        Datos.Instancia.OnGemasActualizadas += ActualizarGemas;
    }

    public void ActualizarPuntos(int puntos, bool establecidos)
    {
        var puntosAnteriores = int.Parse(this.puntos.text);
        if (establecidos)
        {
            this.puntos.SetText($"{puntos:00000}");
        }
        else
        {
            StartCoroutine(AnimarPuntos(puntosAnteriores, puntos));
        }
    }

    private IEnumerator AnimarPuntos(int anteriores, int actuales)
    {
        var incremento = (anteriores < actuales) ? 1 : -1;
        while (anteriores != actuales)
        {
            anteriores += incremento;
            this.puntos.SetText($"{anteriores:00000}");
            yield return new WaitForSeconds(retardoAnimacionPuntos);
        }
    }

    public void ActualizarTiempoRestante(int tiempo)
    {
        this.tiempo.SetText($"{tiempo / 60:00}:{tiempo % 60:00}");
    }
    public void ActualizarVidas(int vidas, bool decrementadas)
    {
        this.vidas.SetText($"{vidas}");
    }

    public void ActualizarGemas(int gemas)
    {
        this.gemas.SetText($"{gemas}");
    }

}