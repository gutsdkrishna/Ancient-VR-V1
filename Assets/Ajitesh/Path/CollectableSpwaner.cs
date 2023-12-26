using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.AI;

public class CollectableSpawner : MonoBehaviour
{
    [SerializeField]
    Collectable prefab;
    [SerializeField]
    Transform Player;
    [SerializeField]
    LineRenderer Path;
    [SerializeField]
    float PathHeight = 1.25f;
    [SerializeField]
    float SpawnHeightOffset = 1.5f;
    [SerializeField]
    float PathUpdateSpeed = 0.25f;

    Collectable ActiveInstance;
    NavMeshTriangulation triangulation;
    Coroutine DrawPathCoroutine;
    NavMeshPath path; // Declare the path variable

    private void Awake()
    {
        triangulation = NavMesh.CalculateTriangulation();
    }

    void Start()
    {
        SpawnNewObject();
    }

    public void SpawnNewObject()
    {
        ActiveInstance = Instantiate(prefab, triangulation.vertices[Random.Range(0, triangulation.vertices.Length)] + Vector3.up * SpawnHeightOffset, Quaternion.Euler(90, 0, 0));
        ActiveInstance.spw = this;

        if (DrawPathCoroutine != null)
        {
            StopCoroutine(DrawPathCoroutine);
        }
        DrawPathCoroutine = StartCoroutine(DPTC());
    }

    IEnumerator DPTC()
    {
        WaitForSeconds wait = new WaitForSeconds(PathUpdateSpeed);
        while (ActiveInstance != null)
        {
            path = new NavMeshPath(); // Initialize the path variable

            if (NavMesh.CalculatePath(Player.position, ActiveInstance.transform.position, NavMesh.AllAreas, path))
            {
                Path.positionCount = path.corners.Length; // Fix the length property

                for (int i = 0; i < path.corners.Length; i++)
                {
                    Path.SetPosition(i, path.corners[i] + Vector3.up * PathHeight);
                }
            }
            else
            {
                Debug.LogError("No path");
            }
            yield return wait;
        }
    }
}





