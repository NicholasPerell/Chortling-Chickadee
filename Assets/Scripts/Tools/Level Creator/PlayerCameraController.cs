using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField] private float lerpParam = 0.9f;

    private GameObject player;
    private LevelCatalog lvl;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lvl = GameObject.FindObjectOfType<LevelCatalog>();
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPos = Vector3.Lerp(player.transform.position,transform.position,lerpParam);

        float cameraHalfHeight = cam.orthographicSize;

        if (desiredPos.y - cameraHalfHeight < 0 && desiredPos.y + cameraHalfHeight > lvl.currentLvl.levelTexture.height)
            desiredPos.y = lvl.currentLvl.levelTexture.height / 2;
        else
            desiredPos.y = Mathf.Clamp(desiredPos.y, cameraHalfHeight, lvl.currentLvl.levelTexture.height - cameraHalfHeight);


        float cameraHalfWidth = cam.orthographicSize * cam.aspect;

        if (desiredPos.x - cameraHalfWidth < 0 && desiredPos.x + cameraHalfWidth > lvl.currentLvl.levelTexture.width)
            desiredPos.x = lvl.currentLvl.levelTexture.width / 2;
        else
            desiredPos.x = Mathf.Clamp(desiredPos.x, cameraHalfWidth, lvl.currentLvl.levelTexture.width - cameraHalfWidth);

        transform.position = new Vector3(desiredPos.x, desiredPos.y, transform.position.z);
    }
}
