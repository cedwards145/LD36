using UnityEngine;
using System.Collections;

public class Machine : MonoBehaviour
{
    public int maxHealth = 1000;
    public int currentHealth;
    public int unitsToCharge = 1000;
    public float unitsCharged = 0;
    public float chargePerSecond = 1f;

    // Use this for initialization
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        unitsCharged += chargePerSecond * Time.deltaTime;
    }
}
