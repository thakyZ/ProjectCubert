using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
	public void OnStartButtonDown()
	{
		GameObject.Find("Fade").GetComponent<LevelTransistion>().OnTestLevelTransition(1);
	}

	public void OnExitButtonDown()
	{
		Application.Quit();
	}
}
