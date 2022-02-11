using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCS : MonoBehaviour
{
    private KeyCode tutorialKey = KeyCode.T;

    [Header("�`���[�g���A���\���܂ł̎���")]
    [Range(0.0f,10.0f)] float limit;

    [Header("�`���[�g���A����UI")]
    [SerializeField]    private GameObject tutorialUI;

    [SerializeField] AudioClip buttonSE;
    AudioSource audioSource;

    //private float timer;
   

    // Start is called before the first frame update
    void Start()
    {
        //timer = 0.0f;
        audioSource = tutorialUI.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //  ���Ԓ�~�͌�
        //if (tutorialUI.activeSelf)
        //{
        //    Time.timeScale = 0f;
        //}
        //else
        //{
        //    Time.timeScale = 1f;
        //}

        if (Input.GetKeyDown(tutorialKey))
		{
            tutorialUI.SetActive(!tutorialUI.activeSelf);
            audioSource.PlayOneShot(buttonSE);
		}
    }
}
