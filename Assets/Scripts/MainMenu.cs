using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject ui1;
    public GameObject ui2;
    bool backTrack = false;
    bool depthFirst = false;
    bool breadthFirst = false;

    public void OpenGameDescription()
    {
        ui1.SetActive(true);
        mainMenu.SetActive(false);
    } 
    public void CloseGameDescription()
    {
        ui1.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void OpenGameStory()
    {
        ui2.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void CloseGameStory()
    {
        ui2.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void CloseApplication()
    {
        Application.Quit();
    }

    public void StartFreePlay()
    {
        SceneManager.LoadScene("GameScene");
    }
    
    public void LookForSolution()
    {
        if (backTrack)
        {
            PlayerPrefs.SetString("chosenSolution", "BackTrack");
        }
        else if (depthFirst)
        {
            PlayerPrefs.SetString("chosenSolution", "DepthFirst");
        }
        else if (breadthFirst)
        {
            PlayerPrefs.SetString("chosenSolution", "BreadthFirst");    
        }

        SceneManager.LoadScene("AIScene");
    }

    public void BackTrack()
    {
        backTrack = true;
        depthFirst = false;
        breadthFirst = false;
    }
    public void DepthFirst()
    {
        backTrack = false;
        depthFirst = true;
        breadthFirst = false;
    }
    public void BreadthFirst()
    {
        backTrack = false;
        depthFirst = false;
        breadthFirst = true;
    }
}
