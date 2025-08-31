using System;
using UnityEngine;

namespace NotificationSystem
{
    public enum Category
    {
        Error,
        Success,
        Generic,
        Warning
    }

    [Serializable]
    public struct NotificationCategory
    {
        public Category Category;
        public Sprite Icon;
        public float Duration;
    }
}