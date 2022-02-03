using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCS : MonoBehaviour
{
    [SerializeField]GameObject PlayerObj;
    [SerializeField] GameObject KeyManagerObj;
    KeyManagerCS script;
    // Start is called before the first frame update
    void Start()
    {
        script = KeyManagerObj.GetComponent<KeyManagerCS>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter(Collider Col_Obj)
	{
        if(Col_Obj.tag == "Player")
		{
            script.KeyFlag = true;
            Destroy(this.gameObject);
        }
	}


}
