using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] bool grownUp = false;
    [SerializeField] double oxygenEmission = 0.1;
    [SerializeField] float oxygenTicks = 1;
    [SerializeField] GameObject woodObject;
    [SerializeField] int minWood = 1;
    [SerializeField] int maxWood = 3;
    private int wood;

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
    public int Wood
    {
        get
        {
            return wood;
        }
    }

    private void Start()
    {
        dome = FindObjectOfType<Dome>();
        wood = Random.Range(minWood, maxWood + 1);
        InvokeRepeating(nameof(EmitOxygen), oxygenTicks, oxygenTicks);
    }

    private void EmitOxygen()
    {
        if (grownUp)
        {
            dome.Oxygen += oxygenEmission;
        }
    }

    public void DropWood()
    {
        float posX = transform.position.x;
        float posY = transform.position.z;

        for (int i = 0; i < wood; i++)
        {
            float spawnX = Random.Range(posX - 2, posX + 2);
            float spawnY = Random.Range(posY - 2, posY + 2);

            Instantiate(woodObject, new Vector3(spawnX, 0, spawnY), Quaternion.identity);
        }
    }
}
