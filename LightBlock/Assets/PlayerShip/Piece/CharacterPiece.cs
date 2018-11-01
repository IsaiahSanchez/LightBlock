using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPiece : MonoBehaviour {

    [SerializeField]
    CharacterShip parentShip;

    public Color myColor;
    public BlockType myType;

    

    public void initialize(BlockType inputType, Color inputColor)
    {
        myType = inputType;
        myColor = inputColor;
    }



    private void strike()
    {
        if (parentShip.hasBeenHurtRecently == false)
        {
            parentShip.Strikes++;
            parentShip.hasBeenHurtRecently = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "ScorePiece")
        {
            if (target.GetComponent<ScorePiece>().blockType != BlockType.None)
            {
                if (myType == target.GetComponent<ScorePiece>().blockType)
                {
                    parentShip.Score += 10;
                }
                else
                {
                    strike();
                }
                Destroy(target.gameObject);
            }
            else
            {
                Destroy(target.gameObject);
            }
        }
        
        }
    }


