using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWorld : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit2D(Collider2D col){
        if (col.gameObject == NewPlayer.Instance.gameObject){
            NewPlayer.Instance.Die();
        }
    }
}
