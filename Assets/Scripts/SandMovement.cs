using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandMovement : MonoBehaviour
{
    public float speed;
    public float turningSpeed;
    Vector2 direction;

    Vector2 inputDir;

    // Start is called before the first frame update
    void Start()
    {
        direction = Vector2.right;
    }

    // Update is called once per frame
    void Update()
    {
        inputDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //direction = inputDir;
    }

    private void FixedUpdate()
    {
        if (inputDir.sqrMagnitude > 0.1f)
        {
            float angleDiff = Vector2.SignedAngle(direction, inputDir);
            float turning = turningSpeed * Time.fixedDeltaTime;
            if (Mathf.Abs(turning) > Mathf.Abs(angleDiff)) turning = angleDiff;
            else if (angleDiff < 0) turning *= -1;

            direction = Quaternion.Euler(0, 0, turning) * direction;
        }

        Vector2 vel = direction.normalized * speed * Time.fixedDeltaTime;
        transform.position += new Vector3(vel.x, vel.y, transform.position.z);
    }
}
