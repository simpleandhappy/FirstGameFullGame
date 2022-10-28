using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewPlayer : PhysicsObject
{
    [SerializeField] private float maxSpeed = 3f;
    [SerializeField] private float jumpHeight = 7f;
    public int maxHealth = 1000;
    public int coinsCollected;
    public int health;
    public List<string> upgrades;

    //UI
    public TMP_Text coinsText;
    public Image healthBar;
    private Vector2 healthBarOrigSize;

    // Start is called before the first frame update
    void Start(){
        healthBarOrigSize = healthBar.rectTransform.sizeDelta;
    }

    // Update is called once per frame
    void Update()
    {
        targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal") * maxSpeed, 0);

        if (Input.GetButtonDown("Jump") && grounded) {
            velocity.y = jumpHeight;
        }
    }

    public void UpdateUI(){
        coinsText.text = coinsCollected.ToString();

        //set health bar width to percentage of original value player health
        float newHealth = healthBarOrigSize.x * ((float)health / (float)maxHealth);
        healthBar.rectTransform.sizeDelta = new Vector2(newHealth, healthBar.rectTransform.sizeDelta.y);
    }
}
