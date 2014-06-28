using System;
using Windows.UI.Notifications;

namespace Qzzz.Toast
{
    public class Toast
    {
        public string AppId { get; set; }

        public Toast(string appId)
        {
            AppId = appId;
        }

        /// <summary>
        /// Show a custom toast template
        /// </summary>
        /// <param name="toastTemplate"></param>
        public void Show(ToastTemplateBase toastTemplate)
        {
            ToastNotificationManager.CreateToastNotifier(AppId).Show(toastTemplate.CreateNotification());
        }

        /// <summary>
        /// Show a simple toast
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <param name="imgPath"></param>
        public void Show(string title, string content, string imgPath)
        {
            var toastTemplate = new ToastTemplate.ToastImageAndText02() {
                Title = title,
                Content = content,
                Image = imgPath
            };
            Show(toastTemplate);
        }

        /// <summary>
        /// Show a simple toast with action
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <param name="imgPath"></param>
        /// <param name="onActivated">Execute when toast activated</param>
        /// <param name="onDismissed">Execute when toast dismissed</param>
        public void Show(string title, string content, string imgPath, Action onActivated, Action onDismissed)
        {
            var toastTemplate = new ToastTemplate.ToastImageAndText02() {
                Title = title,
                Content = content,
                Image = imgPath
            };
            toastTemplate.ActivatedHandler += (s, a) => onActivated();
            toastTemplate.DismissedHandler += (s, a) => onDismissed();
            Show(toastTemplate);
        }
    }
}
