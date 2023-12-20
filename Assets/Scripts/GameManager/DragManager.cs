using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragManager : MonoBehaviour
{
    [HideInInspector] public GameObject plane;
    [SerializeField] Material planeMaterial;
    [SerializeField] Material planeMaterialInvalid;
    [SerializeField] GameStates gs;
    Vector3 selectionStartPosition;
    Vector3 selectionEndPosition;
    RaycastHit hit;
    Ray ray;
    [SerializeField] Camera mainCamera;
    [SerializeField] LayerMask groundLayerMask;
    public Vector3 upwardsOffeset = new Vector3(0, 0.1f, 0);

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftAlt) && Input.GetMouseButtonDown(0) && gs.currentState == GameStates.GameState.Normal && !gs.wasButtonClicked)
        {
            if (plane)
            {
                DestroyPlane();
            }
            else
            {
                ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 1000f, groundLayerMask))
                {
                    CreatePlane();
                    gs.nextState = GameStates.GameState.DraggingMode;
                    selectionStartPosition = hit.point;
                    selectionEndPosition = hit.point;
                    plane.transform.position = (selectionStartPosition + selectionEndPosition) / 2 + upwardsOffeset;
                    plane.transform.localScale = new Vector3(Mathf.Abs(selectionStartPosition.x - selectionEndPosition.x), 1, Mathf.Abs(selectionStartPosition.z - selectionEndPosition.z));
                    Debug.Log("Mouse Down - Start Position: " + selectionStartPosition);
                }
            }
        }
        if (Input.GetKey(KeyCode.LeftAlt) && Input.GetMouseButton(0) && gs.currentState == GameStates.GameState.DraggingMode)
        {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000f, groundLayerMask))
            {
                selectionEndPosition = hit.point;
                plane.transform.position = (selectionStartPosition + selectionEndPosition) / 2 + upwardsOffeset;
                plane.transform.localScale = new Vector3(Mathf.Abs(selectionStartPosition.x - selectionEndPosition.x), 1, Mathf.Abs(selectionStartPosition.z - selectionEndPosition.z));
            }
        }
        if (Input.GetMouseButtonUp(0) && gs.currentState == GameStates.GameState.DraggingMode)
        {
            gs.nextState = GameStates.GameState.Normal;
            Debug.Log("UpPos: " + selectionEndPosition);
        }
    }
    public void CreatePlane()
    {

        Debug.Log("Here");
        // Create a new GameObject for the plane
        plane = new GameObject("Plane");

        // Attach a MeshFilter component to the GameObject
        MeshFilter meshFilter = plane.AddComponent<MeshFilter>();

        // Attach a MeshRenderer component to the GameObject
        MeshRenderer meshRenderer = plane.AddComponent<MeshRenderer>();

        // Create a new Mesh and set it to the MeshFilter
        Mesh mesh = new Mesh();
        meshFilter.mesh = mesh;

        // Define vertices, triangles, normals, and UVs for a simple plane
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(-1f, 0.1f, -1f),
            new Vector3(-1f, 0.1f, 1f),
            new Vector3(1f, 0.1f, 1f),
            new Vector3(1f, 0.1f, -1f)
        };

        int[] triangles = new int[] { 0, 1, 2, 0, 2, 3 };

        Vector3[] normals = new Vector3[]
        {
            Vector3.up,
            Vector3.up,
            Vector3.up,
            Vector3.up
        };

        Vector2[] uv = new Vector2[]
        {
            new Vector2(0f, 0f),
            new Vector2(0f, 1f),
            new Vector2(1f, 1f),
            new Vector2(1f, 0f)
        };

        // Set the mesh data
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.normals = normals;
        mesh.uv = uv;

        // Assign the material to the MeshRenderer
        meshRenderer.material = planeMaterial;
        DragSelector dragSelector = plane.AddComponent<DragSelector>();
        dragSelector.validMaterial = planeMaterial;
        dragSelector.invalidMaterial = planeMaterialInvalid;

        BoxCollider collider = plane.AddComponent<BoxCollider>();
        collider.isTrigger = true;
    }
    public void DestroyPlane()
    {
        Destroy(plane);
        plane = null;
    }
}
