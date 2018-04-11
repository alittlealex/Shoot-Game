using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public enum GameState
    {
        START,
        GAME,
        END
    }

    private GameState state;

    public int time;
    public int score;

    public GameState State
    {
        get { return this.state; }
        set { state = value; }
    }


    void Start () {
        state = GameState.GAME;
        time = 20;
        score = 0;
        InvokeRepeating("SubTime", 0.0f, 1.0f);
	}
	
	void Update () {
        if(state == GameState.GAME)
        {
            Cursor.visible = false;
        }
        else if(state == GameState.END)
        {
            Cursor.visible = true;
        }
        else if (state == GameState.START)
        {
            Cursor.visible = true;
        }

        if (time == 0)
        {
            CancelInvoke();
            state = GameState.END;
        }
	}

    void SubTime()
    {
        time--;
    }
}
