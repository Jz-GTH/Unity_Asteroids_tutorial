using UnityEngine;

public class Ateroid : MonoBehaviour
{
    [SerializeField] private ParticleSystem destroyedParticles;
    public int size = 3;
    public GameManager gameManager;

    private void Start()
    {
        transform.localScale = 0.5f * size * Vector3.one;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(Random.value , Random.value).normalized;
        float spawnSpeed = Random.Range(4f - size, 7f - size);
        rb.AddForce(direction * spawnSpeed, ForceMode2D.Impulse);

        gameManager.asteroidCount++;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            SistemaPuntos.SumarPuntos(10);

            gameManager.asteroidCount--;

            Destroy(collision.gameObject);


            if (size > 1)
            {
                for (int i = 0; i < 2; i++)
                {
                    Ateroid newAsteroid = Instantiate(this, transform.position, Quaternion.identity);
                    newAsteroid.size = size - 1;
                    newAsteroid.gameManager = gameManager;
                }
                

            }
            Instantiate(destroyedParticles, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
