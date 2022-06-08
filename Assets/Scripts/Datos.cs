using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public delegate void ManejadorTiempoActualizado(int tiempo);
public delegate void ManejadorSumarpuntos(int cantidad);
public delegate void ManejadorQuitarvida(int vidas);
public delegate void ManejadorRecogerGema(int gemas);


public class Datos : MonoBehaviour
{
    public static Datos Instancia { get; private set;}
    private int puntos;
    [SerializeField] private int vidas = 3;
    [SerializeField] private TextMeshProUGUI textovida;
    [SerializeField] private int tiempoNivel;
    [SerializeField] private int gemas = 9;
    [SerializeField] private TextMeshProUGUI textoGemas;
    private float tiempoInicio;
    #region eventos
    public event ManejadorTiempoActualizado OntiempoActualizado;
    public event ManejadorSumarpuntos Onsumarpuntos;
    public event ManejadorQuitarvida OnquitarVida;
    public event ManejadorRecogerGema OnrecogerGema;
    #endregion
    private void Awake()
    {
        if (Instancia=null)
        {
            Destroy(gameObject);
        }
        Instancia = this;
    }
    private void Start()
    {
        tiempoInicio = Time.time;
    }
    private void Update()
    {
        ComprobarTiempo();
        textoGemas.text = gemas.ToString();
        textovida.text = vidas.ToString();
    }
    public void SumarPuntos(int cantidad)
    {
        puntos += cantidad;
        Onsumarpuntos?.Invoke(puntos);

    }
    public void QuitarVida()
    {
        vidas--;
        OnquitarVida?.Invoke(vidas);
    }
    public void RecogerGema()
    {
        gemas--;
        OnrecogerGema?.Invoke(gemas);;
    }
    private void ComprobarTiempo()
    {
        var tiempo = Time.time - tiempoInicio;
        var tiempoRestante = tiempoNivel - (int)tiempo;
        OntiempoActualizado?.Invoke(tiempoRestante);
    }
    public void SumarVida()
    {
        vidas++;
    }
}
