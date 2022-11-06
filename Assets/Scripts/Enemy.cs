using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : PhysicsObject
{
    [SerializeField] private float maxSpeed;
    [SerializeField] private int attackPower = 100;

    private int direction = 1;
    private RaycastHit2D rightLedgeRaycastHit;
    private RaycastHit2D leftLedgeRaycastHit;
    private RaycastHit2D rightWallRaycastHit;
    private RaycastHit2D leftWallRaycastHit;

    [SerializeField] private Vector2 raycastOffset;
    [SerializeField] private float raycastLength = 1f;
    [SerializeField] private LayerMask raycastLayerMask;

    public int health = 100;
    private int maxHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        targetVelocity = new Vector2(maxSpeed * direction, 0);
    }

    // Update is called once per frame
    void Update()
    {
        LedgeCheck();
        WallCheck();
        targetVelocity = new Vector2(maxSpeed * direction, 0);

        if (health <= 0){
            gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject == NewPlayer.Instance.gameObject) {
            NewPlayer.Instance.health -= attackPower;
            NewPlayer.Instance.UpdateUI(); 
        }
    }

    private void LedgeCheck(){
        Vector2 rightRaycast2DPosition = new Vector2(transform.position.x + raycastOffset.x, transform.position.y + raycastOffset.y);
        Vector2 leftRaycast2DPosition = new Vector2(transform.position.x - raycastOffset.x, transform.position.y + raycastOffset.y);

        rightLedgeRaycastHit = Physics2D.Raycast(rightRaycast2DPosition, Vector2.down, raycastLength);
        Debug.DrawRay(rightRaycast2DPosition, Vector2.down * raycastLength, Color.green);
        leftLedgeRaycastHit = Physics2D.Raycast(leftRaycast2DPosition, Vector2.down, raycastLength);
        Debug.DrawRay(leftRaycast2DPosition, Vector2.down * raycastLength, Color.green);

        if (rightLedgeRaycastHit.collider == null){
            direction = -1;
        }
        if (leftLedgeRaycastHit.collider == null){
            direction = 1;
        }
    }

    private void WallCheck(){
        Vector2 rightWallRaycast2DPosition = new Vector2(transform.position.x, transform.position.y + raycastOffset.y);
        Vector2 leftWallRaycast2DPosition = new Vector2(transform.position.x, transform.position.y + raycastOffset.y);

        rightWallRaycastHit = Physics2D.Raycast(rightWallRaycast2DPosition, Vector2.right, raycastLength, raycastLayerMask);
        Debug.DrawRay(rightWallRaycast2DPosition, Vector2.right * raycastLength, Color.green);
        leftWallRaycastHit = Physics2D.Raycast(leftWallRaycast2DPosition, Vector2.left, raycastLength, raycastLayerMask);
        Debug.DrawRay(leftWallRaycast2DPosition, Vector2.left * raycastLength, Color.green);

        if (rightWallRaycastHit.collider != null){
            direction = -1;
        }
        if (leftWallRaycastHit.collider != null){
            direction = 1;
        }
    }
}