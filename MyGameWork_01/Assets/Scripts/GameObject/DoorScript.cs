using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    //  �h�A�̃G���A�ɓ����Ă��邩
    private bool isArea;

    //  �h�A�̃A�j���[�^�[
    private Animator animator;

    //  �h�A�̊J�L�[
    public KeyCode openKey = KeyCode.E;

    // Start is called before the first frame update
    void Start()
    {
        isArea = false;
        animator = transform.parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(openKey) && isArea)
		{
            animator.SetBool("Open", !animator.GetBool("Open"));
		}
    }
    
    void OnTriggerEnter(Collider col)
	{
        if(col.tag == "Player") isArea = true;
        Debug.Log(isArea);
		
	}

    void OnTriggerExit(Collider col)
	{
        if(col.tag == "Player") isArea = false;
        Debug.Log(isArea);
		
	}

}
