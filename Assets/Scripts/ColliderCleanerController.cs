

// 
// using UnityEngine;
//
// public class ColliderCleaner: MonoBehaviour
// {
//     [SerializeField] private PolygonCollider2D _spriteCollider;
//     [SerializeField] private Camera _mainCamera;
//     
//     private bool _isMousePressed;
//
//
//     void Update()
//     {
//         if (Input.GetMouseButtonDown(0))
//         {
//             _isMousePressed = true;
//         }
//
//         if (Input.GetMouseButtonUp(0))
//         {
//             _isMousePressed = false;
//         }
//
//         if (_isMousePressed)
//         {
//             Vector2 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
//             RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
//
//             if (hit.collider == _spriteCollider)
//             {
//                 Vector2 localPoint = _spriteCollider.transform.InverseTransformPoint(hit.point);
//                 Collider2D[] colliders = Physics2D.OverlapPointAll(hit.point);
//
//                 foreach (Collider2D collider in colliders)
//                 {
//                     if (collider == _spriteCollider)
//                     {
//                         PolygonCollider2D polygonCollider = collider as PolygonCollider2D;
//                         Vector2[] path = polygonCollider.GetPath(0);
//
//                         for (int i = 0; i < path.Length; i++)
//                         {
//                             if (Vector2.Distance(path[i], localPoint) < 0.8f)
//                             {
//                                 path[i] = new Vector2(float.NaN, float.NaN);
//                             }
//                         }
//
//                         polygonCollider.SetPath(0, path);
//                     }
//                 }
//             }
//         }
//     }
// }