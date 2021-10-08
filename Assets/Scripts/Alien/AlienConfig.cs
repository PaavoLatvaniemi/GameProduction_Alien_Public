using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Alien Config", menuName = "Alien/Alien Config")]
public class AlienConfig : ScriptableObject
{
    public bool canKillPlayer = true;
    [Range(1f, 10f), Tooltip("Speed multiplier for target tracking")]
    public float lookRotationSpeed = 2f;
    [Range(1f, 7f), Tooltip("Used for animation blending")]
    public float maxMovementSpeed = 7f;
    [Range(1f, 7f)]
    public float walkMovementSpeed = 3f;
    [Range(1f, 7f)]
    public float investigateMovementSpeed = 3f;
    [Header("Chase")]
    [Tooltip("The minimum distance needed to escape the chase")]
    public float minEscapeDistance = 5f;
    [Range(1f, 7f)]
    public float chaseMovementSpeed = 7f;
    [Header("Hunt")]
    [Tooltip("A higher value makes the instinct of the target position more accurate")]
    public float huntInstinct = 4f;
    [Range(1f, 7f)]
    public float huntMovementSpeed = 7f;
}
