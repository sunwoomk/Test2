using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafAndFeather : MonoBehaviour
{
    public GameObject prefab;
    GameObject nowPrefab;

    public bool front;
    public bool back;
    public bool Right;
    public bool Left;

    private Vector3 startPos;
    public float endPos;
    private Vector3 DestoryPos;

    float MoveSpeed;

    Vector3 rotationSpeedRange = new Vector3(70f, 10f, 60f);
    Vector3 currentRotationSpeed;

    float respawnCount = 0f;

    private void Awake()
    {
        startPos = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (front)
        {
            DestoryPos = new Vector3(startPos.x, startPos.y, startPos.z - endPos);
        }

        else if (back)
        {
            DestoryPos = new Vector3(startPos.x, startPos.y, startPos.z + endPos);
        }

        else if (Right)
        {
            DestoryPos = new Vector3(startPos.x - endPos, startPos.y, startPos.z);
        }

        else if (Left)
        {
            DestoryPos = new Vector3(startPos.x + endPos, startPos.y, startPos.z);
        }

        else { }
    }

    // Update is called once per frame
    void Update()
    {
        if(respawnCount > 0f)
        {
            respawnCount -= Time.deltaTime;
        }

        else if(respawnCount <= 0f)
        {
            if (nowPrefab == null)
            {
                nowPrefab = GameObject.Instantiate(prefab, startPos, Quaternion.identity);
                MoveSpeed = Random.Range(2f, 6.3f);
                currentRotationSpeed = new Vector3(
                Random.Range(-rotationSpeedRange.x, rotationSpeedRange.x),
                Random.Range(-rotationSpeedRange.y, rotationSpeedRange.y),
                Random.Range(-rotationSpeedRange.z, rotationSpeedRange.z));
            }
        }

        if(nowPrefab != null)
        {
            nowPrefab.transform.position = Vector3.MoveTowards(nowPrefab.transform.position, DestoryPos, MoveSpeed * Time.deltaTime);
            nowPrefab.transform.Rotate(currentRotationSpeed * Time.deltaTime);

            if (Vector3.Distance(nowPrefab.transform.position, DestoryPos) <= 1f)
            {
                Destroy(nowPrefab);
                respawnCount = 2.3f;
            }
        }
    }
}
