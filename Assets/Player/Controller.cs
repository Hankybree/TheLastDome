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

    private Inventory inventory;
    private bool canPlant = true;
    private const string treeTag = "Tree";

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        inventory  = GetComponent<Inventory>();
    }

    private void Update()
    {
        MovePlayer();
        UseFurnace();
        PlantTree();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == treeTag)
        {
            canPlant = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == treeTag)
        {
            canPlant = true;
        }
    }

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
        if (Input.GetKeyDown(KeyCode.Q) && inventory.Wood > 0 && canPlant)
        {
            inventory.Wood -= 1;
            Instantiate(tree, new Vector3(transform.position.x, 0, transform.position.z + 1), Quaternion.identity);
            dome.NumberOfTrees += 1;
        }
    }
}
