using UnityEngine;

public class MouseLookAround : MonoBehaviour
{
    float rotationX = 0f;
    float rotationY = 0f;

    public float sensetivity = 10f;

    void Update()
    {
        rotationY += Input.GetAxis("Mouse X") * sensetivity;
        rotationX += Input.GetAxis("Mouse Y") * -1 * sensetivity;
        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
    }
}
