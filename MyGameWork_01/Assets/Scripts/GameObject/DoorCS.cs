using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCS : MonoBehaviour
{
    [Header("�h�A�J�L�[")]
    public KeyCode DoorOpen = KeyCode.E;      

    //  �R�t����I�u�W�F�N�g
    [SerializeField] GameObject playerObj;
    [SerializeField] GameObject keymanagerObj;

    //  ���֘A
    [Header("SE")]
    [SerializeField] AudioClip lockSE;
    [SerializeField] AudioClip openSE;
    KeyManagerCS keymanagerScript;

    //  �t���O�n
    private bool isArea;
    private bool hasKey;
    private bool isOpen;

    //  ���̑�
    private Animator doorAnimator;
    private AudioSource audioSource;

    private float timer;
    [Header("SE�C���^�[�o��")]
    [Range(0.0f, 10.0f)]
    [SerializeField]float intervalSE = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        isArea = false;
        timer = intervalSE;
        doorAnimator = transform.parent.GetComponent<Animator>();
        keymanagerScript = keymanagerObj.GetComponent<KeyManagerCS>();
        audioSource = this.gameObject.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if (isArea)
        {
            if (Input.GetKeyDown(DoorOpen))
            {
                if (hasKey = keymanagerScript.KeyFlag)
                {
                    doorAnimator.SetBool("Open", !doorAnimator.GetBool("Open"));
                    if (!isOpen)
                    {
                        audioSource.PlayOneShot(openSE);
                        isOpen = true;
                    }
                }
                else
                {
                    if (timer >= intervalSE)
                    {
                        audioSource.PlayOneShot(lockSE);
                        timer = 0.0f;
                    }
                }

            }
        }

    }
        /*
		if (Input.GetKeyDown(DoorOpen) && isArea)
		{
			time += Time.deltaTime;
			if (hasKey = keymanagerScript.KeyFlag)
			{
				doorAnimator.SetBool("Open", !doorAnimator.GetBool("Open"));
				if (!isOpen)
				{
					audioSource.PlayOneShot(openSE);
					isOpen = true;
				}
			}
			else
			{
				if (time >= 1.0f)
				{
					audioSource.PlayOneShot(lockSE);
					time = 0.0f;
				}
			}

		}
	

        */
	void OnTriggerEnter(Collider col)
	{
        if (col.tag == "Player") isArea = true;
        Debug.Log("isArea:");
        Debug.Log(isArea);
        Debug.Log("hasKey:");
        Debug.Log(hasKey);
	}

	void OnTriggerExit(Collider col)
	{
        if (col.tag == "Player") isArea = false;
        Debug.Log("isArea:");
        Debug.Log(isArea);
        Debug.Log("hasKey:");
        Debug.Log(hasKey);
    }
}
