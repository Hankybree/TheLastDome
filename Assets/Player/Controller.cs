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
    private Player player;
    private bool canPlant = true;
    private bool isPlantCooldown = false;

    #region Unity Functions
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        inventory  = GetComponent<Inventory>();
        player     = GetComponent<Player>();
    }

    private void Update()
    {
        HandleClick();
        MovePlayer();
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        canPlant = CanPlant(other.tag, canPlant);
    }

    private void OnTriggerExit(Collider other)
    {
        canPlant = CanPlant(other.tag, canPlant);
    }
    */
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
            if (Physics.Raycast(ray, out hit, 100, Masks.interactable))
            {
                string     tag           = hit.collider.tag;
                float      distance      = Vector3.Distance(hit.point, transform.position);
                Vector3    clickPos      = hit.point;
                GameObject clickedObject = hit.collider.gameObject;

                print(tag);
                print(distance);
                print(clickPos);

                ParseClick(tag, distance, clickPos, clickedObject);
            }
        }
    }

    private void ParseClick(string tag, float distance, Vector3 clickPos, GameObject clickedObject)
    {
        switch (tag)
        {
            case Tags.furnace:
                UseFurnace(distance);
                break;
            case Tags.tree:
                StartCoroutine(ChopDownTree(distance, clickedObject));
                break;
            case Tags.ground:
                PlantTree(distance, clickPos);
                break;
            case Tags.enemy:
                AttackEnemy();
                break;
            default:
                return;
        }
    }

    private void UseFurnace(float distance)
    {
        if (distance < player.Range)
        {
            furnace.HeatDome(inventory);
        }
    }

    private void PlantTree(float distance, Vector3 clickPos)
    {
        if (distance < (player.Range + player.ExtraPlantRange) && inventory.Wood > 0 && canPlant && !isPlantCooldown)
        {
            StartCoroutine(StartPlantCooldown());
            inventory.Wood -= 1;
            dome.AddTree(tree, clickPos);
        }
    }

    private IEnumerator ChopDownTree(float distance, GameObject tree)
    {
        if (distance < player.Range)
        {
            GameObject treeParent = tree.transform.parent.gameObject;
            TreeAnimations treeAnim = tree.transform.GetChild(0).gameObject.GetComponent<TreeAnimations>();
            Tree treeComponent = treeParent.GetComponent<Tree>();
            if (treeComponent.GrownUp)
            {
                tree.GetComponent<BoxCollider>().enabled = false;
                treeAnim.ChopAnimation();
                yield return new WaitForSeconds(treeAnim.AnimationTime);
                inventory.Wood += treeComponent.Wood;
                dome.RemoveTree(treeParent);
            }
        }
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
