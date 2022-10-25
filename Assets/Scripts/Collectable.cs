using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    enum ItemType {Coin, Health, Upgrade};
    private Dictionary<ItemType, string> collectables = new Dictionary<ItemType, string>(){
        {ItemType.Coin, "coin"},
        {ItemType.Health, "health"},
        {ItemType.Upgrade, "upgrade"}
    };
    [SerializeField] private ItemType itemType;

    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update(){}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Player")
        {
            switch(itemType){
                case ItemType.Coin:
                    AddCoin();
                break;
                case ItemType.Health:
                    AddHealth();
                break;
                case ItemType.Upgrade:
                    AddUpgrade();
                break;
            }
            Destroy(gameObject);
        }
    }

    void AddCoin(){
        GameObject.Find("Player").GetComponent<NewPlayer>().coinsCollected += 1;
    }
    void AddHealth(){
        GameObject.Find("Player").GetComponent<NewPlayer>().health += 1;
    }
    void AddUpgrade(){
        GameObject.Find("Player").GetComponent<NewPlayer>().upgrades.Add("1");
    }
}
