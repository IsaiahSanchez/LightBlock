using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShip : MonoBehaviour {

    public int Score = 0;
    public int Strikes = 0;

    private Transform trans;

    private float rot;
    private float desiredRot;

    public float speed = 125;
    private bool shouldRotate = false;

    public bool hasBeenHurtRecently = false;
    private float howLongSinceHurt = 0f;
    private float invincibilityTime = .5f;

    // Use this for initialization
    void Start () {
        rot = 0f;
        desiredRot = 0f;
        trans = transform;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        checkIfShouldRotate();
        if (shouldRotate)
        {
            rotate();
        }

        if (rot <= desiredRot + 20 && rot >= desiredRot - 20)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                setRotationDirection(-1f);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                setRotationDirection(1f);
            }
        }

        if (hasBeenHurtRecently == true)
        {
            howLongSinceHurt += Time.deltaTime;
            Debug.Log(howLongSinceHurt);
            if (howLongSinceHurt > invincibilityTime)
            {
                howLongSinceHurt = 0;
                hasBeenHurtRecently = false;
            }
        }

    }

    public void setRotationDirection(float direction)
    {
        if (rot <= desiredRot + 20 && rot >= desiredRot - 20)
        {
            desiredRot = desiredRot + (90 * direction);
        }
    }

    private void checkIfShouldRotate()
    {
        if (rot != desiredRot)
        {
            shouldRotate = true;
        }
        else
        {
            shouldRotate = false;
        }
        
    }

    private void rotate()
    {
        if (rot < desiredRot)
        {
            rot += (speed * Time.deltaTime);
        }
        else if (rot > desiredRot)
        {
            rot -= (speed * Time.deltaTime);
        }

        if (rot < desiredRot + 7 && rot > desiredRot - 7) 
        {
            rot = desiredRot;
        }

        trans.SetPositionAndRotation(trans.position, Quaternion.Euler(0, 0, rot)); 
    }
}
