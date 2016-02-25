using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public void Start()
    {
        for (int i = 1; i < 21; i++)
        {
            GameObject.Find("Level" + i).GetComponent<Button>().interactable = false;
        }

        int unlocked = PlayerPrefs.GetInt("Unlocked");

        for (int i = 1; i < unlocked + 2; i++)
        {
            GameObject.Find("Level" + i).GetComponent<Button>().interactable = true;
        }
    }

    public void OnGoBack()
    {
        FindObjectOfType<Fade>().FadeToLevel(0);
    }

    public void OnClearData()
    {
        PlayerPrefs.DeleteKey("Unlocked");
        FindObjectOfType<Fade>().FadeToLevel(-1);
    }

    public void OnSelectLevel(int level)
    {
        FindObjectOfType<Fade>().FadeToLevel(level + 1);
    }
}
