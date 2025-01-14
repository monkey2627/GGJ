using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sprite : MonoBehaviour
{
    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        transform.GetComponent<SpriteRenderer>().receiveShadows = true;
        transform.GetComponent<SpriteRenderer>().castShadows = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
