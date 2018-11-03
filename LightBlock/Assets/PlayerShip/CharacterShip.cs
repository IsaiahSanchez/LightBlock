using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterShip : MonoBehaviour {

    [SerializeField]
    private Text multiplierText;

    public int Score = 0;
    public int Strikes = 0;
    private int currentScorePerBlock = 10;
    private int totalScored = 0;
    private int currentChain = 0;
    public int ScoreMultiplier = 1;


    private Transform trans;

    private float rot;
    private float desiredRot;

    public float speed = 125;
    private bool shouldRotate = false;

    public bool hasBeenHurtRecently = false;
    private float howLongSinceHurt = 0f;
    private float invincibilityTime = .5f;

    public bool hasScoredRecently = false;
    private float howLongSinceScored = 0f;
    private float nonScoringTime = .25f;

    // Use this for initialization
    void Start () {
        rot = 0f;
        desiredRot = 0f;
        trans = transform;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            AddScore();
        }

        checkCooldowns();
        checkCurrentMultiplier();
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

    public void AddScore()
    {
        if (hasScoredRecently == false)
        {
            Score += (currentScorePerBlock*ScoreMultiplier);
            hasScoredRecently = true;
            GameplayController.instance.setScoreandStrikes(Score, Strikes);
            currentChain++;
            totalScored++;
            checkToSpeedUp();
        }
    }

    public void AddStrike()
    {
        if (hasBeenHurtRecently == false)
        {
            Strikes++;
            hasBeenHurtRecently = true;
            GameplayController.instance.setScoreandStrikes(Score, Strikes);
            currentChain = 0;
        }
    }

    private void checkCooldowns()
    {
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


        if (hasScoredRecently == true)
        {
            howLongSinceScored += Time.deltaTime;
            Debug.Log(howLongSinceScored);
            if (howLongSinceScored > nonScoringTime)
            {
                howLongSinceScored = 0;
                hasScoredRecently = false;
            }
        }
        
    }

    private void checkCurrentMultiplier()
    {
        switch (currentChain)
        {
            case 0:
                ScoreMultiplier = 1;
                break;
            case 10:
                ScoreMultiplier = 2;
                break;
            case 25:
                ScoreMultiplier = 4;
                break;
            case 40:
                ScoreMultiplier = 8;
                break;

            default:
                break;
        }

        multiplierText.text = "x" + ScoreMultiplier;
    }

    private void checkToSpeedUp()
    {
        if (totalScored % 10 == 0)
        {
            GameplayController.instance.SpeedUpEndlessGame();
        }
    }
}
