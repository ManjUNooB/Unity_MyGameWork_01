using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbiter : MonoBehaviour
{
    [SerializeField] float radius = 10;  // ‰ñ“]”¼Œa
    [SerializeField] float cycle = 27;   // ‰ñ“]ŽüŠú
    [SerializeField] float angle = 0;    // Šp“x
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        angle -= Time.deltaTime * 2 * Mathf.PI / cycle;
        float x = Mathf.Sin(angle) * radius;
        float z = Mathf.Cos(angle) * radius;

        transform.position = new Vector3(x, 0, z);
    }
}
