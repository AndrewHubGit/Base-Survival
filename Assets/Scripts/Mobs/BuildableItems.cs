using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;
using static Unity.VisualScripting.Member;

public class BuildableItems : UsableItem
{
    [SerializeField] private LayerMask _layerBuild;
    [SerializeField] private GameObject _objectToBuild;
    [SerializeField] private Material _hologramMaterialCanBuild;
    [SerializeField] private Material _hologramMaterialNoBuild;
    private MeshRenderer[] _hologramRenderer;
    private Hologram _hologram;
    private static Quaternion _buildableRotation;
    private GameObject _hologramRoot;
    private float _buildDistance = 13;
    private void Start()
    {
        var meshRenderers = GetComponentsInChildren<MeshRenderer>();

        _hologramRoot = new GameObject(gameObject.name + "_Hologram");
        _hologramRoot.transform.localScale = gameObject.transform.localScale;
        _hologram = _hologramRoot.AddComponent<Hologram>();

        var hologramPhysics = _hologramRoot.AddComponent<Rigidbody>();
        hologramPhysics.constraints = RigidbodyConstraints.FreezeAll;

        _hologramRenderer = new MeshRenderer[meshRenderers.Length];
        for (int i = 0; i < meshRenderers.Length; i++)
        {
            var srcRenderer = meshRenderers[i];
            var srcTransform = srcRenderer.transform;

            var child = new GameObject(srcRenderer.name);
            child.transform.SetParent(_hologramRoot.transform, false);

            child.transform.localPosition = srcTransform.localPosition;
            child.transform.localRotation = srcTransform.localRotation;
            child.transform.localScale = srcTransform.localScale;

            var filter = child.AddComponent<MeshFilter>();

            filter.sharedMesh = srcRenderer.GetComponent<MeshFilter>().sharedMesh;

            var renderer = child.AddComponent<MeshRenderer>();

            renderer.material = _hologramMaterialCanBuild;
            _hologramRenderer[i] = renderer;
        }
        _hologramRoot.transform.rotation = _buildableRotation;   
    }
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if(_hologram.CanBuild() == true)
        {
            for (int i = 0; i < _hologramRenderer.Length; i++)
            {
                _hologramRenderer[i].material = _hologramMaterialCanBuild;
            }
        }
        else
        {
            for (int i = 0; i < _hologramRenderer.Length; i++)
            {
                _hologramRenderer[i].material = _hologramMaterialNoBuild;
            }
        }
        if (Physics.Raycast(ray, out RaycastHit hitInfo, _buildDistance, _layerBuild))
        {
            _hologramRoot.SetActive(true);
            _hologramRoot.transform.position = hitInfo.point;
        }
        else
        {
            _hologramRoot.SetActive(false);
        }
    }
    private void OnDisable()
    {
        Destroy(_hologramRoot);
    }
    public override bool Use()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out RaycastHit hitInfo, _buildDistance, _layerBuild) && _hologram.CanBuild() == true)
        {
            Instantiate(_objectToBuild, hitInfo.point, _hologramRoot.transform.rotation);
            return true;
        }
        return false;
    }
    public void RotateObject(int rotation)
    {
        _hologramRoot.transform.Rotate(Vector3.down * rotation);
        _buildableRotation = _hologramRoot.transform.rotation;
    }
}
