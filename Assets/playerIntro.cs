using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerIntro : MonoBehaviour
{
    public GameObject[] images;
    int now;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public void Show()
    {
        images[0].SetActive(true);
        images[1].SetActive(false);
        images[2].SetActive(false);
        now = 0;
    }
}
