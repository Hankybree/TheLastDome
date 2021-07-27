using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnace : MonoBehaviour
{
    public void HeatDome(Inventory inventory)
    {
        if (inventory.Wood > 0)
        {
            Debug.Log("Temp + 5");
            inventory.Wood--;
        }
    }
}
