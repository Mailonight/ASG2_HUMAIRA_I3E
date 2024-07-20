using UnityEngine;
using System.Collections; // Add this line to include System.Collections namespace

public class DoorController : MonoBehaviour
{
    public float openAngle = 90.0f; // Angle by which the door will rotate when opened
    public float openSpeed = 2.0f; // Speed at which the door opens and closes

    private bool isOpen = false;
    private bool isMoving = false;

    void Update()
    {
        if (isMoving)
            return;

        if (Input.GetKeyDown(KeyCode.E) && isOpen == false)
        {
            StartCoroutine(OpenDoor(transform.rotation, Quaternion.Euler(0, openAngle, 0)));
        }
        else if (Input.GetKeyDown(KeyCode.E) && isOpen == true)
        {
            StartCoroutine(OpenDoor(transform.rotation, Quaternion.Euler(0, 0, 0)));
        }
    }

    IEnumerator OpenDoor(Quaternion startRotation, Quaternion endRotation)
    {
        isMoving = true;
        float t = 0.0f;
        while (t < 1.0f)
        {
            t += Time.deltaTime * openSpeed;
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
            yield return null;
        }
        isOpen = !isOpen;
        isMoving = false;
    }
}