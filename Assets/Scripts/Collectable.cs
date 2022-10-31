using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    enum ItemType {Coin, Health, Item};
    [SerializeField] private ItemType itemType;
    NewPlayer player;

    // Start is called before the first frame update
    void Start(){
        player = GameObject.Find("Player").GetComponent<NewPlayer>();
       
    }

    // Update is called once per frame
    void Update(){}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            switch(itemType){
                case ItemType.Coin:
                    AddCoin();
                break;
                case ItemType.Health:
                    AddHealth();
                break;
                case ItemType.Item:
                    player.AddInventoryItem("key", player.keySprite);
                break;
            }
            player.UpdateUI();
            Destroy(gameObject);
        }
    }

    void AddCoin(){
        player.coinsCollected += 1;
    }
    void AddHealth(){
        //potentially can be optimized with %
        if (player.health <= (player.maxHealth - 100)) {
            player.health += 100;
        }
        else if (player.health > (player.maxHealth - 100) && player.health < player.maxHealth){
            player.health = player.maxHealth;
        }
        
    }
}
