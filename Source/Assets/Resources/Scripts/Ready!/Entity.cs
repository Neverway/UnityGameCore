//======== Neverway 2022 Project Script | Written by Arthur Aka Liz ===========
// 
// Purpose: Manages an entity's health, movement, and speed in a game
// Applied to: The root of an entity
//
//=============================================================================

using System.Collections;
using Unity.Netcode;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Entity : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    [Tooltip("The scriptable object the defines the possessing controller of this entity")]
    public Entity_Brain brain;
    [Tooltip("The scriptable object the defines this entity's stats")]
    public Entity_Stats stats;

    
    //=-----------------=
    // Private Variables
    //=-----------------=
    [Header("Read-Only")]
    public float currentSpeed;
    public Vector2 moveDirection;
    public Vector2 faceDirection;
    public bool paused;
    public float currentHealth;
    public Entity target;
    private Vector2 storedMoveDirection; // used to restore momentum when un-pausing the entity
    private float storedAnimationSpeed; // used to restore animation when un-pausing the entity
    private bool invulnerable;


    //=-----------------=
    // Reference Variables
    //=-----------------=
    private Rigidbody2D entityRigidbody;
    private Animator animator;
    private static readonly int MoveX = Animator.StringToHash("MoveX");
    private static readonly int MoveY = Animator.StringToHash("MoveY");
    private static readonly int LastX = Animator.StringToHash("LastX");
    private static readonly int LastY = Animator.StringToHash("LastY");
    public NetworkObject netObject;
    private Net_Entity_Data netEntity;
    public GameObject interactPrefab;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Awake()
    {
        if (brain) brain.EntityAwake(this);
        
        // Get references
        entityRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        netObject = GetComponent<NetworkObject>();
        netEntity = GetComponent<Net_Entity_Data>();
        
        // Set initial values (I'm not sure this should stay here)
        currentSpeed = stats.walkSpeed;
        currentHealth = stats.maxHealth;
    }

    private void Update()
    {
        if (stats.animationController) animator.runtimeAnimatorController = stats.animationController;
        if (!brain) 
        { 
          //Debug.LogWarning("The brain.Think function is trying to be called, but there's no brain component applied to this entity!", this);
          return;
        }
        if (!paused) brain.Think(this);
    }

    private void FixedUpdate()
    {
        UpdateMovement();
    }
    
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    private void UpdateMovement()
    {
        // Update object position
        var position = transform.position;
        entityRigidbody.MovePosition(position + new Vector3(moveDirection.x, moveDirection.y, position.z) * (currentSpeed * Time.fixedDeltaTime));
        
        // Set current movement to animator
        if (animator)
        {
            if (netObject && !netObject.IsOwner) return;
            animator.SetFloat(MoveX, moveDirection.x);
            animator.SetFloat(MoveY, moveDirection.y);
            if (moveDirection.x != 0 || moveDirection.y != 0) { faceDirection = moveDirection; }
            animator.SetFloat(LastX, faceDirection.x);
            animator.SetFloat(LastY, faceDirection.y);
        }
    }
    
    private IEnumerator DamageCooldown()
    {
        yield return new WaitForSeconds(stats.invulnerabilityDuration);
        invulnerable = false;
    }
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
    /// <summary>
    /// Sets the movement direction of the entity to the specified Vector2.
    /// </summary>
    /// <param name="_movement">The direction to move the entity in.</param>
    public void SetMovement(Vector2 _movement)
    {
        moveDirection = _movement;
    }
    
    /// <summary>
    /// Sets the entity's current speed to either their run speed or walk speed, based on whether or not they are sprinting.
    /// </summary>
    /// <param name="_isSprinting">Whether or not the entity is currently sprinting.</param>
    public void SetSprinting(bool _isSprinting)
    {
        currentSpeed = _isSprinting ? stats.runSpeed : stats.walkSpeed;
    }
    
    /// <summary>
    /// Adds the specified value to the current health, clamps the result to the health range,
    /// and starts a damage cooldown coroutine if applicable. If the value is negative, plays a
    /// "Hurt" animation and sets the character as invulnerable. If the value is positive, plays
    /// a "Heal" animation and sets the character as invulnerable.
    /// </summary>
    /// <param name="_value">The value to add to the current health</param>
    public void AddHealth(float _value)
    {
        if (invulnerable) return;
        switch (_value)
        {
            case < 0 when animator:
                animator.Play("Hurt");
                invulnerable = true;
                break;
            case > 0 when animator:
                animator.Play("Heal");
                invulnerable = true;
                break;
        }

        // Modify the health value, then clamp the result to the health range
        currentHealth += _value;
        currentHealth = Mathf.Clamp(currentHealth, 0f, stats.maxHealth);
        StartCoroutine("DamageCooldown");
    }
    
    /// <summary>
    /// Pauses the entity by storing and freezing its current animation and movement.
    /// </summary>
    public void Pause()
    {
        // Store an freeze entity animation
        if (animator)
        {
            storedAnimationSpeed = animator.speed;
            animator.enabled = false;
        }
        // Store and freeze entity movement
        storedMoveDirection = moveDirection;
        SetMovement(new Vector2(0, 0));
        paused = true;
    }
    
    /// <summary>
    /// Resumes the entity's movement and animation from the paused state, restoring the previously saved animation speed
    /// and movement direction.
    /// </summary>
    public void Unpause()
    {
        // Store an freeze entity animation
        if (animator)
        {
            animator.speed = storedAnimationSpeed;
            animator.enabled = true;
        }
        // Store and freeze entity movement
        SetMovement(storedMoveDirection);
        paused = false;
    }
    
    /// <summary>
    /// Determines the direction the entity is facing, and calculates the directional rotation for the interaction.
    /// The function then instantiates an interaction prefab in that direction or sends an interaction request over the network, if the entity is networked.
    /// </summary>
    public void Interact()
    {
        // Get Interaction direction
        int directionalRotation = 0;

        switch (faceDirection.x)
        {
            case 1:
                directionalRotation = -90; 
                print("Right");
                break;
            case -1:
                directionalRotation = 90; 
                print("Left");
                break;
        }
        
        switch (faceDirection.y)
        {
            case 1:
                directionalRotation = 0; 
                print("Up");
                break;
            case -1:
                directionalRotation = 180; 
                print("Down");
                break;
        }

        print(directionalRotation);
        if (netEntity) netEntity.InteractServerRPC(NetworkManager.Singleton.LocalClientId, directionalRotation);
        else Instantiate(interactPrefab, transform.position, Quaternion.Euler(0, 0, directionalRotation));
    }
}

