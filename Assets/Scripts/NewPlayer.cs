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

    void Awake(){
        if (GameObject.Find("NewPlayer")) Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start(){
        DontDestroyOnLoad(gameObject);
        gameObject.name = "NewPlayer";
        transform.position = GameObject.Find("SpawnPoint").transform.position;
        
        GameManager.Instance.healthBarOrigSize = GameManager.Instance.healthBar.rectTransform.sizeDelta;
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
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
        GameManager.Instance.coinsText.text = coinsCollected.ToString();

        //set health bar width to percentage of original value player health
        float newHealth = GameManager.Instance.healthBarOrigSize.x * ((float)health / (float)maxHealth);
        GameManager.Instance.healthBar.rectTransform.sizeDelta = new Vector2(newHealth, GameManager.Instance.healthBar.rectTransform.sizeDelta.y);
    }

    public void AddInventoryItem(string name, Sprite sprite){
        inventory.Add(name, sprite);
        GameManager.Instance.inventoryItemImage.sprite = inventory[name];
    }

    public void RemoveInventoryItem(string name){
        inventory.Remove(name);
        GameManager.Instance.inventoryItemImage.sprite = GameManager.Instance.emptyInventory;
    }

    private IEnumerator ActivateAttack(){
        attackBox.SetActive(true);
        yield return new WaitForSeconds(.2f);
        attackBox.SetActive(false);
    }

    public void Die(){
        transform.position = GameObject.Find("SpawnPoint").transform.position;
        health = maxHealth;
        coinsCollected = 0;
        UpdateUI();
    }
}
