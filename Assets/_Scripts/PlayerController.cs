using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Vector2 Boundary;
    public float speed = 5f;

    Vector2 Right;
    Vector2 Left;

    public bool RightButtonPressed;
    public bool LeftButtonPressed;

    private float normaledX;
    private float mirroredX;

    // Use this for initialization
    void Start () {
        normaledX = this.transform.localScale.x;
        mirroredX = this.transform.localScale.x * -1;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A) || LeftButtonPressed)
        {
            MoveLeft();
            setAnimation(true);
            this.transform.localScale = new Vector2(normaledX, this.transform.localScale.y);
        }
        else if (Input.GetKey(KeyCode.D) || RightButtonPressed)
        {
            MoveRight();
            setAnimation(true);
            this.transform.localScale = new Vector2(mirroredX, this.transform.localScale.y);
        }
        else
        {
            setAnimation(false);
        }
    }

    public void MoveRight()
    {
        if (transform.position.x < Boundary.y)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    public void MoveLeft()
    {
        if (transform.position.x > Boundary.x)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

    public void MoveLeftUIButton(bool status)
    {
        LeftButtonPressed = status;
    }

    public void MoveRightUIButton(bool status)
    {
        RightButtonPressed = status;
    }

    public void setAnimation(bool status)
    {
        GetComponent<Animator>().SetBool("isMoving", status);
    }
}
