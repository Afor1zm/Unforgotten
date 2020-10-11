using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public float Health { get; set; }
    public float CurrentHealth { get; set; }
    public int Damage { get; set; }
    public int Score { get; set; }
    public bool OnAttackPosition { get; set; }    
    public SpriteRenderer SpriteRenderer { get; set; }
}
