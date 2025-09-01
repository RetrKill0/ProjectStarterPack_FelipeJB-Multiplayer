using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NotificationSystem
{
    public class NotificationContainer : MonoBehaviour
    {
        [field:SerializeField] public NotificationPosition ContainerPosition { get; private set; }

        [SerializeField] int maxPopups = 8;
        [SerializeField] RectTransform ContainerRect;

        private List<NotificationPopup> activePopups = new List<NotificationPopup>();

        private void Start()
        {
            Clear();
        }

        private void Reset()
        {
            ContainerRect = GetComponent<RectTransform>();
        }

        public void AddNotification(NotificationPopup popup)
        {
            if(activePopups.Count >= maxPopups)
                activePopups[0].DestroyPopup();

            if (!activePopups.Contains(popup))
                activePopups.Add(popup);

            popup.container = this;
            popup.transform.SetParent(ContainerRect);
            // fix para glitches visuais devido ao layout complexo
            popup.transform.localScale = Vector3.one;
            if(popup.TryGetComponent(out RectTransform tr))
                LayoutRebuilder.ForceRebuildLayoutImmediate(tr);
        }

        public void RemoveNotification(NotificationPopup popup)
        {
            activePopups.Remove(popup);
        }

        public void Clear()
        {
            foreach(var popup in activePopups)
            {
                if(popup != null)
                    popup.DestroyPopup(false); // passar false previne erro por modificar coleção durante foreach
            }

            activePopups.Clear();
        }
    }
}