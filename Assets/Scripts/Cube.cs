using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class Cube : MonoBehaviour
{
    [SerializeField] private Transform FirstPoint;
    [SerializeField] private List<Transform> Path = new List<Transform>();
    private Transform NextPoint;
    private Transform lastPoint;
    private Transform _ThisTransf;
    private bool onPath = false;
    private bool oneDelete = false;
    public NavMeshAgent agent;
    private int IndexNowPoint = -1;
    public float dist = 0;
    public float speed;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(FirstPoint.position);
        _ThisTransf = transform;
        lastPoint = Path[0];
    }

    // Update is called once per frame
    void Update()
    {
        FindPath();
        destroyCube();
    }
    private void FindPath()
    {
        if (onPath)
        {
            agent.speed = speed;
            if (agent.hasPath == false)
            {
                if (NextPoint == null)
                    lastPoint = Path[0];
                else
                    lastPoint = NextPoint;
                NextPoint = GetNextPoint(Path);
                agent.SetDestination(NextPoint.position);
            }
        }
        else
        {
            if (agent.hasPath == false)
                onPath = true;
        }
    }
    private void destroyCube()
    {
        if (Vector3.Distance(lastPoint.position, _ThisTransf.position) > 0.1f)
            dist += 0.1f;
        if (dist >= ManagerCube.Distance && oneDelete == false)
        {
            transform.parent.SendMessage("DeleteCube", 0.5f);
            oneDelete = true;
        }
    }
    private Transform GetNextPoint(List<Transform> Path)
    {
        if (IndexNowPoint != Path.Count - 1)
        {
            IndexNowPoint++;
        }
        else
        {
            IndexNowPoint = 0;
        }
        return Path[IndexNowPoint];
    }

    public void UpdSpeed(float spd)
    {
        speed = spd;
    }


}