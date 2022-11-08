using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private string requiredInventoryItem;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.name == "Player"){
            if (NewPlayer.Instance.inventory.ContainsKey(requiredInventoryItem)){
                NewPlayer.Instance.RemoveInventoryItem(requiredInventoryItem);
                NewPlayer.Instance.canWin = true;
                Destroy(gameObject);
            }
        }
    }
}
