using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GoalCS : MonoBehaviour
{
    [Header("次のステージ")]
    [SerializeField] string nextScene;

    [Header("FadeCanvas")]
    [SerializeField] Fade fade;

    //音関連
    [SerializeField] AudioClip clearSE;
    AudioSource audioSource;

    private bool isArea;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        isArea = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player")
		{
            if (!isArea)
			{
                isArea = true;
                audioSource.PlayOneShot(clearSE);
                //	トランジション掛けてシーン遷移する
                fade.FadeIn(1f, () =>
                {
                    StartCoroutine("SceneChange");

                });
                
			}
        }
	}

    IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene(nextScene);
    }
}
