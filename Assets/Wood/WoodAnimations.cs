using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodAnimations : MonoBehaviour
{
    [SerializeField] float updatedRotation = 100;

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(new Vector3(0, updatedRotation * Time.deltaTime, 0));
    }
}
