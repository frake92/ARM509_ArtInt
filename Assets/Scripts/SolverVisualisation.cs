using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SolverVisualisation : MonoBehaviour
{
    public TextMeshProUGUI applesCount;
    int apples;
    public TextMeshProUGUI pearsCount;
    int pears;
    public TextMeshProUGUI peachesCount;
    int peaches;

    public TextMeshProUGUI applesToGive;
    public TextMeshProUGUI pearsToGive;
    public TextMeshProUGUI peachesToGive;


    public GameObject ZolaBá1;
    public GameObject ZolaBá2;
    public GameObject ZolaBá3;
    public GameObject ZolaBá4;
    int currentIndex = 0;

    public Button nextButton;
    public Button previousButton;

    [HideInInspector]
    public Stack<Node> solution = new Stack<Node>();
    public SolverBase solver = null;
    public List<Node> nodes = new List<Node>();

    public void SolverHelp()
    {
        string chosenSolution = PlayerPrefs.GetString("chosenSolution");

        if (chosenSolution == "BackTrack")
            solver = new GiveGetBacktrack(100, true);
        else if (chosenSolution == "DepthFirst")
            solver = new GiveGetDepthFirst();
        else if (chosenSolution == "BreadthFirst")
            solver = new GiveGetBreadthFirst();
        solution = solver.GetSolution(solver.Search());
        Debug.Log(solution.Count() + " cuuuccli");

        for (int i = 0; i < solution.Count(); i++) 
        {
            nodes.Add(solution.ElementAt(i));
        }

        apples = solution.Peek().State.Apples;
        pears = solution.Peek().State.Pears;
        peaches = solution.Peek().State.Peaches;

        while (solution.Count != 0)
        {
            Debug.Log(solution.Pop().ToString());
        }

        Debug.Log(nodes.Count() + "muuuucli");
        foreach (Node item in nodes)
        {
            Debug.Log(item.ToString());
        }

        Debug.Log("Hogy a rákba kell ToListelni EGY KURVA STACKET");


    }

    public void InitializeValues()
    {
        applesCount.text = apples.ToString();
        pearsCount.text = pears.ToString();
        peachesCount.text = peaches.ToString();
        Debug.Log(apples);
        applesToGive.text = "0";
        pearsToGive.text = "0";
        peachesToGive.text = "0";
    }

    private void Start()
    {
        ZolaBá4.SetActive(false);
        SolverHelp();
        InitializeValues();
        previousButton.interactable = false;
        

    }
    private void Update()
    {
        if (currentIndex == 0)
        {
            previousButton.interactable = false;
        }
        else
        {
            previousButton.interactable = true;
        }

        if (currentIndex == nodes.Count - 1)
        {
            nextButton.interactable = false;
        }
        else
        {
            nextButton.interactable = true;
        }
        if(currentIndex == 46)
        {
            ZolaBá1.SetActive(false);
            ZolaBá2.SetActive(false);
            ZolaBá3.SetActive(false);
            ZolaBá4.SetActive(true);
        }
    }
    public void PreviousStep()
    {
        currentIndex--;
        if (nodes[currentIndex].State.CurrentAction1 == GiveGetAction.GiveApple ||
            nodes[currentIndex].State.CurrentAction2 == GiveGetAction.GiveApple)
            applesToGive.text = "1";
        else
            applesToGive.text = "0";

        if (nodes[currentIndex].State.CurrentAction1 == GiveGetAction.GivePear ||
           nodes[currentIndex].State.CurrentAction2 == GiveGetAction.GivePear)
            pearsToGive.text = "1";
        else
            pearsToGive.text = "0";

        if (nodes[currentIndex].State.CurrentAction1 == GiveGetAction.GivePeach ||
            nodes[currentIndex].State.CurrentAction2 == GiveGetAction.GivePeach)
            peachesToGive.text = "1";
        else
            peachesToGive.text = "0";

        StartCoroutine(WaitSecondsToShowChange());
        if (nodes[currentIndex].State.CurrentAction1 == GiveGetAction.GiveApple &&
                 nodes[currentIndex].State.CurrentAction2 == GiveGetAction.GivePear)
        {
            ZolaBá1.SetActive(false);
            ZolaBá2.SetActive(false);
            ZolaBá3.SetActive(true);
        }
        else if (nodes[currentIndex].State.CurrentAction1 == GiveGetAction.GivePear &&
         nodes[currentIndex].State.CurrentAction2 == GiveGetAction.GiveApple)
        {
            ZolaBá1.SetActive(false);
            ZolaBá2.SetActive(false);
            ZolaBá3.SetActive(true);
        }
        else if (nodes[currentIndex].State.CurrentAction1 == GiveGetAction.GiveApple &&
                 nodes[currentIndex].State.CurrentAction2 == GiveGetAction.GivePeach)
        {
            ZolaBá1.SetActive(false);
            ZolaBá2.SetActive(true);
            ZolaBá3.SetActive(false);
        }
        else if (nodes[currentIndex].State.CurrentAction1 == GiveGetAction.GivePeach &&
         nodes[currentIndex].State.CurrentAction2 == GiveGetAction.GiveApple)
        {
            ZolaBá1.SetActive(false);
            ZolaBá2.SetActive(true);
            ZolaBá3.SetActive(false);
        }
        else if (nodes[currentIndex].State.CurrentAction1 == GiveGetAction.GivePear &&
         nodes[currentIndex].State.CurrentAction2 == GiveGetAction.GivePeach)
        {
            ZolaBá1.SetActive(true);
            ZolaBá2.SetActive(false);
            ZolaBá3.SetActive(false);
        }
        else if (nodes[currentIndex].State.CurrentAction1 == GiveGetAction.GivePeach &&
         nodes[currentIndex].State.CurrentAction2 == GiveGetAction.GivePear)
        {
            ZolaBá1.SetActive(true);
            ZolaBá2.SetActive(false);
            ZolaBá3.SetActive(false);
        }
        apples = nodes[currentIndex].State.Apples;
        pears = nodes[currentIndex].State.Pears;
        peaches = nodes[currentIndex].State.Peaches;

        applesCount.text = apples.ToString();
        pearsCount.text = pears.ToString();
        peachesCount.text = peaches.ToString();
        Debug.Log(currentIndex);


    }
    public void NextStep()
    {
        currentIndex++;

        if (nodes[currentIndex].State.CurrentAction1 == GiveGetAction.GiveApple ||
            nodes[currentIndex].State.CurrentAction2 == GiveGetAction.GiveApple)
            applesToGive.text = "1";
        else
            applesToGive.text = "0";

        if (nodes[currentIndex].State.CurrentAction1 == GiveGetAction.GivePear ||
           nodes[currentIndex].State.CurrentAction2 == GiveGetAction.GivePear)
            pearsToGive.text = "1";
        else
            pearsToGive.text = "0";

        if (nodes[currentIndex].State.CurrentAction1 == GiveGetAction.GivePeach ||
            nodes[currentIndex].State.CurrentAction2 == GiveGetAction.GivePeach)
            peachesToGive.text = "1";
        else
            peachesToGive.text = "0";

        StartCoroutine(WaitSecondsToShowChange());
        if (nodes[currentIndex].State.CurrentAction1 == GiveGetAction.GiveApple &&
                 nodes[currentIndex].State.CurrentAction2 == GiveGetAction.GivePear)
        {
            ZolaBá1.SetActive(false);
            ZolaBá2.SetActive(false);
            ZolaBá3.SetActive(true);
        }
        else if (nodes[currentIndex].State.CurrentAction1 == GiveGetAction.GivePear &&
         nodes[currentIndex].State.CurrentAction2 == GiveGetAction.GiveApple)
        {
            ZolaBá1.SetActive(false);
            ZolaBá2.SetActive(false);
            ZolaBá3.SetActive(true);
        }
        else if (nodes[currentIndex].State.CurrentAction1 == GiveGetAction.GiveApple &&
                 nodes[currentIndex].State.CurrentAction2 == GiveGetAction.GivePeach)
        {
            ZolaBá1.SetActive(false);
            ZolaBá2.SetActive(true);
            ZolaBá3.SetActive(false);
        }
        else if (nodes[currentIndex].State.CurrentAction1 == GiveGetAction.GivePeach &&
         nodes[currentIndex].State.CurrentAction2 == GiveGetAction.GiveApple)
        {
            ZolaBá1.SetActive(false);
            ZolaBá2.SetActive(true);
            ZolaBá3.SetActive(false);
        }
        else if (nodes[currentIndex].State.CurrentAction1 == GiveGetAction.GivePear &&
         nodes[currentIndex].State.CurrentAction2 == GiveGetAction.GivePeach)
        {
            ZolaBá1.SetActive(true);
            ZolaBá2.SetActive(false);
            ZolaBá3.SetActive(false);
        }
        else if (nodes[currentIndex].State.CurrentAction1 == GiveGetAction.GivePeach &&
         nodes[currentIndex].State.CurrentAction2 == GiveGetAction.GivePear)
        {
            ZolaBá1.SetActive(true);
            ZolaBá2.SetActive(false);
            ZolaBá3.SetActive(false);
        }

        apples = nodes[currentIndex].State.Apples;
        pears = nodes[currentIndex].State.Pears;
        peaches = nodes[currentIndex].State.Peaches;

        applesCount.text = apples.ToString();
        pearsCount.text = pears.ToString();
        peachesCount.text = peaches.ToString();

        Debug.Log(currentIndex);


    }
    public void QuitToMain()
    {
        SceneManager.LoadScene("MainScene");
    }
    IEnumerator WaitSecondsToShowChange()
    {
        yield return new WaitForSeconds(5);
    }
}
