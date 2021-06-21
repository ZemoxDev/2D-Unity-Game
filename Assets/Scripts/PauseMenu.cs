using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;

    public Animator resumeAnim;
    public Animator optionsAnim;
    public Animator quitAnim;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        gameIsPaused = false;
        HideMouseCursor();

        resumeAnim.SetTrigger("Normal");
        optionsAnim.SetTrigger("Normal");
        quitAnim.SetTrigger("Normal");
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        gameIsPaused = true;
        ShowMouseCursor();
    }

    void ShowMouseCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void HideMouseCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ResumeButton()
    {
        if(gameIsPaused == true)
        {
            StartCoroutine(ResumeEnumerator());
        }
    }

    public void OptionsButton()
    {
        if(gameIsPaused == true)
        {
            StartCoroutine(OptionsEnumerator());
        }
    }

    public void XButton()
    {
        optionsMenuUI.SetActive(false);

        FindObjectOfType<AudioManager>().Play("UISelectSound");
    }

    public void QuitGameButton()
    {
        if(gameIsPaused == true)
        {
            Debug.Log("Quitting Game");
            Application.Quit();
        }
    }

    IEnumerator ResumeEnumerator()
    {
        yield return new WaitForSeconds(0.6f);

        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        gameIsPaused = false;
        HideMouseCursor();

        resumeAnim.SetTrigger("Normal");
        optionsAnim.SetTrigger("Normal");
        quitAnim.SetTrigger("Normal");
    }

    IEnumerator OptionsEnumerator()
    {
        yield return new WaitForSeconds(0.6f);

        optionsMenuUI.SetActive(true);

        resumeAnim.SetTrigger("Normal");
        optionsAnim.SetTrigger("Normal");
        quitAnim.SetTrigger("Normal");
    }
}
