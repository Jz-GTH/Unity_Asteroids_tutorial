using UnityEngine;
using UnityEngine.SceneManagement;

public class MainOver : MonoBehaviour
{
    public GameObject salirMenu;
    public GameObject Reanudar;

    public void OpenOptionsPanel()
    {
        Reanudar.SetActive(false);
        salirMenu.SetActive(true);

    }
    public void quitGame()
    {
        SceneManager.LoadScene("MainMENU");
    }
    public void PlayGame()


    {
        SceneManager.LoadScene("SampleGame");
    }
}
