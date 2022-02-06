using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCS : MonoBehaviour
{
    //  ポーズ時に表示するUIのプレハブ
    [SerializeField] GameObject pauseUIPrefab;
    //  UIのインスタンス
    private GameObject pauseUIInstance;
    //  キー設定
    [SerializeField] KeyCode pauseKey;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(pauseKey))
		{
            if(pauseUIInstance == null)
			{
                pauseUIInstance = GameObject.Instantiate(pauseUIPrefab) as GameObject;
                Time.timeScale = 0f;
			}
			else
			{
                Destroy(pauseUIInstance);
                Time.timeScale = 1f;
			}
		}
    }
}
