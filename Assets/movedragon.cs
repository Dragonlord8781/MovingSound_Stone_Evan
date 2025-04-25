using UnityEngine;
using System.Collections;

public class movedragon : MonoBehaviour
{
    public float movSpeed = 3f;
    public float switchTime = 10f; // Duration to stay in one direction (changeable)

    private bool isRotating = false;
    private string currentDirection = "north";

    void Start()
    {
        StartCoroutine(DirectionCycle());
    }

    void Update()
    {
        // Move in the current direction
        switch (currentDirection)
        {
            case "north":
                transform.Translate(-movSpeed * Time.deltaTime, 0f, 0f, Space.World);
                break;
            case "south":
                transform.Translate(movSpeed * Time.deltaTime, 0f, 0f, Space.World);
                break;
            case "east":
                transform.Translate(0f, 0f, movSpeed * Time.deltaTime, Space.World);
                break;
            case "west":
                transform.Translate(0f, 0f, -movSpeed * Time.deltaTime, Space.World);
                break;
        }
    }

    IEnumerator DirectionCycle()
    {
        while (true)
        {
            yield return StartCoroutine(SwitchDirection("north", 270));
            yield return StartCoroutine(SwitchDirection("east", 0));
            yield return StartCoroutine(SwitchDirection("south", 90));
            yield return StartCoroutine(SwitchDirection("west", 180));
        }
    }

    IEnumerator SwitchDirection(string direction, float rotation)
    {
        currentDirection = direction;
        yield return StartCoroutine(RotateToAngle(rotation));
        yield return new WaitForSeconds(switchTime); // Wait before switching to next direction
    }

    IEnumerator RotateToAngle(float targetAngle)
    {
        isRotating = true;

        float startAngle = transform.rotation.eulerAngles.y;
        float endAngle = targetAngle;

        if (Mathf.Abs(endAngle - startAngle) > 180)
        {
            if (endAngle > startAngle)
                endAngle -= 360;
            else
                startAngle -= 360;
        }

        float elapsedTime = 0f;
        float duration = 0.5f; // Smooth rotation time

        while (elapsedTime < duration)
        {
            float newAngle = Mathf.LerpAngle(startAngle, endAngle, elapsedTime / duration);
            transform.rotation = Quaternion.Euler(-90f, newAngle, 0f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = Quaternion.Euler(-90f, endAngle, 0f);
        isRotating = false;
    }
}

