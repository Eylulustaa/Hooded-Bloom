using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject LevelPanel, GuidePanel;
    
    public void Begin()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void Level_2()
    {
        SceneManager.LoadScene("Level_2");
    }

    public void Level_3()
    {
        SceneManager.LoadScene("Level_3");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void LevelPanelOpen()
    {
        LevelPanel.SetActive(true);
    }

    public void LevelPanelClose()
    {
        LevelPanel.SetActive(false);
    }

    public void GuideOpen()
    {
        GuidePanel.SetActive(true);
    }

    public void GuideClose()
    {
        GuidePanel.SetActive(false);
    }


}
