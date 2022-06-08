using UnityEngine;

public class Datos : MonoBehaviour
{
    [SerializeField] private int tiempoNivel = 300;
    [SerializeField] private int vidasIniciales = 3;
    [SerializeField] private int gemasIniciales = 3;
    private float tiempoInicio;
    private int tiempoRestante;
    private int puntos;
    private int vidas;
    private int gemas;

    #region Delegados y Eventos
    public delegate void ManejadorTiempoRestanteActualizado(int tiempo);
    public event ManejadorTiempoRestanteActualizado OnTiempoRestanteActualizado;
    public delegate void ManejadorPuntosActualizados(int puntos, bool establecidos = false);
    public event ManejadorPuntosActualizados OnPuntosActualizados;
    public delegate void ManejadorVidasActualizadas(int vidas, bool decrementadas = true);
    public event ManejadorVidasActualizadas OnVidasActualizadas;
    public delegate void ManejadorGemasActualizadas(int gemas);
    public event ManejadorGemasActualizadas OnGemasActualizadas;
    #endregion

    #region Singleton
    public static Datos Instancia { get; private set; }

    private void Awake()
    {
        if (Instancia != null)
        {
            Destroy(gameObject);
        }
        Instancia = this;
    }
    #endregion

    public void ReiniciarValores()
    {
        EstablecerTiempoInicio();
        vidas = vidasIniciales;
        OnVidasActualizadas?.Invoke(vidas, false);
        puntos = 0;
        OnPuntosActualizados?.Invoke(puntos, true);
        EstablecerGemasIniciales();
    }

    public void EstablecerValores()
    {
        EstablecerTiempoInicio();
        OnVidasActualizadas?.Invoke(vidas, false);
        OnPuntosActualizados?.Invoke(puntos, true);
        EstablecerGemasIniciales();
    }

    private void Update()
    {
        ActualizarTiempoRestante();
    }

    public void ActualizarTiempoRestante()
    {
        var tiempoTranscurrido = Time.time - tiempoInicio;
        tiempoRestante = tiempoNivel - (int)tiempoTranscurrido;
        OnTiempoRestanteActualizado?.Invoke(tiempoRestante);
    }

    private void EstablecerTiempoInicio()
    {
        tiempoInicio = Time.time;
        ActualizarTiempoRestante();
    }

    private void EstablecerGemasIniciales()
    {
        gemas = gemasIniciales;
        OnGemasActualizadas?.Invoke(gemas);
    }

    public void SumarPuntos(int cantidad)
    {
        puntos += cantidad;
        OnPuntosActualizados?.Invoke(puntos);
    }

    public int GetPuntos()
    {
        return puntos;
    }

    public int GetRecord()
    {
        var record = PlayerPrefs.GetInt("Puntos", 0);
        if (puntos > record)
        {
            PlayerPrefs.SetInt("Puntos", puntos);
        }
        return record;
    }

    public void DecrementarVidas()
    {
        vidas--;
        OnVidasActualizadas?.Invoke(vidas);
    }
    public void SumarVida()
    {
        vidas++;
        OnVidasActualizadas?.Invoke(vidas);
    }

    public void DecrementarGemas()
    {
        gemas--;
        OnGemasActualizadas?.Invoke(gemas);
    }

}