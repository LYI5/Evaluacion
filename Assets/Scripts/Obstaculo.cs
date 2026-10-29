using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    public float velocidad = 4f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        float angulo = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        Vector2 direccion = new Vector2(Mathf.Cos(angulo), Mathf.Sin(angulo));
        rb.linearVelocity = direccion * velocidad;
    }

    void FixedUpdate()
    {
        if (rb.linearVelocity.sqrMagnitude > 0.0001f)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * velocidad;
        }
    }
}