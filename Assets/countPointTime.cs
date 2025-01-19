using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class countPointTime : MonoBehaviour
{
    // Start is called before the first frame update
    int time = 0;
    void Start()
    {
        
    }

    public void TImeAdd()
    {
        time += 1;
        if(time == 1)
        {
            GameManager.instance.StartGame();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
