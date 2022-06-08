using System.Collections;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private readonly int estaOculto = Animator.StringToHash("estaOculto");
    [SerializeField] private Animator jugar;
    [SerializeField] private Animator creditos;
    [SerializeField] private Animator salir;
    [SerializeField] private Animator infoCreditos;

    private void Start()
    {
        MostrarBotones();
    }

    private void MostrarBotones()
    {
        jugar.SetBool(estaOculto, false);
        creditos.SetBool(estaOculto, false);
        salir.SetBool(estaOculto, false);
    }

    public void MostrarInfoCreditos()
    {
        OcultarBotones();
        infoCreditos.SetBool(estaOculto, false);
    }

    public void OcultarInfoCreditos()
    {
        MostrarBotones();
        infoCreditos.SetBool(estaOculto, true);
    }

    private void OcultarBotones()
    {
        jugar.SetBool(estaOculto, true);
        creditos.SetBool(estaOculto, true);
        salir.SetBool(estaOculto, true);
    }

    public void Jugar()
    {
        StartCoroutine(OcultarBotonesYJugar());
    }

    public void Salir()
    {
        StartCoroutine(OcultarBotonesYSalir());
    }

    private IEnumerator OcultarBotonesYJugar()
    {
        OcultarBotones();
        yield return new WaitForSeconds(1.0f);
        GameManager.Instancia.Jugar();
    }

    private IEnumerator OcultarBotonesYSalir()
    {
        OcultarBotones();
        yield return new WaitForSeconds(1.0f);
        GameManager.Instancia.Salir();
    }
}