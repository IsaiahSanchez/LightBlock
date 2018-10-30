using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShip : MonoBehaviour {

    private Transform trans;

    private float rot;
    private float desiredRot;

    public float speed = 100;
    private bool shouldRotate = false;

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
        else
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
    }

    public void setRotationDirection(float direction)
    {
        if (shouldRotate == false)
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
        if (rot < desiredRot + 3 && rot > desiredRot - 3)
        {
            rot = desiredRot;
        }

        trans.SetPositionAndRotation(trans.position, Quaternion.Euler(0, 0, rot)); 
    }
}
