using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using System.Dynamic;
using System;


// Controls the tab group of the UI
public class TabGroup : MonoBehaviour
{
    public List<Button> tabButtons;
    public Color tabIdle;
    public Color tabHover;  
    public Color tabActive;
    public Button selectedTab;
    public List<GameObject> objectsToSwap;

    public void Subscribe(Button button) // Subscribes the button to the list if it is not already in said list
    {
        if (tabButtons == null) // Checks if the buttons list is empty to make a new list
        {
            tabButtons = new List<Button>();
        }

        tabButtons.Add(button);
    }

    public void OnTabEnter(Button button) 
    { 
        ResetTabs();
        if (selectedTab == null || button != selectedTab)
        {
            button.ActiveColor = tabHover;
        }
    }

    public void OnTabExit(Button button) 
    {
        ResetTabs();
        button.InactiveColor = tabIdle;
    }

    public void OnTabSelected(Button button)
    {
        selectedTab = button;
        ResetTabs();
        button.ActiveColor = tabActive;
        int index = button.transform.GetSiblingIndex();
        for (int i = 0; i < objectsToSwap.Count; i++)
        {
            if (i==index)
            {
                objectsToSwap[i].SetActive(true);
            }
            else
            {
                objectsToSwap[i].SetActive(false);
            }
        }
    }

    public void ResetTabs()
    {
        foreach(Button button in tabButtons)
        {
            if (selectedTab!=null && button == selectedTab) { continue; }
            button.InactiveColor = tabIdle;
        }
    
    }
}
