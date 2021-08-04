using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class M_gamemanager : MonoBehaviour
{
    public static M_gamemanager _instance;
    [HideInInspector]
    public int LeftIndex = 0;
    [HideInInspector]
    public int RightIndex = 0;
    [HideInInspector]
    public float LeftScore = 0;
    [HideInInspector]
    public float RightScore = 0;
    [HideInInspector]
    public int levelIndex =1;

    [HideInInspector]
    public bool IsLeftGebo = false;
    [HideInInspector]
    public bool IsRightGebo = false;

    public Transform tar;
    public VideoPlay video;

    public GameObject rightHand;
    public GameObject leftHand;

    public Text LeijiTime;
    public Text BenjieTime;
    public Text BenjieAnimation;
    public Text Huanceshou;
    public Text ZhengqueIndex;

    public Text LeijiTime02;
    public Text BenjieTime02;
    public Text BenjieAnimation02;
    public Text Huanceshou02;
    public Text ZhengqueIndex02;

    public AudioClip[] clips;
    public AudioClip[] gujiclips;

    public Transform Benjiejieshao;
    public Transform BenjieJiezhong;

    public GameObject Wancheng;
    public GameObject Quanbuwancheng;

    float leijiIndex = 0;
    float beijieIndex = 0;

    private void Awake()
    {
        _instance = this;
        levelIndex =0;
    }

    private void Start()
    {
        switch (User_.H_handtype)
        {
            case User_.Handtype.lefthand:
                Huanceshou.text = "左手";
                Huanceshou02.text = "左手";
                video.transform.localScale = new Vector3(video.transform.localScale.x, video.transform.localScale.y, video.transform.localScale.z);
                break;
            case User_.Handtype.righthand:
                Huanceshou.text = "右手";
                Huanceshou02.text = "右手";
                video.transform.localScale = new Vector3(-(video.transform.localScale.x), video.transform.localScale.y, video.transform.localScale.z);
                break;
        }
    }

    //设置起始得声音
    public void SetStartAudio()
    {
        if (levelIndex>=0&&levelIndex<= clips.Length-1)
        {
            this.GetComponent<AudioSource>().clip = clips[levelIndex];
            this.GetComponent<AudioSource>().Play();
        } 
    }

    public void Leftscore(bool ison)
    {
        if (LeftIndex<32)
        {
            if (LeftIndex==16)
            {
                this.GetComponent<AudioSource>().clip = gujiclips[0];
                this.GetComponent<AudioSource>().Play();
            }

            if (ison)
            {
                LeftIndex++;
                ZhengqueIndex.text = LeftIndex.ToString();
                ZhengqueIndex02.text = LeftIndex.ToString();
            }
            Tiaozhuan();
        }
    }

    public void Rightscore(bool ison)
    {
        if (RightIndex< 32)
        {
            if (RightIndex==16)
            {
                this.GetComponent<AudioSource>().clip = gujiclips[0];
                this.GetComponent<AudioSource>().Play();
            }
  
            if (ison)
            {
                RightIndex++;
                ZhengqueIndex.text = RightIndex.ToString();
                ZhengqueIndex02.text = RightIndex.ToString();
            }
            Tiaozhuan();
        }
    }

    public void Tiaozhuan()
    {
        switch (User_.H_handtype)
        {
            case User_.Handtype.lefthand:
                if (LeftIndex == 32)
                {
                    if (levelIndex < tar.childCount)
                    {
                        this.GetComponent<AudioSource>().clip = gujiclips[2];
                        this.GetComponent<AudioSource>().Play();
                        video.M_Stop();

                        StartCoroutine(yanshi_Tiaozhuan());
                    }
                    else
                    {
                        this.GetComponent<AudioSource>().clip = gujiclips[2];
                        this.GetComponent<AudioSource>().Play();
                        video.M_Stop();
                        Quanbuwancheng.SetActive(true);
                    }
                }
                break;
            case User_.Handtype.righthand:
                if (RightIndex == 32)
                {
                    if (levelIndex < tar.childCount)
                    {
                        this.GetComponent<AudioSource>().clip = gujiclips[2];
                        this.GetComponent<AudioSource>().Play();
                        video.M_Stop();
                        StartCoroutine(yanshi_Tiaozhuan());
                    }
                    else
                    {
                        this.GetComponent<AudioSource>().clip = gujiclips[2];
                        this.GetComponent<AudioSource>().Play();
                        video.M_Stop();
                        Quanbuwancheng.SetActive(true);
                    }
                }
                break;
        }

    }

    IEnumerator yanshi_Tiaozhuan()
    {
       
        M_Bianli(BenjieJiezhong, 20); //隐藏文字
        Wancheng.gameObject.SetActive(true);
        yield return new WaitForSeconds(10);

        Tiaozhuanlevel(1);
    }


    void Bianli(int index)
    {
        for (int i = 0; i < tar.childCount; i++)
        {
            if (i == index)
            {
                tar.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                tar.GetChild(i).gameObject.SetActive(false);
            }
        }
  
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (levelIndex < tar.childCount)
            {
                Tiaozhuanlevel(1);
            }
        }

        if (Input.GetKeyDown(KeyCode.B))
        {        
            if (levelIndex >0)
            {
                Tiaozhuanlevel(-1);
            }
        }

        if (Input.GetKeyDown(KeyCode.KeypadPlus)|| Input.GetKeyDown(KeyCode.Return))
        {

            //if (levelIndex==4)
            //{
                switch (User_.H_handtype)
                {
                    case User_.Handtype.lefthand:
                        Leftscore(true);
                        break;
                    case User_.Handtype.righthand:
                        Rightscore(true);
                        break;
                }
            //}
        }

        leijiIndex += Time.deltaTime;
        LeijiTime.text = string.Format("累计时间：{0:D2}:{1:D2}", (int)leijiIndex / 60, (int)leijiIndex%60);
        LeijiTime02.text = string.Format("累计时间：{0:D2}:{1:D2}", (int)leijiIndex / 60, (int)leijiIndex%60);

        beijieIndex += Time.deltaTime;
        BenjieTime.text = string.Format("本节时间：{0:D2}:{1:D2}", (int)beijieIndex / 60, (int)beijieIndex % 60);
        BenjieTime02.text = string.Format("本节时间：{0:D2}:{1:D2}", (int)beijieIndex / 60, (int)beijieIndex % 60);
    }

    public void JumpScene()
    {
        SceneManager.LoadScene(0);
        User_.H_handtype = User_.Handtype.Null;
    }

    public void Tiaozhuanlevel(int index)
    {
        if (index>0)
        {
            levelIndex++;
            if (levelIndex>=9)
            {
                levelIndex = 9;
            }
        }
        else if (index<0)
        {
            levelIndex--;
            if (levelIndex<=0)
            {
                levelIndex = 0;
            }
        }

        M_Bianli(BenjieJiezhong, 20); //隐藏文字

        rightHand.GetComponent<Hand>().go = null;
        leftHand.GetComponent<Hand>().go = null;
        Bianli(levelIndex);

        ZhengqueIndex.text = "0";
        ZhengqueIndex02.text = "0";

        beijieIndex = 0;
        LeftIndex = 0;
        RightIndex = 0;
        LeftScore = 0;
        RightScore = 0;
        IsLeftGebo = false;
        IsRightGebo = false;
        SetAinimation();
        Wancheng.SetActive(false);
        StopCoroutine(video.M_video());
        StartCoroutine(video.M_video());
    }

    void SetAinimation()
    {
        switch (levelIndex)
        {
            case 0:
                BenjieAnimation.text = "第一节：握拳动作";
                BenjieAnimation02.text = "第一节：握拳动作";
                break;
            case 1:
                BenjieAnimation.text = "第二节：旋腕动作";
                BenjieAnimation02.text = "第二节：旋腕动作";
                break;
            case 2:
                BenjieAnimation.text = "第三节：屈肘动作";
                BenjieAnimation02.text = "第三节：屈肘动作";
                break;
            case 3:
                BenjieAnimation.text = "第四节：上举动作";
                BenjieAnimation02.text = "第四节：上举动作";
                break;
            case 4:
                BenjieAnimation.text = "第五节：绕肩动作";
                BenjieAnimation02.text = "第五节：绕肩动作";
                break;
            case 5:
                BenjieAnimation.text = "第六节：摸耳动作";
                BenjieAnimation02.text = "第六节：摸耳动作";
                break;
            case 6:
                BenjieAnimation.text = "第七节：爬墙动作";
                BenjieAnimation02.text = "第七节：爬墙动作";
                break;
            case 7:
                BenjieAnimation.text = "第八节：后背手动作";
                BenjieAnimation02.text = "第八节：后背手动作";
                break;
            case 8:
                BenjieAnimation.text = "第九节：抱头动作";
                BenjieAnimation02.text = "第九节：抱头动作";
                break;
            case 9:
                BenjieAnimation.text = "第十节：外展动作";
                BenjieAnimation02.text = "第十节：外展动作";
                break;
        }
    }


    public void M_Bianli(Transform tra,int index)
    {
        for (int i = 0; i < tra.childCount; i++)
        {
            if (i==index)
            {
                tra.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                tra.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
