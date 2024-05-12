using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Serialization;
using TMPro;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FreePlay : MonoBehaviour
{
    public Button[] addButtons;
    public Button[] removeButtons;
    public TextMeshProUGUI[] fruitsToAdd;
    public TextMeshProUGUI[] fruitsRemaining;
    public GameObject[] ZolaBaInteractions;
    public Button giveToZolaBa;
    int apples = 13;
    int pears = 46;
    int peaches = 59;
    int applesToGive = 0;
    int pearsToGive = 0;
    int peachesToGive = 0;
    int fruitsToGive = 0;
    int counter = 0;
    public void QuitToMain()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void InitializeValues()
    {
        removeButtons[0].interactable = false;
        removeButtons[1].interactable = false;
        removeButtons[2].interactable = false;
        foreach (var item in ZolaBaInteractions)
        {
            item.SetActive(false);
        }
        giveToZolaBa.interactable = false;


    }
    void Start()
    {
        InitializeValues();
    }
    public void AddToZolaBa()
    {
        counter++;
        foreach (var item in ZolaBaInteractions)
        {
            item.SetActive(false);
        }
        if (applesToGive == 1 && pearsToGive == 1)
        {
            ZolaBaInteractions[2].SetActive(true);
            peaches += 2;
        }
        else if (applesToGive == 1 && peachesToGive == 1)
        {
            ZolaBaInteractions[1].SetActive(true);
            pears += 2;
        }
        else if (pearsToGive == 1 && peachesToGive == 1)
        {
            ZolaBaInteractions[0].SetActive(true);
            apples += 2;
        }
       
        foreach (var item in addButtons)
        {
            item.interactable = true;
        }
        foreach (var item in removeButtons)
        {
            item.interactable = false;
        }
        applesToGive = 0;
        pearsToGive = 0;
        peachesToGive = 0;
        fruitsToGive = 0;

    }
    void Update()
    {
        fruitsRemaining[0].text = apples.ToString();
        fruitsRemaining[1].text = pears.ToString();
        fruitsRemaining[2].text = peaches.ToString();

        fruitsToAdd[0].text = applesToGive.ToString();
        fruitsToAdd[1].text = pearsToGive.ToString();
        fruitsToAdd[2].text = peachesToGive.ToString();

        if (fruitsToGive == 2)
        {
            giveToZolaBa.interactable = true;
        }
        else
        {
            giveToZolaBa.interactable = false;
        }
        if(apples == 0)
        {
            addButtons[0].interactable = false;
        }
        if (pears == 0)
        {
            addButtons[1].interactable = false;
        }
        if (peaches == 0)
        {
            addButtons[2].interactable = false;
        }

        if (apples == 0 && peaches == 0)
        {
            foreach (var item in addButtons)
            {
                item.interactable = false;
            }
            foreach (var item in removeButtons)
            {
                item.interactable = false;
            }
            foreach (var item in ZolaBaInteractions)
            {
                item.SetActive(false);
            }
            ZolaBaInteractions[3].SetActive(true);

        }
        else if (apples == 0 && pears == 0)
        {
            foreach (var item in addButtons)
            {
                item.interactable = false;
            }
            foreach (var item in removeButtons)
            {
                item.interactable = false;
            }
            foreach (var item in ZolaBaInteractions)
            {
                item.SetActive(false);
            }
            ZolaBaInteractions[3].SetActive(true);

        }
        else if (pears == 0 && peaches == 0)
        {
            foreach (var item in addButtons)
            {
                item.interactable = false;
            }
            foreach (var item in removeButtons)
            {
                item.interactable = false;
            }
            foreach (var item in ZolaBaInteractions)
            {
                item.SetActive(false);
            }
            ZolaBaInteractions[3].SetActive(true);

        }
    }
    public void AddApple()
    {
        if(applesToGive == 0 && apples != 0)
        {
            applesToGive = 1;
            apples--;
            addButtons[0].interactable = false;
            removeButtons[0].interactable = true;
        }
        fruitsToGive++;

        if(fruitsToGive == 2)
        {
            foreach (var item in addButtons)
            {
                item.interactable = false;
            }
        }
        fruitsToAdd[0].text = applesToGive.ToString();
    }
    public void RemoveApple()
    {
        if(applesToGive == 1)
        {
            applesToGive = 0;
            apples++;
            addButtons[0].interactable = true;
            removeButtons[0].interactable = false;
        }
        if(fruitsToGive == 2)
        {
            if(pearsToGive == 0)
            {
                addButtons[1].interactable = true;
            }
            else if(peachesToGive == 0)
            {
                addButtons[2].interactable = true;
            }
        }
        fruitsToGive--;
        fruitsToAdd[0].text = applesToGive.ToString();
    }

    public void AddPear()
    {
        if (pearsToGive == 0 && pears != 0)
        {
            pearsToGive = 1;
            pears--;
            addButtons[1].interactable = false;
            removeButtons[1].interactable = true;
        }
        fruitsToGive++;
        if (fruitsToGive == 2)
        {
            foreach (var item in addButtons)
            {
                item.interactable = false;
            }
        }
        fruitsToAdd[1].text = pearsToGive.ToString();
    }

    public void RemovePear()
    {
        if (pearsToGive == 1)
        {
            pearsToGive = 0;
            pears++;
            addButtons[1].interactable = true;
            removeButtons[1].interactable = false;
        }
        if (fruitsToGive == 2)
        {
            if (applesToGive == 0)
            {
                addButtons[0].interactable = true;
            }
            else if (peachesToGive == 0)
            {
                addButtons[2].interactable = true;
            }
        }
        fruitsToGive--;
        fruitsToAdd[1].text = pearsToGive.ToString();
    }

    public void AddPeach()
    {
        if (peachesToGive == 0 && peaches!= 0)
        {
            peachesToGive = 1;
            peaches--;
            addButtons[2].interactable = false;
            removeButtons[2].interactable = true;
        }
        fruitsToGive++;
        if (fruitsToGive == 2)
        {
            foreach (var item in addButtons)
            {
                item.interactable = false;
            }
        }
        fruitsToAdd[2].text = peachesToGive.ToString();
    }

    public void RemovePeach()
    {
        if (peachesToGive == 1)
        {
            peachesToGive = 0;
            peaches++;
            addButtons[2].interactable = true;
            removeButtons[2].interactable = false;
        }
        if (fruitsToGive == 2)
        {
            if (applesToGive == 0)
            {
                addButtons[0].interactable = true;
            }
            else if (pearsToGive == 0)
            {
                addButtons[1].interactable = true;
            }
        }
        fruitsToGive--;
        fruitsToAdd[2].text = peachesToGive.ToString();
    }

}
