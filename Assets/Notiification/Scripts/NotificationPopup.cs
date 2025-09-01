using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NotificationSystem
{
    [RequireComponent(typeof(RectTransform))]
    public class NotificationPopup : MonoBehaviour
    {
        [field: SerializeField] public Image TimeFill { get; private set; }
        [field: SerializeField] public Image Icon { get; private set; }
        [field: SerializeField] public TextMeshProUGUI TitleText { get; private set; }
        [field: SerializeField] public TextMeshProUGUI ContentText { get; private set; }
        [field: SerializeField] public NotificationContainer container { get; set; }

        public float ShowTime = 5;

        private float timeLeft = 5;
        private bool active = false;

        void Start()
        {
            active = true;
            TimeFill.fillAmount = 1f;
            timeLeft = ShowTime; 
        }

        void Update()
        {
            if(active)
            {
                timeLeft -= Time.deltaTime;
                TimeFill.fillAmount = timeLeft / ShowTime;
                if (timeLeft <= 0)
                    DestroyPopup();
            }
        }

        public void DestroyPopup(bool notifyContainer = true)
        {
            active = false;
            if(container != null && notifyContainer)
                container.RemoveNotification(this);
            Destroy(gameObject);
        }
    }
}
