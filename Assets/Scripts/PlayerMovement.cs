using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb;

    float x;
    float y;

    float bottomLimit;
    float leftLimit;
    float topLimit;
    float rightLimit;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(Vector3.zero);
        bottomLimit = bottomLeft.y;
        leftLimit = bottomLeft.x;

        Vector3 topRight = Camera.main.ViewportToWorldPoint(Vector3.one);
        topLimit = topRight.y;
        rightLimit = topRight.x;

        //bottomLimit += renderer.bounds.extents.y;
        //topLimit -= renderer.bounds.extents.y;
        //leftLimit += renderer.bounds.extents.x;
        //rightLimit -= renderer.bounds.extents.x;

    }
    private void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        //transform.position += new Vector3(x, y, 0f) * speed * Time.deltaTime;

        //rb.velocity = new Vector2(x, y) * speed;
    }

    private void FixedUpdate()
    {
        Vector3 desiredPosition = transform.position + new Vector3(x, y, 0f) * speed * Time.fixedDeltaTime;

        desiredPosition.x = Mathf.Clamp(desiredPosition.x, leftLimit, rightLimit);

        desiredPosition.y = Mathf.Clamp(desiredPosition.y, bottomLimit, topLimit);

        rb.MovePosition(desiredPosition);

        //rb.MovePosition(transform.position + new Vector3(x, y, 0f) * speed * Time.fixedDeltaTime);


    }
    
}