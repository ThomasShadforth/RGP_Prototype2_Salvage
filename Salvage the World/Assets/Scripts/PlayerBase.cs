using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{

    public static PlayerBase instance;

    Animator animator;
    Rigidbody2D rb;

    Vector3 moveInput;
    [Header("Movement Properties")]
    public float walkSpeedMult;
    public float sprintSpeedMult;
    [SerializeField]
    float speedMult;

    [SerializeField]
    bool isSprinting;

    [Header("Player Properties")]
    public int playerMaxHealth;
    [SerializeField]
    int playerHealth;
    public float staminaMax;
    [SerializeField]
    float playerStamina;
    public float staminaRate;
    

    // Start is called before the first frame update
    void Start()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        //animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        speedMult = walkSpeedMult;
        playerStamina = staminaMax;
        moveInput = Vector3.zero;
    }

    void FixedUpdate()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        if (isSprinting)
        {
            speedMult = sprintSpeedMult;
        }
        else
        {
            speedMult = walkSpeedMult;
        }

        moveInput.Normalize();

        
    }


    // Update is called once per frame
    void Update()
    {
        checkForSprint();
        if(isSprinting)
        {
            playerStamina -= 1 * staminaRate * Time.deltaTime;
        }
    }

    void LateUpdate()
    {
        //rb.MovePosition(transform.position + moveInput * speedMult * Time.deltaTime);

        rb.velocity = new Vector2(moveInput.x * speedMult, moveInput.y * speedMult);
    }



    void checkForSprint()
    {
        if (Input.GetButton("Sprint") && playerStamina > 0)
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }
    }
}
