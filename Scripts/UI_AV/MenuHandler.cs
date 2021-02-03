using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    // Dependancies
    public GameObject pauseMenu;
    public GameObject loseMenu;

    private bool _isPaused;

    private void Start()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (_isPaused)
            {
                _isPaused = false;
                Resume();
            }
            else
            {
                _isPaused = true;
                Pause();
            }
        }
        
    }

    // static??
    public void ActivateLoseMenu()
    {
        loseMenu.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;

    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
    }
    
    public void Restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }    
    public void Quit()
    {
        Application.Quit();
    }

}
