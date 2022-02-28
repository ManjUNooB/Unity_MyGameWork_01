using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunModeCS : MonoBehaviour
{
	//カメラ
	[SerializeField] private Camera playerCamera;
	//M4のプレハブ
	[SerializeField] private GameObject M4Obj;

	//マウス設定
	[SerializeField]
	[Range(0, 2)] private int mouseButton;

	//Audio
	[SerializeField] private AudioSource gunmodeAudio;
	[SerializeField] private AudioClip gunmodeSE;

	//フラグ
	private bool gunFlag;
	//プロパティ
	public bool ModeFlag
	{
		set { gunFlag = ModeFlag; }
		get { return gunFlag; }
	}

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		//銃の有効化
		if (gunFlag)
		{
			M4Obj.SetActive(!M4Obj.activeSelf);
		}


	}

	private void FixedUpdate()
	{
		if (Input.GetKey(KeyCode.F))
		{
			Debug.Log(gunFlag);
		}

		if (gunFlag){
			//マウスを押した時
			if (Input.GetMouseButton(mouseButton))
			{
				Ray ray = playerCamera.ViewportPointToRay(new Vector2(0.5f, 0.5f));
				RaycastHit hit;

				if (Physics.Raycast(ray, out hit, 20.0f))
				{
					Debug.Log(hit.collider.transform.name);
				}
				Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, 5);
			}
		}
	}
}