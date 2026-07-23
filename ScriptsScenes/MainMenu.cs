using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject salirMenu;
    public GameObject MainMenu;

    public void OpenOptionsPanel()
    {
        MainMenu.SetActive(false);
        salirMenu.SetActive(true);
    
    }
    public void quitGame()
    {
        Application.Quit();
    }
    public void PlayGame()

    
    {
        SceneManager.LoadScene("SampleGame");
    }
}
