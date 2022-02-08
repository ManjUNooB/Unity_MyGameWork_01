using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCS : MonoBehaviour
{
    private KeyCode tutorialKey = KeyCode.T;

    [Header("チュートリアル表示までの時間")]
    [Range(0.0f,10.0f)] float limit;

    [Header("チュートリアルのUI")]
    [SerializeField]    private GameObject tutorialUI;

    private float timer;
   

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > limit)
		{
			if (!tutorialUI.activeSelf)
			{

			}
		}

		if (Input.GetKeyDown(tutorialKey))
		{
            tutorialUI.SetActive(!tutorialUI.activeSelf);

			if (tutorialUI)
			{
                Time.timeScale = 0f;
			}
			else
			{
                Time.timeScale = 1f;
			}
		}
    }
}
