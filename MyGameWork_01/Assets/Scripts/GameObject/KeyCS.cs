using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCS : MonoBehaviour
{
    [SerializeField] AudioClip keyGetSE;
    [SerializeField]GameObject PlayerObj;
    [SerializeField] GameObject KeyManagerObj;
    KeyManagerCS script;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        script = KeyManagerObj.GetComponent<KeyManagerCS>();
        audioSource = KeyManagerObj.GetComponent<AudioSource>();
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
            audioSource.PlayOneShot(keyGetSE);
            Destroy(this.gameObject);
            
        }
	}


}
