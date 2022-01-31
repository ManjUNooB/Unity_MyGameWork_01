using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCS : MonoBehaviour
{
    GameObject Player_Obj;

    // Start is called before the first frame update
    void Start()
    {
        Player_Obj = GameObject.FindWithTag("Player").GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter(Collider Col_Obj)
	{
        if(Col_Obj.tag == "Player")
		{
            Player_Obj.GetComponent<FirstPersonMovement>().Has_Key = true;
            Destroy(this.gameObject);
        }
	}


}
