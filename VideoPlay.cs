using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlay : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(M_video());
    }

    //int index = 0;

    public IEnumerator M_video()
    {
        this.GetComponent<VideoPlayer>().Stop();
        M_gamemanager._instance.Benjiejieshao.gameObject.SetActive(true);

        //遍历开头
        M_gamemanager._instance.M_Bianli(M_gamemanager._instance.Benjiejieshao, M_gamemanager._instance.levelIndex);
        //开始语音
        M_gamemanager._instance.SetStartAudio();
        yield return new WaitForSeconds(M_gamemanager._instance.clips[M_gamemanager._instance.levelIndex].length);

        //index = M_gamemanager._instance.levelIndex;

        M_gamemanager._instance.Benjiejieshao.gameObject.SetActive(false);
        M_gamemanager._instance.BenjieJiezhong.gameObject.SetActive(true);

        M_gamemanager._instance.M_Bianli(M_gamemanager._instance.Benjiejieshao, 20); //隐藏文字
        M_gamemanager._instance.M_Bianli(M_gamemanager._instance.BenjieJiezhong, M_gamemanager._instance.levelIndex); //隐藏文字

        if (this.GetComponent<VideoPlayer>().isPlaying)
        {
            yield break;
        }

        switch (M_gamemanager._instance.levelIndex)
        {
            case 0:
                this.GetComponent<VideoPlayer>().url = Application.streamingAssetsPath + "/video/" + "第一节.mp4";
                break;
            case 1:
                this.GetComponent<VideoPlayer>().url = Application.streamingAssetsPath + "/video/" + "第二节.mp4";
                break;
            case 2:
                this.GetComponent<VideoPlayer>().url = Application.streamingAssetsPath + "/video/" + "第三节.mp4";
                break;
            case 3:
                this.GetComponent<VideoPlayer>().url = Application.streamingAssetsPath + "/video/" + "第四节.mp4";
                break;
            case 4:
                this.GetComponent<VideoPlayer>().url = Application.streamingAssetsPath + "/video/" + "第五节.mp4";
                break;
            case 5:
                this.GetComponent<VideoPlayer>().url = Application.streamingAssetsPath + "/video/" + "第六节.mp4";
                break;
            case 6:
                this.GetComponent<VideoPlayer>().url = Application.streamingAssetsPath + "/video/" + "第七节.mp4";
                break;
            case 7:
                this.GetComponent<VideoPlayer>().url = Application.streamingAssetsPath + "/video/" + "第八节.mp4";
                break;
            case 8:
                this.GetComponent<VideoPlayer>().url = Application.streamingAssetsPath + "/video/" + "第九节.mp4";
                break;
            case 9:
                this.GetComponent<VideoPlayer>().url = Application.streamingAssetsPath + "/video/" + "第十节.mp4";
                break;
        }
        // print("69989899");
        this.GetComponent<VideoPlayer>().Play();

    }

    public void M_Stop()
    {
        this.GetComponent<VideoPlayer>().Pause();

    }

    public void Update()
    {
        if (this.GetComponent<VideoPlayer>().isPlaying)
        {
            this.GetComponent<MeshRenderer>().material.SetTexture("_BaseColorMap", this.GetComponent<VideoPlayer>().texture);
        }
    }
}
