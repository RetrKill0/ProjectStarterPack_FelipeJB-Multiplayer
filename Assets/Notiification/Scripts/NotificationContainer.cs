using UnityEngine;

namespace NotificationSystem
{
    public class NotificationContainer : MonoBehaviour
    {
        [SerializeField] RectTransform ContainerRect;

        private void Reset()
        {
            ContainerRect = GetComponent<RectTransform>();
        }
    }
}