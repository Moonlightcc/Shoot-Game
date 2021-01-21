using UnityEngine;
using System.Collections;

public class FeiPan : MonoBehaviour {

    private GameManager m_GameManager;

    void Start()
    {
        m_GameManager = GameObject.Find("UI").GetComponent<GameManager>();
    }
	// Use this for initialization
	void OnDestroy()
    {
        if(m_GameManager != null)
            m_GameManager.AddScore();
    }
}
