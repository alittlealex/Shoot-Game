using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrossHair : MonoBehaviour {
    public GUISkin m_Skin;
    public Texture2D crossHair;
    GameManager manager;

    void Start () {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
	
	void Update () {
		
	}

    void OnGUI()
    {
        GUI.skin = m_Skin;
        GUI.Label(new Rect(0, 0, 200, 50), "时间:" + manager.time.ToString());
        GUI.Label(new Rect(Screen.width - 100, 0, 100, 50), "分数:" + manager.score.ToString());

        float x = Input.mousePosition.x - (crossHair.width >> 1);
        float y = Input.mousePosition.y + (crossHair.height >> 1);
        if(manager.State == GameManager.GameState.GAME)
        {
            GUI.DrawTexture(new Rect(x, Screen.height - y, crossHair.width, crossHair.height), crossHair);
        }

        if(manager.time == 0)
        {
            GUI.Label(new Rect(610, 50, 500, 500), "GameOver");
            GUI.Label(new Rect(610, 100, 500, 500), "总分数：" + manager.score.ToString());
            if(GUI.Button(new Rect(610, 150, 100, 50), "重 新 开 始"))
            {
                
                SceneManager.LoadScene(0);
            }
        }
    }

}
