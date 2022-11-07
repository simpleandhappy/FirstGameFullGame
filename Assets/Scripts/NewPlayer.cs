using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class NewPlayer : PhysicsObject
{
    [SerializeField] private float maxSpeed = 3f;
    [SerializeField] private float jumpHeight = 7f;
    [SerializeField] private GameObject attackBox;
    public int attackPower;
    public int maxHealth = 1000;
    public int coinsCollected;
    public int health;
    public Vector2 direction;

    //Inventory
    public Dictionary<string, Sprite> inventory = new Dictionary<string, Sprite>();

    //UI
    public Image inventoryItemImage;
    public Sprite emptyInventory;
    public TMP_Text coinsText;
    public Image healthBar;
    private Vector2 healthBarOrigSize;

    //Singleton
    private static NewPlayer instance;
    public static NewPlayer Instance
    {
        get
        {
            if (instance == null) instance = GameObject.FindObjectOfType<NewPlayer>();
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start(){
        healthBarOrigSize = healthBar.rectTransform.sizeDelta;
        direction = new Vector2(1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal") * maxSpeed, 0);

        if (Input.GetButtonDown("Jump") && grounded) {
            velocity.y = jumpHeight;
        }
        
        if (Input.GetButtonDown("Fire1")){
            StartCoroutine("ActivateAttack");
        }

        //flip player based on direction
        if (targetVelocity.x < -.01) {
            direction = new Vector2(-1, 1);
        } 
        else if (targetVelocity.x > 0.01){
            direction = new Vector2(1, 1);
        }
        transform.localScale = direction;
        if (health <= 0){
            Die();
        }

        
    }

    public void UpdateUI(){
        coinsText.text = coinsCollected.ToString();

        //set health bar width to percentage of original value player health
        float newHealth = healthBarOrigSize.x * ((float)health / (float)maxHealth);
        healthBar.rectTransform.sizeDelta = new Vector2(newHealth, healthBar.rectTransform.sizeDelta.y);
    }

    public void AddInventoryItem(string name, Sprite sprite){
        inventory.Add(name, sprite);
        inventoryItemImage.sprite = inventory[name];
    }

    public void RemoveInventoryItem(string name){
        inventory.Remove(name);
        inventoryItemImage.sprite = emptyInventory;
    }

    private IEnumerator ActivateAttack(){
        attackBox.SetActive(true);
        yield return new WaitForSeconds(.2f);
        attackBox.SetActive(false);
    }

    public void Die(){
        SceneManager.LoadScene("FirstLevel");
    }
}
