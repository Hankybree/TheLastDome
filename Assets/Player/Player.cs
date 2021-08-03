using System.Collections;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] GameObject healthBar;

    [Header("Stats")]
    [SerializeField] int health = 100;
    [SerializeField] float range = 1.5f;

    [Header("Other")]
    [SerializeField] Dome dome;
    [SerializeField] float healthTicks = 1f;

    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
            healthBar.GetComponent<TextMeshProUGUI>().text = "Health: " + health;
        }
    }
    public float Range
    {
        get
        {
            return range;
        }
    }

    private void Start()
    {
        InvokeRepeating(nameof(TakeDamage), healthTicks, healthTicks);
    }

    private void TakeDamage()
    {
        if (dome.Temperature < 0 || dome.Temperature > 30 || dome.Oxygen < 0)
        {
            Health -= 1;
        }
    }
}
