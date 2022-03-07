using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingDoorCS : MonoBehaviour
{
	[Header("ドア開閉キー")]
	public KeyCode DoorOpen = KeyCode.E;

	//  紐付けるオブジェクト
	[SerializeField] GameObject playerObj;

	//  音関連
	[Header("SE")]
	[SerializeField] AudioClip lockSE;
	[SerializeField] AudioClip unlockSE;
	[SerializeField] AudioClip openSE;

	//  フラグ系
	private bool isArea;
	private bool isLock;
	private bool isOpen;

	//  その他
	private Animator doorAnimator;
	private AudioSource audioSource;

	//	連続SE防止
	private float timer;
	[Header("SEインターバル")]
	[Range(0.0f, 10.0f)]
	[SerializeField] float intervalSE = 1.0f;


	// Start is called before the first frame update
	void Start()
	{
		isArea = false;
		isLock = true;
		timer = intervalSE;
		doorAnimator = transform.parent.GetComponent<Animator>();
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

				if (!isLock)
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

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player") isArea = true;
		Debug.Log("isArea :" + isArea);
		Debug.Log("isLock : " + isLock);
	}

	void OnTriggerExit(Collider col)
	{
		if (col.tag == "Player") isArea = false;
		Debug.Log("isArea :" + isArea);
		Debug.Log("isLock : " + isLock);
	}

	public void LockFlag(bool torf)
	{
		isLock = torf;
		audioSource.PlayOneShot(unlockSE);
		Debug.Log("isLock : " + isLock);
	}
}
