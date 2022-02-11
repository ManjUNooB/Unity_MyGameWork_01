using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoLockDoorCS : MonoBehaviour
{
    [Header("ドア開閉キー")]
    [SerializeField] KeyCode doorKey = KeyCode.E;

    [Header("紐付けるオブジェクト")]
    [SerializeField] GameObject playerObj;

    //  音関連
    [Header("SE")]
    [SerializeField] AudioClip lockSE;
    [SerializeField] AudioClip openSE;

    //  フラグ系
    private bool isArea;
    private bool isOpen;

    //その他
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
			if (isArea)
			{
                if(!isOpen)
			    {
                    doorAnimator.SetBool("Open", !doorAnimator.GetBool("Open"));
                    audioSource.PlayOneShot(openSE);
                    isOpen = true;
			    }
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
