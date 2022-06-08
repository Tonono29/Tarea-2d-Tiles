using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorUI : MonoBehaviour
{
    [SerializeField] Animator jugarAnimator;
    [SerializeField] Animator salirAnimator;
    [SerializeField] Animator creditosAnimator;
    [SerializeField] Animator panelCreditos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BotonCreditos()
    {
        jugarAnimator.SetBool("Oculto", true);
        salirAnimator.SetBool("Oculto", true);
        creditosAnimator.SetBool("Oculto", true);
        panelCreditos.SetBool("Oculto", false);
    }
    public void Quitarpanel()
    {
        jugarAnimator.SetBool("Oculto", false);
        salirAnimator.SetBool("Oculto", false);
        creditosAnimator.SetBool("Oculto", false);
        panelCreditos.SetBool("Oculto", true);
    }
}
