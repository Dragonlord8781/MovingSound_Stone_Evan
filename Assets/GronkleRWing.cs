using UnityEngine;

public class GronkleRWing : MonoBehaviour
{
    //sets up stuff to change
    public float speed = 100f;
    public bool rotatingLeft;
    public float startDelay;
    public float repeatTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rotatingLeft = true;
        InvokeRepeating("Flip", startDelay, repeatTime);
    }

    //rotatingLeft = not rotatingLeft
    void Flip()
    {
        rotatingLeft = !rotatingLeft;
    }

    // Update is called once per frame
    void Update()
    {
        // if within -77 and 36 the wings are supposed to move, have back up statements where wings move based on time
        if (transform.rotation.z < -76.977f && rotatingLeft == true)
        {
            transform.Rotate(0f, 0f, -speed * Time.deltaTime, Space.Self);
            rotatingLeft = false;
        }
        else if (transform.rotation.z > 35.641f && rotatingLeft == false)
        {
            transform.Rotate(0f, 0f, speed * Time.deltaTime, Space.Self);
            rotatingLeft = true;
        }
        else if (rotatingLeft)
        {
            transform.Rotate(0f, 0f, speed * Time.deltaTime, Space.Self);
        }
        else if (rotatingLeft == false)
        {
            transform.Rotate(0f, 0f, -speed * Time.deltaTime, Space.Self);
        }

    }
        
}
