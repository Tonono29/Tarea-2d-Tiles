using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody2D))]
public class Jugador : MonoBehaviour
{
    private Rigidbody2D rigid;
    [SerializeField] private int velocidad;
    [SerializeField] private int fuerzasalto;
    private Vector2 desplazamientocentro;
    public bool estaenelsuelo;
    private Vector2 movimiento;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.freezeRotation = true;
        var alturajugador = GetComponent<SpriteRenderer>().bounds.size.y;
        desplazamientocentro =new Vector2 (0,alturajugador/2+0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMover(InputValue valor)
    {
        var movimiento2d = valor.Get<Vector2>() * velocidad;
        movimiento= new Vector2(movimiento2d.x, 0);
    }
    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(movimiento.x, rigid.velocity.y);
        RaycastHit2D alcanzado = Physics2D.Raycast((Vector2)transform.position - desplazamientocentro, Vector2.down, 0.01f);
        estaenelsuelo = alcanzado.collider != null;
    }
    private void OnSaltar()
    {
        if(estaenelsuelo)
        {
            rigid.AddForce(Vector2.up * fuerzasalto,ForceMode2D.Impulse);
        }

    }
    private void OnBajar()
    {
        var objetodebajo = Physics2D.Raycast(((Vector2)transform.position - desplazamientocentro), Vector2.down, 0.1f);
        if (objetodebajo&&objetodebajo.collider.name=="PlataformaAtravesable")
        {
            objetodebajo.collider.gameObject.SendMessage("HacerBajable ");
            //objetodebajo.collider.GetComponent<Atravesable>().HacerBajable();
        }
    }
}
