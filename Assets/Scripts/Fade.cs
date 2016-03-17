using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    private Image UIImage;

    public int ToLevel;

    public float FadeSpeed = 0.8f;

    public int DrawDepth = -1000;

    public float Alpha = 1.0f;

    public float FadeDir = -1;

    public float FadeTime = 0;

    void Start()
    {
        UIImage = GetComponent<Image>();
        //UIImage.color = new Color(0, 0, 0, 0);
    }

    void OnGUI()
    {
        Alpha += FadeDir * FadeSpeed * Time.deltaTime;

        Alpha = Mathf.Clamp01(Alpha);

        UIImage.color = new Color(0, 0, 0, Alpha);
    }

    public float BeginFade(int Direction)
    {
        FadeDir = Direction;
        return (FadeSpeed);
    }

    void OnLevelWasLoaded()
    {
        BeginFade(-1);
    }

    IEnumerator ChangeLevel(int level)
    {
        FadeTime = BeginFade(1);
        yield return new WaitForSeconds(FadeTime);
        FadeTime = 0;
        SceneManager.LoadScene(level);
    }

    IEnumerator ResetLevel()
    {
        FadeTime = BeginFade(1);
        yield return new WaitForSeconds(FadeTime);
        FadeTime = 0;
        BeginFade(-1);
    }

    public void FadeToLevel(int level)
    {
        if (level == -1)
        {
            StartCoroutine(ResetLevel());
        }
        else
        {
            StartCoroutine(ChangeLevel(level));
        }
    }

    public void FadeToLevel(string level)
    {
        var levelIndex = SceneManager.GetActiveScene().buildIndex;

        if (level.Contains("+"))
        {
            levelIndex += Convert.ToInt32(level.Substring(1));
        }
        else if (level.Contains("-"))
        {
            levelIndex -= Convert.ToInt32(level.Substring(1));
        }

        StartCoroutine(ChangeLevel(levelIndex));
    }
}
