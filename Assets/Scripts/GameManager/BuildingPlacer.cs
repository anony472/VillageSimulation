using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingPlacer : MonoBehaviour
{
    public static BuildingPlacer instance; // (Singleton pattern)

    public LayerMask groundLayerMask;

    protected GameObject _buildingPrefab;
    protected GameObject _toBuild;

    protected Camera _mainCamera;

    protected Ray _ray;
    protected RaycastHit _hit;
    [SerializeField] GameStates gm;
    [SerializeField] Money money;
    // [SerializeField] PauseGame pg;

    private void Awake()
    {
        instance = this; // (Singleton pattern)
        _mainCamera = Camera.main;
        _buildingPrefab = null;
    }

    private void Start()
    {

    }

    private void Update()
    {
        if (_buildingPrefab != null)
        { // if in build mode

            // right-click: cancel build mode
            if (Input.GetMouseButtonDown(1) && !gm.wasButtonClicked)
            {
                Destroy(_toBuild);
                gm.nextState = GameStates.GameState.Normal;
                _toBuild = null;
                _buildingPrefab = null;
                return;
            }

            if (!_toBuild.activeSelf) _toBuild.SetActive(true);

            // rotate preview with Spacebar
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _toBuild.transform.Rotate(Vector3.up, 90);
            }

            _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(_ray, out _hit, 1000f, groundLayerMask))
            {
                if (!_toBuild.activeSelf) _toBuild.SetActive(true);
                _toBuild.transform.position = _hit.point;

                if (Input.GetMouseButtonDown(0) && !gm.wasButtonClicked)
                { // if left-click
                    BuildingManager m = _toBuild.GetComponent<BuildingManager>();
                    Debug.Log("I am here");
                    if (m.hasValidPlacement)
                    {
                        m.SetPlacementMode(PlacementMode.Fixed);
                        money.money -= m.requirementsToBuild.cost;

                        EventTrigger et = _toBuild.GetComponent<EventTrigger>();
                        if (et != null)
                            _toBuild.GetComponent<EventTrigger>().Placed();

                        // shift-key: chain builds
                        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                        {
                            _toBuild = null; // (to avoid destruction)
                            _PrepareBuilding();
                        }
                        // exit build mode
                        else
                        {
                            Destroy(m);
                            _buildingPrefab = null;
                            _toBuild = null;
                            Debug.Log("I did it");
                            gm.nextState = GameStates.GameState.Normal;
                        }
                    }
                }

            }
            else if (_toBuild.activeSelf) _toBuild.SetActive(false);
        }
    }

    public void SetBuildingPrefab(GameObject prefab)
    {
        // bool isPause=PauseGame.Instance.isPause;
        // if(!isPause){
        _buildingPrefab = prefab;
        _PrepareBuilding();
        // EventSystem.current.SetSelectedGameObject(null); // cancel keyboard UI nav
        // }
    }

    protected virtual void _PrepareBuilding()
    {
        if (_toBuild) Destroy(_toBuild);

        _toBuild = Instantiate(_buildingPrefab);
        _toBuild.SetActive(false);

        BuildingManager m = _toBuild.GetComponent<BuildingManager>();
        m.isFixed = false;
        m.SetPlacementMode(PlacementMode.Valid);
    }

}