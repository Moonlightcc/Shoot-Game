using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public enum GameStatus { START,GAME,END}

    private GameObject m_StartUI;
    private GameObject m_GameUI;
    private GameObject m_EndUI;
    private GUIText m_GUIText;

    private GameStatus gameStatus;

    private AudioSource m_AudioSource;

    private Weapon m_weapon;

    private FeiPanManager m_FeiPanManager;

    private int Score = 0;

    private bool startTime = false;
    private float time = 5;
    private GUIText time_GUIText;

    private GUIText end_GUIText;
	// Use this for initialization
	void Start () {
        m_StartUI = GameObject.Find("StartUI");
        m_GameUI = GameObject.Find("GameUI");
        m_EndUI = GameObject.Find("EndUI");
        m_GUIText = GameObject.Find("GameScore").GetComponent<GUIText>();

        m_AudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        m_weapon = GameObject.Find("Hand").GetComponent<Weapon>();
        m_FeiPanManager = GameObject.Find("FeiPanParent").GetComponent<FeiPanManager>();

        time_GUIText = GameObject.Find("GameTime").GetComponent<GUIText>();

        end_GUIText = GameObject.Find("GameTotalScore").GetComponent<GUIText>();
        ChangeGameStatus(GameStatus.START);
    }
	
	// Update is called once per frame
    public void ChangeGameStatus(GameStatus status)
    {
        GameStatus m_GameStatus = status;
        if (m_GameStatus == GameStatus.START)
        {
            m_StartUI.SetActive(true);
            m_GameUI.SetActive(false);
            m_EndUI.SetActive(false);
            m_AudioSource.Stop();
            m_weapon.ChangeHandMove(false);
            m_FeiPanManager.StopCreateFeiPan();
            GameObject[] trash = GameObject.FindGameObjectsWithTag("Trash");
            for (int i = 0; i < trash.Length; i++)
                GameObject.Destroy(trash[i]);
            
        }
        else if (m_GameStatus == GameStatus.GAME)
        {
            Score = 0;
            m_GUIText.text = "分数:0";
            time = 20;
            time_GUIText.text = "时间：20秒";
            m_GameUI.SetActive(true);
            m_StartUI.SetActive(false);
            m_EndUI.SetActive(false);
            m_AudioSource.Play();
            m_weapon.ChangeHandMove(true);
            m_FeiPanManager.StartCreateFeiPan();
            StartTime();
        }
        else
        {
            m_EndUI.SetActive(true);
            m_StartUI.SetActive(false);
            m_GameUI.SetActive(false);
            m_AudioSource.Stop();
            OverScore();
            m_weapon.ChangeHandMove(false);
            m_FeiPanManager.StopCreateFeiPan();
        }
    }
    public void AddScore()
    {
        Score++;
        m_GUIText.text = "分数：" + Score;
    }

    public void StartTime()
    {
        startTime = true;
    }

    void Update()
    {
        if(startTime)
        {
            time -= Time.deltaTime;
            time_GUIText.text = "时间:" + (int)time + "秒";
            if(time <= 0)
            {
                time = 20;
                startTime = false;
                ChangeGameStatus(GameStatus.END);
            }
        }
    }
    void OverScore()
    {
        end_GUIText.text = "总分数:" + Score;
    }
}
