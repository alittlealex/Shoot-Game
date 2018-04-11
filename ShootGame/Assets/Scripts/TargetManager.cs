using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour {

    public GameObject Target;

    private Transform m_Transform;
    GameManager manager;

    void Start () {
        InvokeRepeating("CreateTarget", 2.0f, 1.0f);
        m_Transform = gameObject.GetComponent<Transform>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
	
	void Update () {
		if(manager.State == GameManager.GameState.END)
        {
            CancelInvoke();
        }
	}

    /// <summary>
    /// 创建靶子
    /// </summary>
    void CreateTarget()
    {
        for(int i = 0; i < 3; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-4.0f, 4.5f), Random.Range(0.5f, 3.0f), Random.Range(17.0f, 20.0f));

            GameObject go = GameObject.Instantiate(Target, pos, Quaternion.identity) as GameObject;
            go.GetComponent<Transform>().SetParent(m_Transform);
        }

    }

    
}
