using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

	// Use this for initialization
	void Awake () {
        MakeSingleton();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void MakeSingleton()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }
}

public enum BlockType {TopLeft,TopRight,BottomRight,BottomLeft,None}
