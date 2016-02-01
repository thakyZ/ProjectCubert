using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelTransistion : MonoBehaviour
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

	IEnumerator ChangeLevel()
	{
		FadeTime = BeginFade(1);
		yield return new WaitForSeconds(FadeTime);
		FadeTime = 0;
		SceneManager.LoadScene(ToLevel);
	}

	public void OnTestLevelTransition(int level)
	{
		ToLevel = level;
		StartCoroutine(ChangeLevel());
	}
}
