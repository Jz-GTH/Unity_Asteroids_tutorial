using UnityEngine;

public class VidasPlayer : MonoBehaviour
{
    public GameObject[] corazoness;
    private int life;

    void Start()
    {
        life = corazoness.Length;
    }

    // Se ejecuta automáticamente cuando algo choca con el Player (si usan Triggers)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Comprobamos si el objeto con el que chocamos es un asteroide
        if (collision.CompareTag("Asteroid"))
        {
            RestarVida();
        }
    }

    /* 
    * Nota: Si tus colliders NO son triggers y usan físicas reales físicas, 
    * borra el método de arriba y descomenta este de abajo:
    *
    * private void OnCollisionEnter2D(Collision2D collision)
    * {
    *     if (collision.gameObject.CompareTag("Asteroide"))
    *     {
    *         RestarVida();
    *     }
    * }
    */

    private void RestarVida()
    {
        // Validamos que aún nos queden vidas para no causar un error en el array
        if (life > 0)
        {
            life--; // Restamos una vida
            corazoness[life].SetActive(false); // Desactivamos el RawImage visualmente
        }

        // Por ahora, como pediste, no hacemos nada más si llega a 0
    }
}