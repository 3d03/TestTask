using UnityEngine;
using System.Linq;


namespace TestTask { 
public class Dragger: MonoBehaviour
    {
        Vector3 startPos;
        Vector3 screenPoint;
        Vector3 offset;

        public Camera cam;

        void OnMouseDown()
        {
            startPos = transform.position;
            screenPoint = cam.WorldToScreenPoint(gameObject.transform.position);
            offset = gameObject.transform.position - cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        }

        void OnMouseDrag()
        {
            Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 cursorPosition = cam.ScreenToWorldPoint(cursorPoint) + offset;
            transform.position = new Vector3(cursorPosition.x, startPos.y, cursorPosition.z);
            transform.position = FindClosestSnapPoint();
        }

        Vector3 FindClosestSnapPoint()
        {
            return GridBuilder.instance.SnapPoints.OrderBy(sp => (Vector3.Distance(transform.position, sp))).ElementAt(0);
        }
    }
}