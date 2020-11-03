using UnityEngine;

public class Player : SingletonMonobehaviour<Player>
{
#pragma warning disable CS1072
#pragma warning disable CS0414
#pragma warning disable CS0108

    private float movementSpeed;
    public Rigidbody2D rigidbody2D;
#pragma warning restore CS1072
#pragma warning restore CS0414
#pragma warning restore CS0108

    //Player Animation
    private float xInput = 0;

    private float yInput = 0;

    // Start is called before the first frame update
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        PlayerMovementInput();
        PlayerWalkInput();
       // PlayerTestInput();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        Vector2 move = new Vector2(xInput * movementSpeed * Time.deltaTime, yInput * movementSpeed * Time.deltaTime);

        rigidbody2D.MovePosition(rigidbody2D.position + move);
    }

    private void PlayerWalkInput()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            movementSpeed = Settings.walkingSpeed;
        }
        else
        {
            movementSpeed = Settings.runningSpeed;
        }
    }

    private void PlayerMovementInput()
    {
        yInput = Input.GetAxisRaw("Vertical");
        xInput = Input.GetAxisRaw("Horizontal");

        if (yInput != 0 && xInput != 0)
        {
            xInput = xInput * 0.71f;
            yInput = yInput * 0.71f;
        }

        if (xInput != 0 || yInput != 0)
        {
            movementSpeed = Settings.runningSpeed;

            /*  // Capture player direction for save game
              if (xInput < 0)
              {
                  playerDirection = Direction.left;
              }
              else if (xInput > 0)
              {
                  playerDirection = Direction.right;
              }
              else if (yInput < 0)
              {
                  playerDirection = Direction.down;
              }
              else
              {
                  playerDirection = Direction.up;
              }*/
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("Trigger " + collision.name);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("Collision " + collision.gameObject.name);
    }

  
}