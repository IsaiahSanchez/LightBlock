using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScaler : MonoBehaviour {

    [SerializeField]
    public GameObject locationTop, locationRight, locationBottom, locationLeft;

	// Use this for initialization
	void Start () {
        float height = Camera.main.orthographicSize;
        float width = Screen.width / (Camera.main.scaledPixelHeight / height);

        locationTop.transform.position = new Vector2(0, height);
        locationBottom.transform.position = new Vector2(0, -height);
        locationLeft.transform.position = new Vector2(-width, 0);
        locationRight.transform.position = new Vector2(width, 0);

        locationTop.transform.rotation = Quaternion.Euler(0, 0, 0);
        locationRight.transform.rotation = Quaternion.Euler(0, 0, -90);
        locationBottom.transform.rotation = Quaternion.Euler(0, 0, 180);
        locationLeft.transform.rotation = Quaternion.Euler(0, 0, 90);


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
