using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Unity.VisualScripting.Member;

public class BuildableItems : UsableItem
{
    [SerializeField] private LayerMask _layerBuild;
    [SerializeField] private GameObject _objectToBuild;
    [SerializeField] private Material _hologramMaterial;
    private static Quaternion _buildableRotation;
    private GameObject _hologramRoot;
    private float _buildDistance = 13;
    private void Start()
    {
        var meshRenderers = GetComponentsInChildren<MeshRenderer>();
        _hologramRoot = new GameObject(gameObject.name + "_Hologram");
        _hologramRoot.transform.localScale = gameObject.transform.localScale;
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
            renderer.material = _hologramMaterial;
        }
        _hologramRoot.transform.rotation = _buildableRotation;
    }
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
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
        if (Physics.Raycast(ray, out RaycastHit hitInfo, _buildDistance, _layerBuild))
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
