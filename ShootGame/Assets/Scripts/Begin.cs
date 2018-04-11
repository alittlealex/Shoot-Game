using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Begin : MonoBehaviour {

    public GUISkin m_Skin;
    GameManager manager;

    void Start () {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        manager.State = GameManager.GameState.START;
    }
	
	void Update () {
		
	}

    void OnGUI()
    {
        GUI.skin = m_Skin;
        GUI.Label(new Rect(610, 50, 500, 500), "打 手 枪");

        if(GUI.Button(new Rect(650, 200, 100, 50), "开始游戏"))
        {
            SceneManager.LoadScene(1);
        }
    }
}
