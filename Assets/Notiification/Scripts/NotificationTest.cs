using UnityEngine;
using NotificationSystem;
using TMPro;

public class NotificationTest : MonoBehaviour
{
    [SerializeField] NotificationsManager NotificationsManager;
    [SerializeField] TMP_InputField TitleText;
    [SerializeField] TMP_InputField ContentText;
    [SerializeField] NotificationPosition Position;
    [SerializeField] Category Category = Category.Error;

    void Start()
    {
        //ShowNotif();
    }

    
    public void ShowNotif()
    {
        NotificationsManager.ShowNotification(TitleText.text, ContentText.text, Category, Position);

        switch (Category)
        {
            case Category.Error:
                Category = Category.Success;
                break;
            case Category.Success:
                Category = Category.Generic;
                break;
            case Category.Generic:
                Category = Category.Warning;
                break;
            case Category.Warning:
                Category = Category.Error;
                break;
            default:
                break;
        }
    }
}
