using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeAnimations : MonoBehaviour
{
    [Header("Plant")]
    [SerializeField] float startScale;
    [SerializeField] float growthRatio;
    private float currentScale;

    [Header("Chop")]
    [SerializeField] float animationTime = 1;
    private Animation anim;

    public float AnimationTime
    {
        get
        {
            return animationTime;
        }
    }

    private void Start()
    {
        anim = GetComponent<Animation>();

        if (!gameObject.GetComponentInParent<Tree>().GrownUp)
        {
            transform.localScale = new Vector3(startScale, startScale, startScale);
        }
    }

    private void Update()
    {
        PlantAnimation();
    }

    private void PlantAnimation()
    {
        if (transform.localScale.x < 1)
        {
            currentScale += growthRatio * Time.deltaTime;
            transform.localScale = new Vector3(currentScale, currentScale, currentScale);
        }
        else
        {
            gameObject.GetComponentInParent<Tree>().GrownUp = true;
        }
    }

    public void ChopAnimation()
    {
        anim.Play();
    }
}
