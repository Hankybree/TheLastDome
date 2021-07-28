using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnace : MonoBehaviour
{
    [SerializeField] Dome dome;

    public void HeatDome(Inventory inventory)
    {
        if (inventory.Wood > 0)
        {
            dome.Temperature += 5;
            inventory.Wood--;
        }
    }
}
