using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Ateroid AteroidPrefab;
    public int asteroidCount = 0;
    private int level = 0;

    private void Update()
    {
        if (asteroidCount == 0)
        {
            level++;

            int numAsteroids = 2 + (2 + level);
            for (int i = 0; i < numAsteroids; i++)
            {
                spawAsteroids();
            }

        }
    }

    private void spawAsteroids()
    {
        float offset = Random.Range(0f, 1f);
        Vector2 viewportSpawnPoints = Vector2.zero;

        int edge = Random.Range(0, 4);
        if (edge == 0)
        {
            viewportSpawnPoints = new Vector2(offset, 0);
        }
        else if (edge == 1)
        {
            viewportSpawnPoints = new Vector2(offset, 1);
        }
        else if (edge == 2)
        {
            viewportSpawnPoints = new Vector2(0, offset);
        }
        else if (edge == 3)
        {
            viewportSpawnPoints = new Vector2(1, offset);
        }

        Vector2 worldSpawnPoints = Camera.main.ViewportToWorldPoint(viewportSpawnPoints);
        Ateroid asteroid = Instantiate(AteroidPrefab, worldSpawnPoints, Quaternion.identity);
        asteroid.gameManager = this;
    }
    public void GameOver()
    {
        StartCoroutine(Restart());
    }
    private IEnumerator Restart()
    {
        Debug.Log("Game over");

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        yield return null;


    }
}
