using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    Transform m_Transform;
    Transform m_Point;
    Ray ray;
    RaycastHit hit;
    LineRenderer line;
    AudioSource m_AudioSource;
    GameManager manager;


    void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        m_Point = m_Transform.Find("Point");
        line = m_Point.GetComponent<LineRenderer>();
        m_AudioSource = gameObject.GetComponent<AudioSource>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
	
	void Update () {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit))
        {
            m_Transform.LookAt(hit.point);

            line.SetPosition(0, m_Point.position);
            line.SetPosition(1, hit.point);

            if (Input.GetMouseButtonDown(0))
            {
                m_AudioSource.Play();
            }

            if(hit.collider.tag == "Target" && Input.GetMouseButtonDown(0))
            {
                manager.score += 1;
                Transform parent = hit.collider.gameObject.GetComponent<Transform>().parent;
                Transform[] childs = parent.GetComponentsInChildren<Transform>();
                for(int i = 0; i < childs.Length; i++)
                {
                    childs[i].gameObject.AddComponent<Rigidbody>();
                }

                GameObject.Destroy(parent.gameObject, 2.0f);
            }
        }

        if(manager.State == GameManager.GameState.END)
        {
            GameObject.Destroy(gameObject);
        }


	}
}
