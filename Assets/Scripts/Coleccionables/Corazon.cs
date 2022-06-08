using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corazon : Coleccionable
{
    protected override void Recoger()
    {
        Datos.Instancia.SumarVida();
    }
}
