using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCS : MonoBehaviour
{
    //ïœêîêÈåæ
    public KeyCode DoorOpen = KeyCode.E;
    [SerializeField] GameObject playerObj;
    [SerializeField] GameObject keymanagerObj;
    KeyManagerCS keymanagerScript;

    private bool isArea;
    private bool hasKey;

    private Animator doorAnimator;

    // Start is called before the first frame update
    void Start()
    {
        isArea = false;
        doorAnimator = transform.parent.GetComponent<Animator>();
        keymanagerScript = keymanagerObj.GetComponent<KeyManagerCS>();
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(DoorOpen) && isArea)
		{
            if (hasKey = keymanagerScript.KeyFlag)
            {
                doorAnimator.SetBool("Open", !doorAnimator.GetBool("Open"));
            }
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
