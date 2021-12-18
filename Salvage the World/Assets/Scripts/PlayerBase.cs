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

    public Salvage_Object objectInRange;
    [SerializeField]
    public Obstacle obstacleInRange;

    public string areaTransitionName;
    // Start is called before the first frame update
    void Start()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
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
        if (GamePause.GamePaused)
        {
            return;
        }
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

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
        if (GamePause.GamePaused)
        {
            return;
        }
        checkForSprint();
        if(isSprinting)
        {
            playerStamina -= 1 * staminaRate * GamePause.deltaTime;
        }
        checkForSalvageInput();
        checkForObstacleInteract();
        
    }

    void LateUpdate()
    {
        if (GamePause.GamePaused)
        {
            return;
        }
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

    void checkForSalvageInput()
    {
        if (objectInRange && !objectInRange.hasBeenSalvaged)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                objectInRange.isTimerActive = true;
            }

            if (objectInRange.isTimerActive)
            {
                if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
                {
                    objectInRange.resetTimer();
                }
            }
        }
    }
    void checkForObstacleInteract()
    {
        bool canDamage = false;
        if (obstacleInRange && GameManager.instance.itemManagerDB.selectedItem != null)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (GameManager.instance.itemManagerDB.selectedItem.isAxe)
                {
                    if (obstacleInRange.needsAxe)
                    {
                        canDamage = true;
                    }
                    else
                    {
                        canDamage = false;
                    }
                } else if (GameManager.instance.itemManagerDB.selectedItem.isPickaxe)
                {
                    if (obstacleInRange.needsPickaxe)
                    {
                        canDamage = true;
                    }
                    else
                    {
                        canDamage = false;
                    }
                } else if (GameManager.instance.itemManagerDB.selectedItem.isShovel)
                {
                    if (obstacleInRange.needsShovel)
                    {
                        canDamage = true;
                    }
                    else
                    {
                        canDamage = false;
                    }
                }

                if (canDamage)
                {
                    obstacleInRange.reduceHitCount(GameManager.instance.itemManagerDB.selectedItem.efficiency);
                }
                GameManager.instance.itemManagerDB.selectedItem.durability -= 1;
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("You can't break this with your bare hands! You need to craft a tool!");
            }
        }
    }
}
