using UnityEngine;

public class Controller : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed;
    [SerializeField] Vector3 cameraOffset;
    private CharacterController controller;

    [Header("Other")]
    [SerializeField] GameObject furnace;
    private Inventory inventory;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        inventory  = GetComponent<Inventory>();
    }

    private void Update()
    {
        MovePlayer();
        UseFurnace();
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
                furnace.GetComponent<Furnace>().HeatDome(inventory);
            }
        }
    }
}
