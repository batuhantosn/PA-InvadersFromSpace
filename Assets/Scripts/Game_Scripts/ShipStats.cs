using UnityEngine;

[System.Serializable]

public class ShipStats
{
    [Range(1,5)]
    public int maxHealth;
    [HideInInspector]
    public int currentHealth;
    [HideInInspector]
    public int maxLife = 3;
    [HideInInspector]
    public int currenLifes = 3;

    public float shipSpeed;
    public static float fireRate = 0.7f;
}
