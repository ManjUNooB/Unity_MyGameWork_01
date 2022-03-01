using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M4CS : MonoBehaviour
{
	[Header("PlayerObject")]
	[SerializeField] private GameObject playerObj;
	private GunModeCS gunmodeCS;

	[Header("ItemM4Prefab")]
	[SerializeField] private GameObject m4ItemObj;

	// Start is called before the first frame update
	void Start()
	{
		gunmodeCS = playerObj.GetComponent<GunModeCS>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnTriggerEnter(Collider coll)
	{
		if (coll.tag == "Player")
		{
			gunmodeCS.modeFlag = true;
			Destroy(m4ItemObj);
		}
	}
}
