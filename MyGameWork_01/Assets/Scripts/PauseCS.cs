using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCS : MonoBehaviour
{
    //  �|�[�Y���ɕ\������UI�̃v���n�u
    [SerializeField] GameObject pauseUIPrefab;
    //  UI�̃C���X�^���X
    private GameObject pauseUIInstance;
    //  �L�[�ݒ�
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
