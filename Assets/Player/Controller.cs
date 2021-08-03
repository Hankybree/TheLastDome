using System;
using System.Collections;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed;
    [SerializeField] Vector3 cameraOffset;
    private CharacterController controller;

    [Header("Interactions")]
    [SerializeField] Furnace furnace;
    [SerializeField] GameObject tree;
    [SerializeField] Dome dome;
    [SerializeField] float plantCooldown;

    private Inventory inventory;
    private bool canPlant = true;
    private bool isPlantCooldown = false;

    #region Unity Functions
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        inventory  = GetComponent<Inventory>();
    }

    private void Update()
    {
        HandleClick();
        MovePlayer();
        UseFurnace();
        PlantTree();
    }

    private void OnTriggerEnter(Collider other)
    {
        canPlant = CanPlant(other.tag, canPlant);
    }

    private void OnTriggerExit(Collider other)
    {
        canPlant = CanPlant(other.tag, canPlant);
    }
    #endregion

    #region Movement
    private void MovePlayer()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * moveSpeed);

        MoveCamera();
    }

    private void MoveCamera()
    {
        Camera.main.transform.position = transform.position + cameraOffset;
    }
    #endregion

    #region Interactions
    private void HandleClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100, Mask.interactable))
            {
                print(hit.collider.tag);
                print(Vector3.Distance(hit.point, transform.position));
            }
        }
    }

    private void UseFurnace()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float distanceY = furnace.transform.position.z - transform.position.z;

            if (distanceY < 2.5f)
            {
                furnace.HeatDome(inventory);
            }
        }
    }

    private void PlantTree()
    {
        if (Input.GetKeyDown(KeyCode.Q) && inventory.Wood > 0 && canPlant && !isPlantCooldown)
        {
            StartCoroutine(StartPlantCooldown());
            inventory.Wood -= 1;
            dome.PlantTree(tree, new Vector3(transform.position.x, 0, transform.position.z + 1));
        }
    }

    private void ChopDownTree()
    {

    }

    private void AttackEnemy()
    {

    }
    #endregion

    #region Rules
    private bool CanPlant(string tag, bool currentState)
    {
        if (tag == Tags.tree || tag == Tags.furnace)
        {
            return !currentState;
        }

        return currentState;
    }

    private IEnumerator StartPlantCooldown()
    {
        isPlantCooldown = true;
        yield return new WaitForSeconds(plantCooldown);
        isPlantCooldown = false;
    }
    #endregion
}
