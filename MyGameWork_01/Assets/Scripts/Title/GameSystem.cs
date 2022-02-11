using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
	[Header("次のシーン")]
	[SerializeField] string sceneName;

	//	音関連
	[SerializeField] AudioClip buttonSE;

	[Header("FadeCanvas")]
	[SerializeField] Fade fade;

	private bool buttonFlag;
	private AudioSource audioSource;

	private void Start()
	{
		//	カーソルを自由に
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
		buttonFlag = false;
		audioSource = this.GetComponent<AudioSource>();
		fade.StartFade = true;
		fade.FadeOut(1f);	//	フェードの設定
	}

	void Update()
	{
		if (!buttonFlag)
		{
			if (Input.GetKey(KeyCode.Escape))
			{
				buttonFlag = true;
				audioSource.PlayOneShot(buttonSE);
				QuitGame();
			}
		}
	}

	//	if Push StartButton GameStart
	public void StartGame()
	{
		if (!buttonFlag)
		{
			audioSource.PlayOneShot(buttonSE);
			buttonFlag = true;
		}

		//	トランジション掛けてシーン遷移する
		fade.FadeIn(1f, () =>
		 {
			 StartCoroutine("SceneChange");

		 });
		
	}

	// if Push Quit Button Quit Game
	public void QuitGame()
	{
		if (!buttonFlag)
		{
			audioSource.PlayOneShot(buttonSE);
			buttonFlag = true;
			
		}
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
		UnityEngine.Application.Quit();
#endif
	}

	//	if Push Return Title Button
	public void ReturnTitle()
	{
		if (!buttonFlag)
		{
			audioSource.PlayOneShot(buttonSE);
			buttonFlag = true;
		}

		//	トランジション掛けてシーン遷移する
		fade.FadeIn(1f, () =>
		{
			StartCoroutine("SceneChange");

		});
	}


	IEnumerator SceneChange()
	{
		yield return new WaitForSeconds(0.8f);
		SceneManager.LoadScene(sceneName);

	}


}