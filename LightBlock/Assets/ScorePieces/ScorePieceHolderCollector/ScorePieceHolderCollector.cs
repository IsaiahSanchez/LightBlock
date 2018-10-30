using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePieceHolderCollector : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "ScorePieceHolder")
        {
            Destroy(target.gameObject);
        }
    }
}
