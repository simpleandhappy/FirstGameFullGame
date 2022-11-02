using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    enum ItemType {Coin, Health, Item};
    [SerializeField] private ItemType itemType;
    [SerializeField] private string itemName;
    [SerializeField] private Sprite itemSprite;

    // Start is called before the first frame update
    void Start(){
       
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
                    NewPlayer.Instance.AddInventoryItem(itemName, itemSprite);
                break;
            }
            NewPlayer.Instance.UpdateUI();
            Destroy(gameObject);
        }
    }

    void AddCoin(){
        NewPlayer.Instance.coinsCollected += 1;
    }
    void AddHealth(){
        //potentially can be optimized with %
        if (NewPlayer.Instance.health <= (NewPlayer.Instance.maxHealth - 100)) {
            NewPlayer.Instance.health += 100;
        }
        else if (NewPlayer.Instance.health > (NewPlayer.Instance.maxHealth - 100) && NewPlayer.Instance.health < NewPlayer.Instance.maxHealth){
            NewPlayer.Instance.health = NewPlayer.Instance.maxHealth;
        }
        
    }
}
