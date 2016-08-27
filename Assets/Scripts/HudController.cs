using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HudController : MonoBehaviour
{
    private PlayerController player;
    public Slider healthSlider;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        healthSlider.maxValue = player.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = player.currentHealth;
    }
}
