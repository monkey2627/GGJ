using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YarnSpirit : MonoBehaviour
{
    Seeker mySeeker;
    private List<Vector3> aimPoint;
    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        mySeeker = transform.GetComponent<Seeker>();
        mySeeker.pathCallback += OnPathComplete;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hitInfo))
            {
                mySeeker.StartPath(transform.position, hitInfo.point);
            }
        }
    }

    private void FixedUpdate()
    {
        if (aimPoint != null && aimPoint.Count > 0)
        {
            Vector3 dir = (aimPoint[0] - transform.position).normalized;
            //transform.LookAt(transform.position + dir);

            //Quaternion qua = Quaternion.LookRotation(aimPoint[0] - transform.position);
            //transform.rotation = Quaternion.Lerp(transform.rotation, qua, 0.1f);
            transform.position += dir * Time.fixedDeltaTime * speed;
            if (Vector3.Distance(aimPoint[0], transform.position) <= 0.1f)
            {
                aimPoint.RemoveAt(0);
            }
        }
    }
    void OnPathComplete(Path path)
    {
        aimPoint = new List<Vector3>(path.vectorPath);
    }
}
