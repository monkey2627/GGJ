using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
    public void OpenSettings()
    {
        gameObject.transform.Find("SettingsPanel").gameObject.SetActive(true);
    }
    public void CloseSettings()
    {
        gameObject.transform.Find("SettingsPanel").gameObject.SetActive(false);
    }

}
