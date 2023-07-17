using System.Collections.Generic;
using UnityEngine;

public class EraserController : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRendererPrefab;
    [SerializeField] private Material _lineMaterial;
    
    private LineRenderer _currentLineRenderer;
    private List<Vector3> _currentLinePoints = new List<Vector3>();
    private float _startWidth = 0.45f;
    private float _endtWidth = 0.45f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartNewLine();
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPos.z = -8;

            if (_currentLinePoints.Count > 0 &&
                Vector3.Distance(worldPos, _currentLinePoints[_currentLinePoints.Count - 1]) < 0.1f)
            {
                return;
            }

            _currentLinePoints.Add(worldPos);
            _currentLineRenderer.positionCount = _currentLinePoints.Count;
            _currentLineRenderer.SetPositions(_currentLinePoints.ToArray());

            // Проверка коллайдера
            RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);
            if (hit.collider != null && !hit.collider.CompareTag("Ball"))
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }

    private void StartNewLine()
    {
        _currentLineRenderer = Instantiate(_lineRendererPrefab, transform);
        _currentLineRenderer.material = _lineMaterial;
        _currentLineRenderer.startColor = Color.white;
        _currentLineRenderer.endColor = Color.white;
        _currentLineRenderer.startWidth = _startWidth;
        _currentLineRenderer.endWidth = _endtWidth;

        _currentLinePoints.Clear();
    }
}