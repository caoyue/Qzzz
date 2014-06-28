using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.UI.Notifications;

namespace Qzzz.Toast
{
    public class ToastTemplateBase
    {
        private readonly XmlDocument _document;
        private readonly ToastTemplateType _templateType;

        protected ToastTemplateBase(ToastTemplateType templateType)
        {
            _templateType = templateType;
            _document = ToastNotificationManager.GetTemplateContent(templateType);
        }

        protected ToastTemplateType TemplateType
        {
            get { return _templateType; }
        }

        protected void SetText(int id, string value)
        {
            string xpath = string.Format("//text[@id={0}]", id);
            var node = _document.SelectSingleNode(xpath);
            node.InnerText = value;
        }

        protected string GetText(int id)
        {
            string xpath = string.Format("//text[@id={0}]", id);
            var node = _document.SelectSingleNode(xpath);
            return node.InnerText;
        }

        protected void SetImage(int id, string value)
        {
            string xpath = string.Format("//image[@id={0}]", id);
            var node = (XmlElement)_document.SelectSingleNode(xpath);
            node.SetAttribute("src", value);
        }

        protected string GetImage(int id)
        {
            string xpath = string.Format("//image[@id={0}]", id);
            var node = (XmlElement)_document.SelectSingleNode(xpath);
            return node.GetAttribute("src");
        }

        public TypedEventHandler<ToastNotification, object> ActivatedHandler { get; set; }

        public TypedEventHandler<ToastNotification, ToastDismissedEventArgs> DismissedHandler { get; set; }

        public TypedEventHandler<ToastNotification, ToastFailedEventArgs> FailedHandler { get; set; }

        public ToastNotification CreateNotification()
        {
            var toast = new ToastNotification(_document);
            toast.Activated += ActivatedHandler;
            toast.Dismissed += DismissedHandler;
            toast.Failed += FailedHandler;
            return toast;
        }
    }
}
