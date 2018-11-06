using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelMovement : MonoBehaviour {
    public float speed;
    public float rotateSpeed;
    public Transform level;
    public float minDistanceFromWall;
    private bool move = false;
    private bool rotateLeft = false;
    private bool rotateRight = false;
    private float xPosition;
    private float zPosition;

    // Use this for initialization
    void Start () {
        xPosition = level.transform.position.x;
        zPosition = level.transform.position.z;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        RaycastHit hit;

        if (Input.GetKey(KeyCode.W) || move)
        {
            Ray ray = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(ray.origin, ray.direction, out hit, minDistanceFromWall))
                Debug.DrawRay(ray.origin, ray.direction * minDistanceFromWall, Color.red);
            else
            {
                Debug.DrawRay(ray.origin, ray.direction * minDistanceFromWall, Color.white);
                //levelContainer.Translate(transform.up * Time.deltaTime * speed);
                level.transform.Translate(-transform.forward * Time.deltaTime * speed, Space.World);
                level.transform.localPosition = 
                    new Vector3(level.transform.localPosition.x, 0, level.transform.localPosition.z);
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow) || rotateLeft)    
            Orbit(transform.position, transform.up, Time.deltaTime * rotateSpeed);
        else if (Input.GetKey(KeyCode.RightArrow) ||  rotateRight)
            Orbit(transform.position, transform.up, -Time.deltaTime * rotateSpeed);
	}

    private void Orbit(Vector3 point, Vector3 axis, float angle)
    {
        level.transform.RotateAround(point, axis, angle);
        level.transform.localPosition = new Vector3(level.transform.localPosition.x, 0, level.transform.localPosition.z);
    }

    public void OnMoveButtonPointerDown()
    {
        move = true;
    }

    public void OnMoveButtonPointerUp()
    {
        move = false;
    }

    public void OnLeftButtonPointerDown()
    {
        rotateLeft = true;
    }

    public void OnLeftButtonPointerUp()
    {
        rotateLeft = false;
    }

    public void OnRightButtonPointerDown()
    {
        rotateRight = true;
    }

    public void OnRightButtonPointerUp()
    {
        rotateRight = false;
    }
}
