using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour
{
    bool gamePaused = false;
    public GameObject Quitbtn;
    public GameObject Resetbtn;
    // Start is called before the first frame update
    void Start()
    {
        Quitbtn.SetActive(gamePaused);
        Resetbtn.SetActive(gamePaused);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void btnpress()
    {
        if (gamePaused)
        {
            resumeGame();
        }
        else
        {
            PauseGame();
        }
    }
    private void PauseGame()
    {
        Debug.Log("PauseGame");
        Time.timeScale = 0f;
        gamePaused = true;
        Quitbtn.SetActive(true);
        Resetbtn.SetActive(true);
    }
    private void resumeGame()
    {
        Debug.Log("PauseGame");
        Time.timeScale = 1f;
        gamePaused = false;
        Quitbtn.SetActive(false);
        Resetbtn.SetActive(false);
    }
    public void quitGame()
    {
        Application.Quit();
    }
    public void reset()
    {
        Debug.Log("PauseGame");
    }
}
