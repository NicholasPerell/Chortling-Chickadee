using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayerMouse : MonoBehaviour
{
    PlayerControls controls;
    void Awake()
    {
        controls = new PlayerControls();
        controls.Player.MousePos.performed += ctx => CheckInput(ctx.ReadValue<Vector2>());
        controls.Player.MousePos.started += ctx => CheckInput(ctx.ReadValue<Vector2>());
        controls.Player.MousePos.canceled += ctx => CheckInput(ctx.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        controls.Player.Enable();
        controls.Player.MousePos.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
        controls.Player.MousePos.Disable();
    }

    Vector3 mosPos;
    void CheckInput(Vector2 pos)
    {
        mosPos = pos;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0,0,-Vector2.SignedAngle(Camera.main.ScreenToWorldPoint(mosPos) - transform.position,Vector2.right)));
//        transform.LookAt(Camera.main.ScreenToWorldPoint(mosPos), new Vector3(0,0,1));
    }
}
