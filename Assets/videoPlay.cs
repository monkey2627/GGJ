using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class videoPlay : MonoBehaviour
{
    // Start is called before the first frame update
    public VideoPlayer videoPlayer;
    public GameObject startPanel;
    float t = 0;
    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }
    void Start()
    {
        videoPlayer.Play();
        t = 0;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
       if(!videoPlayer.isPlaying && t > 4f){

            startPanel.SetActive(true);
            gameObject.transform.parent.gameObject.SetActive(false);
        }
    }
}
