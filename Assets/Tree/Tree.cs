using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] bool grownUp = false;
    [SerializeField] double oxygenEmission = 0.1;
    [SerializeField] float oxygenTicks = 1;

    private Dome dome;

    public bool GrownUp
    {
        get
        {
            return grownUp;
        }
        set
        {
            grownUp = value;
        }
    }

    private void Start()
    {
        dome = FindObjectOfType<Dome>();
        InvokeRepeating(nameof(EmitOxygen), oxygenTicks, oxygenTicks);
    }

    private void EmitOxygen()
    {
        if (grownUp)
        {
            dome.Oxygen += oxygenEmission;
        }
    }
}
