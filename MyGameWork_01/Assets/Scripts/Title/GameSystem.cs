using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
	[SerializeField] string sceneName;

	void Update()
	{
		if (Input.GetKey(KeyCode.Escape)) QuitGame();
	}

	//	if Push StartButton GameStart
	public void StartGame()
	{
		SceneManager.LoadScene(sceneName);
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