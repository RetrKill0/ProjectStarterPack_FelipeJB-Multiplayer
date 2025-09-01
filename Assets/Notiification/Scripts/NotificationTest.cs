using UnityEngine;
using NotificationSystem;
using TMPro;

public class NotificationTest : MonoBehaviour
{
    [SerializeField] NotificationsManager NotificationsManager;
    [SerializeField] TMP_InputField TitleText;
    [SerializeField] TMP_InputField ContentText;
    [SerializeField] TMP_InputField TimeText;
    [SerializeField] NotificationPosition Position;
    [SerializeField] Category Category = Category.Error;

    void Start()
    {
        NotificationsManager.ShowNotification("Login bem sucedido", "Aproveite sua gameplay!", Category.Success, Position);
        NotificationsManager.ShowNotification("Login incorreto", "Senha ou usuário incorreto", Category.Error, Position);
        NotificationsManager.ShowNotification("Link copiado", "O link do nosso discord foi copiado", Category.Generic, Position);
        NotificationsManager.ShowNotification("Conta inexistente", "Essa conta não existe, verifique suas informações", Category.Warning, Position);
    }

    
    public void ShowNotif()
    {
        float notifTime = 0;

        if (TimeText.text != "" && float.TryParse(TimeText.text, out float customTime))
            notifTime = customTime;

        NotificationsManager.ShowNotification(TitleText.text, ContentText.text, Category, Position, notifTime);

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
