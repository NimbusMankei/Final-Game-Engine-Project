using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerStats P1Stats;
    bool readyToJump;
    public AudioSource footStepsSounds;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    //Health&Inventory
    PlayerInventoryStats PI;

    private EventInstance footsteps;

    


    private void Awake()
    {
        PI = GetComponent<PlayerInventoryStats>();

    }

    private void Start()
    {
        footsteps = AudioManager.instance.CreateEventInstance(FMODEvents.instance.Steps);

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;
    }

    private void Update()
    {
        //checkforground
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        SpeedControl();

        //playerdrag
        if (grounded)
        {
            rb.linearDamping = P1Stats.groundDrag;
            UpdateSound();
        }
        else
        {
            rb.linearDamping = 0;
        }
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (grounded) {

                UpdateSound();

            }
                
            

        }
        else
                footStepsSounds.enabled = false;

        if (Input.GetKey(KeyCode.Q))
        {
            UnlockMouse();
        }

        if (Input.GetKey(KeyCode.P))
        {
            PI.TakeDamage(2);
        }

        if (Input.GetKey(KeyCode.O))
        {
            RestoreHealth();
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();

        UpdateSound();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //jump:3
        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();
            SoundManager.PlaySound(SoundType.Jump);

            Invoke(nameof(ResetJump), P1Stats.jumpCooldown);
        }
    }
    
    void RestoreHealth()
    {
        if(Inventory.inventory.consumableItemsController.GetItem("HealthPill").GetOwnedQuantity() != 0)
        {
            Inventory.inventory.consumableItemsController.UseItem("HealthPill");
        }
    }

    private void MovePlayer()
    {
        //movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (grounded) //onground
            rb.AddForce(moveDirection.normalized * P1Stats.moveSpeed * 10f, ForceMode.Force);
        else if (!grounded) //inair
            rb.AddForce(moveDirection.normalized * P1Stats.moveSpeed * 10f * P1Stats.airMultiplier, ForceMode.Force);
            
    }

    private void SpeedControl() 
    {
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        //limitspeed
        if(flatVel.magnitude > P1Stats.moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * P1Stats.moveSpeed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        //makesureverticalvelociyis0
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        rb.AddForce(transform.up * P1Stats.jumpForce, ForceMode.Impulse);
        AudioManager.instance.PlayOneShot(FMODEvents.instance.Jump, this.transform.position);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }

    void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void UpdateSound()
    {
        if(grounded)
        {
            PLAYBACK_STATE playbackstate;
            footsteps.getPlaybackState(out playbackstate);
            if (playbackstate.Equals(PLAYBACK_STATE.STOPPED))
            {
                footsteps.start();
            }
            else {

                footsteps.stop(STOP_MODE.ALLOWFADEOUT);
            }

        }
    }
}
