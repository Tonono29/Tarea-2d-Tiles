using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zariguella : Enemigo
{
    [SerializeField] private Vector2 posicionfinal;
    [SerializeField] private float velocidad;
    private Vector2 posicioninicial;
    private Vector2 destino;
    // Start is called before the first frame update
    protected override void Start()
    {
        destino = posicionfinal;
        posicioninicial = transform.position;
        base.Start();
    }
    protected override IEnumerator Mover()
    {
        while (true)
        {
            transform.position = Vector2.MoveTowards(transform.position, destino, velocidad * Time.deltaTime);
            if ((Vector2)transform.position == destino)
            {
                destino = destino == posicioninicial ? posicionfinal : posicioninicial;
                if (destino.x < transform.position.x)
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                }
                else
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                }
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
