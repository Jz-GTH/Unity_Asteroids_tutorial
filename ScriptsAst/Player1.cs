using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1 : MonoBehaviour
{
    [Header("Ship parameters")]
    [SerializeField] private float shipAcceleration = 10f;
    [SerializeField] private float shipMaxVelocity = 10f;
    [SerializeField] private float shipRotationSpeed = 180f;
    [SerializeField] private float bulletspeed = 8f;

    [Header("Object references")]
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private Rigidbody2D bulletPrefab;
    [SerializeField] private ParticleSystem destroyedParticles;

    private Rigidbody2D shipRigidbody;
    private bool isAlive = true;
    private bool isAccelerating = false;
    public GameObject[] corazoness;
    private int life;



    private void Start()
    {
        life = corazoness.Length;
        // Get a reference to the attached Rigidbody2D.
        shipRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isAlive)
        {
            HandleShipAcceleration();
            HandleShipRotation();
            HandleShooting();
        }

    }

    private void FixedUpdate()
    {
        if (isAlive && isAccelerating)
        {
            // Increase velocity upto a maximum.
            shipRigidbody.AddForce(shipAcceleration * transform.up);
            shipRigidbody.linearVelocity = Vector2.ClampMagnitude(shipRigidbody.linearVelocity, shipMaxVelocity);
        }
    }

    private void HandleShipAcceleration()
    {
        // Are we accelerating?
        isAccelerating = Input.GetKey(KeyCode.UpArrow);
    }

    private void HandleShipRotation()
    {
        // Ship rotation.
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(shipRotationSpeed * Time.deltaTime * transform.forward);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(-shipRotationSpeed * Time.deltaTime * transform.forward);
        }
    }

    private void HandleShooting()
    {
        // Dispara al presionar la barra espaciadora
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody2D bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);

            Vector2 shipVelocity = shipRigidbody.linearVelocity;
            Vector2 shipDireccion = transform.up;
            float shipFowardSpeed = Vector2.Dot(shipVelocity, shipDireccion);

            if (shipFowardSpeed < 0)
            {
                shipFowardSpeed = 0;
            }
            bullet.linearVelocity = shipDireccion * shipFowardSpeed;

            bullet.AddForce(bulletspeed * transform.up, ForceMode2D.Impulse);


        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Asteroid"))
        {
            if (life > 0)
            {
                life--;
                corazoness[life].SetActive(false);
            }

            if (life <= 0)
            {
                SistemaPuntos.ReiniciarPuntos();
                isAlive = false;

                // Creamos las partículas de destrucción antes de cambiar de escena
                if (destroyedParticles != null)
                {
                    Instantiate(destroyedParticles, transform.position, Quaternion.identity);
                }

                // Carga la tercera escena. 
                // Asegúrate de escribir el nombre EXACTAMENTE igual a como se llama tu archivo de escena.
                SceneManager.LoadScene("GameOver");

                // NOTA: Ya no hace falta el Destroy(gameObject) porque cambiar de escena limpia la pantalla.
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
