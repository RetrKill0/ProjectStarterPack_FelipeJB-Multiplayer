using System.Linq;
using UnityEngine;

namespace NotificationSystem
{
    public class NotificationsManager : MonoBehaviour
    {
        [SerializeField] NotificationPopup NotificationPrefab;
        [SerializeField] NotificationCategory[] NotificationCategories;
        [SerializeField] NotificationContainer[] Containers;

        private void Reset()
        {
            Containers = GetComponentsInChildren<NotificationContainer>();
        }

        public void ShowNotification(string title, string content, Category category, NotificationPosition position, float customDuration = 0)
        {
            NotificationContainer container = Containers.FirstOrDefault(c => c.ContainerPosition == position);
            if(container != null)
            {
                NotificationCategory notifCategory = NotificationCategories.FirstOrDefault(c => c.Category == category);

                NotificationPopup popup = Instantiate(NotificationPrefab, container.ContainerRect);
                popup.TitleText.text = title;
                popup.ContentText.text = content;
                popup.Icon.sprite = notifCategory.Icon;
                popup.ShowTime = customDuration > 0 ? customDuration : notifCategory.Duration;
                container.AddNotification(popup);
            }
            else
            {
                Debug.LogError($"No notification container found for position {position}");
                return;
            }
        }
    }
}