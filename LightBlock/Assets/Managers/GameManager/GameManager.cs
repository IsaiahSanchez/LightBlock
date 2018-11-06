using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    public Color chosenTL, chosenTR, chosenBR, chosenBL;

    public GameType gameType = GameType.Endless;

    public GameObject selectedLevel;

    public bool isMuted = false;

	// Use this for initialization
	void Awake () {
        MakeSingleton();
        chosenTL = new Color(0, 1, 0);
        chosenTR = new Color(1, 0, 0);
        chosenBR = new Color(1, 1, 0);
        chosenBL = new Color(0, 0, 1);
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
public enum SpawnLocation {Top,Right,Bottom,Left}
public enum GameType {Endless, Level}
