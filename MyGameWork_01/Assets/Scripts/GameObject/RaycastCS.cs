using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastCS : MonoBehaviour
{
	[SerializeField] private Camera playerCamera;
	[SerializeField]
	[Range(0, 2)] private int MouseKey;

	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
	}

	private void FixedUpdate()
	{
		if(Input.GetMouseButton(MouseKey)){
			Ray ray = playerCamera.ViewportPointToRay(new Vector2(0.5f, 0.5f));
			RaycastHit hit;

			if(Physics.Raycast(ray,out hit,10.0f)){
				Debug.Log(hit.collider.gameObject.name);
			}
			Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, 5);
		}


	}
}
