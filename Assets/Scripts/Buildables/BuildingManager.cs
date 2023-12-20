using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public enum PlacementMode
{
    Fixed,
    Valid,
    Invalid
}

public class BuildingManager : MonoBehaviour
{
    public Material validPlacementMaterial;
    public Material invalidPlacementMaterial;

    public MeshRenderer[] meshComponents;
    private Dictionary<MeshRenderer, List<Material>> initialMaterials;

    [HideInInspector] public bool hasValidPlacement;
    [HideInInspector] public bool isFixed;
    [SerializeField] Vector3 mulfactor; //Due to different sizes of base scale among different objects. Hardcoded.

    public GameObject gameManager;
    BuildingPlacer bp;
    DragManager dm;

    public KeyCode requiredKey;

    private int _nObstacles;
    [SerializeField] GameStates gs;
    [SerializeField] public RequirementsToBuild requirementsToBuild;
    [SerializeField] Money money;
    public bool otherBuildingMethods = false;

    private void Awake()
    {
        hasValidPlacement = true;
        isFixed = true;
        _nObstacles = 0;

        _InitializeMaterials();
    }

    private void Start()
    {
        bp = gameManager.GetComponent<BuildingPlacer>();
        dm = gameManager.GetComponent<DragManager>();
    }

    private void Update()
    {
        if (money.money >= requirementsToBuild.cost)
        {
            if ((Input.GetKeyDown(requiredKey)) && (gs.currentState == GameStates.GameState.Normal || gs.currentState == GameStates.GameState.BuildingMode))
            {
                if (gs.currentState == GameStates.GameState.Normal && dm.plane != null)
                {
                    DragSelector ds = dm.plane.GetComponent<DragSelector>();
                    if (ds.nog == 0)
                    {
                        HandleSize();
                    }

                }
                else
                {
                    gs.nextState = GameStates.GameState.BuildingMode;
                    bp.SetBuildingPrefab(this.gameObject);
                }
            }
            if (otherBuildingMethods && gs.currentState == GameStates.GameState.Normal)
            {
                Debug.Log("Nani pls work");
                if (gs.currentState == GameStates.GameState.Normal && dm.plane != null)
                {
                    DragSelector ds = dm.plane.GetComponent<DragSelector>();
                    if (ds.nog == 0)
                    {
                        HandleSize();
                    }

                }
                else
                {
                    gs.nextState = GameStates.GameState.BuildingMode;
                    bp.SetBuildingPrefab(this.gameObject);
                }
                otherBuildingMethods = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("Hello from ontriggerenter");
        if (isFixed) return;

        // ignore ground objects
        if (_IsGround(other.gameObject)) return;

        _nObstacles++;
        SetPlacementMode(PlacementMode.Invalid);
    }

    private void OnTriggerExit(Collider other)
    {
        // Debug.Log("Hello from ontriggerexit");
        if (isFixed) return;

        // ignore ground objects
        if (_IsGround(other.gameObject)) return;

        _nObstacles--;
        if (_nObstacles == 0)
            SetPlacementMode(PlacementMode.Valid);
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        _InitializeMaterials();
    }
#endif

    public void SetPlacementMode(PlacementMode mode)
    {
        if (mode == PlacementMode.Fixed)
        {
            isFixed = true;
            hasValidPlacement = true;
        }
        else if (mode == PlacementMode.Valid)
        {
            hasValidPlacement = true;
        }
        else
        {
            hasValidPlacement = false;
        }
        SetMaterial(mode);
    }

    public void SetMaterial(PlacementMode mode)
    {
        if (mode == PlacementMode.Fixed)
        {
            foreach (MeshRenderer r in meshComponents)
                r.sharedMaterials = initialMaterials[r].ToArray();
        }
        else
        {
            Material matToApply = mode == PlacementMode.Valid
                ? validPlacementMaterial : invalidPlacementMaterial;

            Material[] m; int nMaterials;
            foreach (MeshRenderer r in meshComponents)
            {
                nMaterials = initialMaterials[r].Count;
                m = new Material[nMaterials];
                for (int i = 0; i < nMaterials; i++)
                    m[i] = matToApply;
                r.sharedMaterials = m;
            }
        }
    }

    private void _InitializeMaterials()
    {
        if (initialMaterials == null)
            initialMaterials = new Dictionary<MeshRenderer, List<Material>>();
        if (initialMaterials.Count > 0)
        {
            foreach (var l in initialMaterials) l.Value.Clear();
            initialMaterials.Clear();
        }

        foreach (MeshRenderer r in meshComponents)
        {
            initialMaterials[r] = new List<Material>(r.sharedMaterials);
        }
    }

    private bool _IsGround(GameObject o)
    {
        return ((1 << o.layer) & BuildingPlacer.instance.groundLayerMask.value) != 0;
    }

    private void HandleSize()
    {
        GameObject temp = Instantiate(gameObject);
        Destroy(temp.GetComponent<BuildingManager>());
        temp.transform.position = dm.plane.transform.position - dm.upwardsOffeset;
        AdjustSizeWrtCollider(temp);
        dm.DestroyPlane();
        gs.nextState = GameStates.GameState.Normal;
    }

    private void AdjustSizeWrtCollider(GameObject buildable)
    {
        buildable.transform.localScale = Vector3.Scale(dm.plane.transform.localScale, mulfactor);
    }
}