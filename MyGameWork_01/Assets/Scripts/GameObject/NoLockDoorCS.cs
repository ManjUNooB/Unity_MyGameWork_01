using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoLockDoorCS : MonoBehaviour
{
    [Header("�h�A�J�L�[")]
    [SerializeField] KeyCode doorKey = KeyCode.E;

    [Header("�R�t����I�u�W�F�N�g")]
    [SerializeField] GameObject playerObj;

    //  ���֘A
    [Header("SE")]
    [SerializeField] AudioClip lockSE;
    [SerializeField] AudioClip openSE;

    //  �t���O�n
    private bool isArea;
    private bool isOpen;

    //���̑�
    private Animator doorAnimator;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        isArea = false;
        doorAnimator = transform.parent.GetComponent<Animator>();
        audioSource = this.gameObject.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(doorKey))
		{
            if(!isOpen)
			{
                doorAnimator.SetBool("Open", !doorAnimator.GetBool("Open"));
                audioSource.PlayOneShot(openSE);
                isOpen = true;
			}
            
		}
    }

	private void OnTriggerEnter(Collider other)
	{
        if (other.tag == "Player") isArea = true;
        Debug.Log("isArea:");
        Debug.Log(isArea);
    }

	private void OnTriggerExit(Collider other)
	{
        if (other.tag == "Player") isArea = false;
        Debug.Log("isArea:");
        Debug.Log(isArea);
    }
}
