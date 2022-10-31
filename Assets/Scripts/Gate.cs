using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    NewPlayer player;
    [SerializeField] private string requiredInventoryItem;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<NewPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.name == "Player"){
            if (player.inventory.ContainsKey(requiredInventoryItem)){
                player.RemoveInventoryItem(requiredInventoryItem);
                Destroy(gameObject);
            }
        }
    }
}
