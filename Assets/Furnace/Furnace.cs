using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnace : MonoBehaviour
{
    [SerializeField] Dome dome;
    [SerializeField] int oxygenReduction = 3;
    [SerializeField] int temperatureIncrease = 5;

    public void HeatDome(Inventory inventory)
    {
        if (inventory.Wood > 0)
        {
            dome.Temperature += temperatureIncrease;
            dome.Oxygen -= oxygenReduction;
            inventory.Wood--;
        }
    }
}
