using System.Collections;
using UnityEngine;

namespace Inventory.Utils
{
    public class CoroutineRunner : MonoBehaviour
    {
        private static CoroutineRunner coroutineRunner;
        
        private static CoroutineRunner Instance
        {
            get
            {
                if (coroutineRunner == null)
                    coroutineRunner = new GameObject("Coroutine Runner").AddComponent<CoroutineRunner>();

                return coroutineRunner;
            }
        }

        private Coroutine LocalRun(IEnumerator enumerator)
        {
            return StartCoroutine(enumerator);
        }

        public static Coroutine Run(IEnumerator enumerator)
        {
            return Instance.LocalRun(enumerator);
        }
    }
}