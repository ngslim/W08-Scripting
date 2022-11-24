using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speed = 5f;
    bool isMoving = false;

    Vector3 originalPos;
    Vector3 targetPos;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            if(isMoving)
            {
                isMoving = false;
            }
            else
            {
                isMoving = true;
                originalPos = transform.position;
                int direction = Random.Range(0, 3);
                float distance = Random.Range(10f, 20f);
                if(direction == 0)
                {
                    targetPos = originalPos + Vector3.up * distance;
                }
                else if (direction == 1)
                {
                    targetPos = originalPos + Vector3.forward * distance;
                }
                else
                {
                    targetPos = originalPos + Vector3.right * distance;
                }
            }
        }
        if(isMoving)
        {
            if (transform.position == targetPos)
            {
                Vector3 tempPos = originalPos;
                originalPos = targetPos;
                targetPos = tempPos;
            }
            transform.position = Vector3.MoveTowards(transform.position, targetPos, (2 + 19120272 % 10) * Time.deltaTime);
        }
        if (!isMoving)
        {
            float hDirection = Input.GetAxisRaw("Horizontal");
            float vDirection = Input.GetAxisRaw("Vertical");
            transform.Translate(new Vector3(vDirection, 0, -hDirection) * speed * Time.deltaTime);
        }
        
    } 
}
