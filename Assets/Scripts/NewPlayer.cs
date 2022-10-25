using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayer : PhysicsObject
{
    [SerializeField] private float maxSpeed = 3f;
    [SerializeField] private float jumpHeight = 7f;
    public int coinsCollected;
    public int health;
    public List<string> upgrades;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal") * maxSpeed, 0);

        if (Input.GetButtonDown("Jump") && grounded) {
            velocity.y = jumpHeight;
        }
    }
}
