using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Inventory.Utils
{
    public static class UIHelper
    {
        private static PointerEventData pointerEventData;
        private static List<RaycastResult> rayCastResults = new();
        
        public static GameObject GetPointerUI()
        {
            pointerEventData = new PointerEventData(EventSystem.current) {position = Input.mousePosition};
            rayCastResults.Clear();
            
            EventSystem.current.RaycastAll(pointerEventData, rayCastResults);

            if (rayCastResults.Count > 0)
                return rayCastResults[0].gameObject;

            return null;
        }
        
        public static IEnumerable<GameObject> GetAllPointerUI()
        {
            pointerEventData = new PointerEventData(EventSystem.current) {position = Input.mousePosition};
            rayCastResults.Clear();
            
            EventSystem.current.RaycastAll(pointerEventData, rayCastResults);

            if (rayCastResults.Count > 0)
            {
                foreach (var result in rayCastResults)
                    yield return result.gameObject;
            }
        }
    }
}