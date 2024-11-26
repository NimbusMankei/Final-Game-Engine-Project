using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStuff", menuName = "ScriptableObject/PlayerStuff", order = 1)]
public class PlayerStats : ScriptableObject
{
    [field: Header("PlayerStuff")]
    [field: SerializeField] public float moveSpeed {get; private set;}
    [field: SerializeField] public float groundDrag {get; private set;}
    [field: SerializeField] public float jumpForce {get; private set;}
    [field: SerializeField] public float jumpCooldown {get; private set;}
    [field: SerializeField] public float airMultiplier {get; private set;}
    
}
