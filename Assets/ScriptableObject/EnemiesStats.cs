using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Enemies stats", menuName ="Enemies stats")]
public class EnemiesStats : ScriptableObject
{
    public int HealthToAdd { get; set; } = 2;

    //public float SpeedPercentageToAdd { get; set; }
}
