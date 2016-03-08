using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using UnityEngine.EventSystems;

public class LevelSelector : MonoBehaviour
{
    public InputField HiddenSecret;

    public string SecretText;

    public int MaxNumberOfLevels = 1;

    public int UnlockedLevels = 0;

    public int Page = 1;

    public List<GameObject> Pages = new List<GameObject>();

    public void Start()
    {
        for (int i = 1; i < MaxNumberOfLevels; i++)
        {
            if (GameObject.Find("Tut" + i))
            {
                GameObject.Find("Tut" + i).GetComponent<Button>().interactable = false;
            }
            if (GameObject.Find("Level" + i) != null)
            {
                GameObject.Find("Level" + i).GetComponent<Button>().interactable = false;
            }
        }

        UnlockedLevels = PlayerPrefs.GetInt("Unlocked");

        for (int i = 1; i < UnlockedLevels + 1; i++)
        {
            if (GameObject.Find("Tut" + i) != null)
            {
                GameObject.Find("Tut" + i).GetComponent<Button>().interactable = true;
            }
            if (UnlockedLevels > 5)
            {
                int j = i - 5;

                if (GameObject.Find("Level" + j) != null)
                {
                    GameObject.Find("Level" + j).GetComponent<Button>().interactable = true;
                }
            }
        }
    }

    public void OnHiddenSubmit()
    {
        if (HiddenSecret.text == SecretText)
        {
            PlayerPrefs.SetInt("Unlocked", MaxNumberOfLevels);
            Start();
            SelectPage(1);
        }
    }

    public void OnGoBack()
    {
        FindObjectOfType<Fade>().FadeToLevel(0);
    }

    public void OnClearData()
    {
        PlayerPrefs.SetInt("Unlocked", 1);
        Start();
        SelectPage(1);
    }

    public void OnSelectLevel(int level)
    {
        FindObjectOfType<Fade>().FadeToLevel(level + 1);
    }

    public void SelectPage(int page)
    {
        for (int i = 0; i < Pages.Count; i++)
        {
            if (Convert.ToInt32(Pages[i].name.Substring(4)) == page)
            {
                Pages[i].SetActive(true);
            }
            else
            {
                Pages[i].SetActive(false);
            }
        }

        Page = page;

        Start();
    }

    public void ForwardPage()
    {
        Page += 1;

        if (Page >= Pages.Count + 1)
        {
            Page = Pages.Count;
        }

        if (Page <= 0)
        {
            Page = 1;
        }

        SelectPage(Page);
    }

    public void BackPage()
    {
        Page -= 1;

        if (Page <= 0)
        {
            Page = 1;
        }

        if (Page >= Pages.Count + 1)
        {
            Page = Pages.Count;
        }

        SelectPage(Page);
    }
}
