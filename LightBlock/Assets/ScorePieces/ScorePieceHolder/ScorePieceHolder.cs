using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePieceHolder : MonoBehaviour {

    [SerializeField]
    private ScorePiece LeftLocation, RightLocation;

    public float speed = 10f;

    Rigidbody2D myBody;

    // Use this for initialization
    void Awake () {
        myBody = GetComponent<Rigidbody2D>();

        setBlockType(BlockType.TopLeft, BlockType.TopRight);
        setColorsForObjects(new Color(0, 0, 0), new Color(0, 0, 0));
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        moveObject();
	}

    private void moveObject()
    {
        myBody.velocity = -transform.up.normalized * (speed * Time.deltaTime);
    }

    public void setColorsForObjects(Color leftColor, Color rightColor)
    {
        LeftLocation.GetComponent<SpriteRenderer>().color = leftColor;
        RightLocation.GetComponent<SpriteRenderer>().color = rightColor;
    }

    public void setBlockType(BlockType leftType, BlockType rightType)
    {
        LeftLocation.blockType = leftType;
        RightLocation.blockType = rightType;
    }

    public BlockType getBlocktype(bool Left)
    {
        if (Left)
        {
            return LeftLocation.blockType;
        }
        else
        {
            return RightLocation.blockType;
        }
    }
}
