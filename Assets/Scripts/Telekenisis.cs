using UnityEngine;

public class Telekenisis : MonoBehaviour
{
    public LayerMask telekinesisLayer;
    public float pickUpRange = 10f;
    public float moveSpeed = 10f;
    public float scrollSpeed = 5f;

    private Transform pickedUpObject;
    private Rigidbody pickedUpRigidbody;
    private Item pickedUpSoundEmitter;
    private float objectDistance;


    // Handles input for picking up and dropping objects, and moves the picked-up object with the camera
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (pickedUpObject == null)
            {
                TryPickUpObject();
            }
            else
            {
                DropObject();
            }
        }

        if (pickedUpObject != null)
        {
            MoveObjectWithCamera();
            AdjustObjectDistance();
        }
    }

    // Performs a raycast to pick up an object with the telekinesis layer and within the range
    void TryPickUpObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, pickUpRange, telekinesisLayer))
        {
            pickedUpObject = hit.transform;
            pickedUpRigidbody = pickedUpObject.GetComponent<Rigidbody>();
            pickedUpSoundEmitter = pickedUpObject.GetComponent<Item>();

            if (pickedUpRigidbody != null)
            {
                pickedUpRigidbody.useGravity = false;
                pickedUpRigidbody.linearVelocity = Vector3.zero;
                pickedUpRigidbody.angularVelocity = Vector3.zero;
            }

            if (pickedUpSoundEmitter != null)
            {
                pickedUpSoundEmitter.ResetFallDetection();
            }

            objectDistance = Vector3.Distance(Camera.main.transform.position, pickedUpObject.position);
        }
    }


    // Drops the currently picked-up object and resets its state
    void DropObject()
    {
        if (pickedUpRigidbody != null)
        {
            pickedUpRigidbody.useGravity = true;
            pickedUpRigidbody = null;
        }

        if (pickedUpSoundEmitter != null)
        {
            pickedUpSoundEmitter.EmitSound();
            pickedUpSoundEmitter = null;
        }

        pickedUpObject = null;
    }

    // Moves the picked-up object to follow the camera's position
    void MoveObjectWithCamera()
    {
        Vector3 newPosition = Camera.main.transform.position + Camera.main.transform.forward * objectDistance;
        pickedUpRigidbody.MovePosition(Vector3.Lerp(pickedUpObject.position, newPosition, moveSpeed * Time.deltaTime));
    }

    // Adjusts the distance of the picked-up object based on mouse scroll input
    void AdjustObjectDistance()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        objectDistance += scroll * scrollSpeed;
        objectDistance = Mathf.Clamp(objectDistance, 2f, 20f); 
    }
}