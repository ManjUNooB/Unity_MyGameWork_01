using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunModeCS : MonoBehaviour
{
	//カメラ
	[SerializeField] private Camera playerCamera;
	//M4のプレハブ
	[SerializeField] private GameObject M4Obj;
	//ドア
	[SerializeField] private GameObject doorObj;

	//マウス設定
	[SerializeField]
	[Range(0, 2)] private int mouseButton;

	//レイの長さ
	[SerializeField]
	[Range(0.0f, 100.0f)] private float rayRange;

	//スクリプト
	ShootingDoorCS doorCS;

	//Audio
	//[SerializeField] private AudioSource gunmodeAudio;
	//[SerializeField] private AudioClip gunmodeSE;

	//フラグ
	private bool gunFlag;
	private bool hitFlag;
	//プロパティ
	public bool modeFlag
	{
		set { gunFlag = value; }
		get { return gunFlag; }
	}

	// Start is called before the first frame update
	void Start()
	{
		doorCS = doorObj.GetComponent<ShootingDoorCS>();
		hitFlag = false;
	}

	// Update is called once per frame
	void Update()
	{
		//銃の有効化
		if (gunFlag)
		{
			M4Obj.SetActive(true);
			gunFlag = true;
		}

	}

	private void FixedUpdate()
	{
		if (gunFlag)
		{
			//マウスを押した時
			if (Input.GetMouseButton(mouseButton))
			{
				Ray ray = playerCamera.ViewportPointToRay(new Vector2(0.5f, 0.5f));
				RaycastHit hit;

				if (Physics.Raycast(ray, out hit, rayRange))
				{
					if (hit.transform.tag == "Target")
					{
						if (!hitFlag)
						{
							doorCS.LockFlag(false);
							Debug.Log("Target Hit");
							hitFlag = true;
						}
					}
				}
				Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, 5);
			}
		}
	}
}