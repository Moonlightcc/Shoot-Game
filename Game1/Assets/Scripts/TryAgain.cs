using UnityEngine;
using System.Collections;

public class TryAgain : MonoBehaviour {
    private GameManager m_GameManager;
    // Use this for initialization
    void Start () {
        m_GameManager = GameObject.Find("UI").GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	void OnMouseDown()
    {
        m_GameManager.ChangeGameStatus(GameManager.GameStatus.START);
    }
}
