using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnace : MonoBehaviour
{
    [SerializeField] GameObject dome;

    public void HeatDome(Inventory inventory)
    {
        if (inventory.Wood > 0)
        {
            dome.GetComponent<Dome>().Temperature += 5;
            inventory.Wood--;
        }
    }
}
