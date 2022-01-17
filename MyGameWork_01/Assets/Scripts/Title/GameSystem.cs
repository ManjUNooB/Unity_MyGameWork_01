using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
	void Update()
	{
		if (Input.GetKey(KeyCode.Escape)) QuitGame();
	}

	//	if Push StartButton GameStart
	public void StartGame()
	{
		SceneManager.LoadScene("MainStage1");
	}

	// if Push Quit Button Quit Game
	public void QuitGame()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
		UnityEngine.Application.Quit();
#endif
	}
}