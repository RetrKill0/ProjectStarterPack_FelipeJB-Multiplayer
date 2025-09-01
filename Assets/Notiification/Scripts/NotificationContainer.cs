using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace NotificationSystem
{
    public class NotificationContainer : MonoBehaviour
    {
        [field:SerializeField] public NotificationPosition ContainerPosition { get; private set; }
        
        [SerializeField] RectTransform ContainerRect;

        private List<NotificationPopup> activePopups = new List<NotificationPopup>();

        private void Reset()
        {
            ContainerRect = GetComponent<RectTransform>();
        }

        public void AddNotification(NotificationPopup popup)
        {
            if(!activePopups.Contains(popup))
                activePopups.Add(popup);
            popup.container = this;
            popup.transform.SetParent(ContainerRect);
        }

        public void RemoveNotification(NotificationPopup popup)
        {
            activePopups.Remove(popup);
        }

        public void Clear()
        {
            foreach(var popup in activePopups)
            {
                Destroy(popup);
            }
            activePopups.Clear();
        }
    }
}