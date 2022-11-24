using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int StudentID = 19120272;
    public GameObject gameObjectA;
    public GameObject gameObjectB;
    public float force = 600f;

    bool isRotatingA = false;
    bool isRotatingB = false;

    Vector3 rotateDirA;
    Vector3 rotateDirB;

    public float rotateSpeed = 5;
    GameObject A;

    GameObject BManager;
    // Start is called before the first frame update
    void Start()
    {
        A = Instantiate(gameObjectA, new Vector3(0, Random.Range(10f, 20f), 0), Quaternion.identity);
        BManager = GameObject.Find("BManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Vector3 initPos = new Vector3(0, Random.Range(10f, 10 + StudentID % 10f), 0);
            GameObject newObject = Instantiate(gameObjectB, initPos, Quaternion.identity);

            Vector3 forceDir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 0f), Random.Range(-1f, 1f));
            newObject.GetComponent<Rigidbody>().AddForce(forceDir * force);

            newObject.transform.parent = BManager.transform;
        }

        if (isRotatingA)
        {
            A.transform.Find("Cube").transform.RotateAroundLocal(rotateDirA, rotateSpeed * Time.deltaTime);
        }
        
        if (isRotatingB)
        {
            Transform[] children = BManager.GetComponentsInChildren<Transform>();
            for(int i = 1; i < children.Length; i++)
            {
                children[i].RotateAroundLocal(rotateDirB, rotateSpeed * Time.deltaTime);
            }
        }

        if (Input.GetKeyDown("c"))
        {
            Transform[] children = BManager.GetComponentsInChildren<Transform>();
            for (int i = 1; i < children.Length; i++)
            {
                children[i].gameObject.GetComponent<MeshRenderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            }
        }

        if (Input.GetKeyDown("q"))
        {
            Invoke("DeleteBObject", 2f);
        }

        if (Input.GetKeyDown("r"))
        {
            if (isRotatingA)
            {
                isRotatingA = false;
            }
            else
            {
                rotateDirA = new Vector3(Random.Range(0.1f, 2f), Random.Range(0.1f, 2f), Random.Range(0.1f, 2f));
                isRotatingA = true;
            }
        }

        if (Input.GetKeyDown("t"))
        {
            if(isRotatingB)
            {
                isRotatingB = false;
                Transform[] children = BManager.GetComponentsInChildren<Transform>();
                for (int i = 1; i < children.Length; i++)
                {
                    children[i].gameObject.GetComponent<Rigidbody>().useGravity = true;
                    children[i].gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                }
            }
            else
            {
                isRotatingB = true;
                rotateDirB = new Vector3(Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2));
                Transform[] children = BManager.GetComponentsInChildren<Transform>();
                float yPos = Random.Range(10f, 20f);
                for (int i = 1; i < children.Length; i++)
                {
                    children[i].gameObject.GetComponent<Rigidbody>().useGravity = false;
                    children[i].gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
                    children[i].position += new Vector3(0, yPos, 0);
                }
                    
            }
        }
    }

    void DeleteBObject()
    {
        Transform[] children = BManager.GetComponentsInChildren<Transform>();
        
        if(children.Length == 0)
        {
            return;
        }

        Destroy(children[Random.Range(1, children.Length)].gameObject);

        Invoke("DeleteBObject", 0.2f);
    }
}
