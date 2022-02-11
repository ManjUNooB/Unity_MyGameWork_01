using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerCS : MonoBehaviour
{
    [SerializeField] Fade fade;

    // Start is called before the first frame update
    void Start()
    {
        fade.FadeOut(1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
