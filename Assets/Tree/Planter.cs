using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planter : MonoBehaviour
{
    [SerializeField] float startScale;
    [SerializeField] float growthRatio;
    private float currentScale;
    
    void Start()
    {
        if (!gameObject.GetComponentInParent<Tree>().GrownUp)
        {
            transform.localScale = new Vector3(startScale, startScale, startScale);
        }
    }

    void Update()
    {
        if (transform.localScale.x < 1)
        {
            currentScale += growthRatio;
            transform.localScale = new Vector3(currentScale, currentScale, currentScale);
        }
        else
        {
            gameObject.GetComponentInParent<Tree>().GrownUp = true;
        }
    }
}
