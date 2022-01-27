using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCS : MonoBehaviour
{
    //ïœêîêÈåæ
    public KeyCode DoorOpen;

    private bool keyFlag;
    private bool isArea;

    private Animator doorAnimator;

    // Start is called before the first frame update
    void Start()
    {
        isArea = false;
        doorAnimator.transform.parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(DoorOpen) && isArea && keyFlag)
		{
            doorAnimator.SetBool("Open", !doorAnimator.GetBool("Open"));
		}
    }

	private void OnTriggerEnter(Collider col)
	{
        if (col.tag == "Player") isArea = true;
	}

	private void OnTriggerExit(Collider col)
	{
        if (col.tag == "Player") isArea = false;
	}
}
