using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSwapScript : MonoBehaviour
{
    [SerializeField]
    private Transform shapeContainer;

    public GameObject[] shapes; // Array to hold all the shape prefabs
    private int currentShapeIndex = 0; // Index of the current shape - the player
    private bool isShifting = false;

    GameObject chickenObject;

    
    private void Awake()
    {

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShiftShape();
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with something");
        if (collision.collider.GetComponent<AvailableTransform>())
        {
            Debug.Log("Collided with a transform");
            // Get the transform component
            AvailableTransform availableTransform = collision.collider.GetComponent<AvailableTransform>();
            // Get the current transform
            AnimalTransform currentTransform = availableTransform.CurrentTransform;
            // Switch the player to the current transform
            //SwitchShape(currentTransform);

            var avaiableTransform = collision.collider.GetComponent<AvailableTransform>();

            for (int i = 0; i < shapes.Length; i++)
            {
                var shape = shapes[i];
                if (shape.GetComponent<AvailableTransform>().CurrentTransform == avaiableTransform.CurrentTransform)
                {
                    isShifting = true;
                    currentShapeIndex = i;
                    Invoke(nameof(ShiftShape), 2f);
                }
            }           
        }
    }
    public void OnCollisionExit()
    {
        if (isShifting)
        {
            isShifting = false;
            CancelInvoke(nameof(ShiftShape));
        }
    }
    public void ShiftShape()
    {
        //Get the position and rotation of the current player
        Vector3 currentPosition = transform.position;
        Quaternion currentRotation = transform.rotation;
        Destroy(shapeContainer.GetChild(0).gameObject);
        shapeContainer.DetachChildren();

        GameObject newShape = Instantiate(shapes[currentShapeIndex], currentPosition, currentRotation);
        newShape.transform.SetParent(shapeContainer);
        newShape.GetComponent<BoxCollider>().enabled = false;

        Debug.Log("Shape Shifted");
        currentShapeIndex++;
        if (currentShapeIndex >= shapes.Length)
        {
            currentShapeIndex = 0;
        }
        isShifting = false;
    }
}
