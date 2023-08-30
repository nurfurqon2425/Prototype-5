using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 mousePosition;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.isGameActive)
        {
            PointerMovement();
        }

    }

    public void PointerMovement()
    {
        if (Input.GetMouseButton(0))
        {
            mousePosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            mousePosition.z += 10.0f;
            transform.position = mousePosition;
        }

    }
}
