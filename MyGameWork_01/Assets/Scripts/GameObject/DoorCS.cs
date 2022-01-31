using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCS : MonoBehaviour
{
    //ïœêîêÈåæ
    public KeyCode DoorOpen = KeyCode.E;
    GameObject Player_Obj;
    private bool isArea;

    private Animator doorAnimator;

    // Start is called before the first frame update
    void Start()
    {
        isArea = false;
        doorAnimator = transform.parent.GetComponent<Animator>();
        Player_Obj = GameObject.FindWithTag("Player").GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(DoorOpen) && isArea && Player_Obj.GetComponent<FirstPersonMovement>().Has_Key)
		{
            doorAnimator.SetBool("Open", !doorAnimator.GetBool("Open"));
		}
    }

	private void OnTriggerEnter(Collider col)
	{
        if (col.tag == "Player") isArea = true;
        Debug.Log(isArea);
	}

	private void OnTriggerExit(Collider col)
	{
        if (col.tag == "Player") isArea = false;
        Debug.Log(isArea);
    }
}
