using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoInput : MonoBehaviour
{
    public float fuerza = 8f;

    private Rigidbody2D rb;
    private Vector2 movimiento;
    private Vector2 posicionInicial;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        posicionInicial = transform.position;
    }

    public void OnMove(InputValue value)
    {
        movimiento = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        rb.AddForce(movimiento * fuerza);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trampa"))
        {
            Reaparecer();
        }
    }

    void Reaparecer()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = posicionInicial;
    }
}