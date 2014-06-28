using Windows.UI.Notifications;

namespace Qzzz.Toast
{
    public class ToastTemplate
    {
        /// <summary>
        /// A large image and a single string wrapped across three lines of text. 
        /// </summary>
        public class ToastImageAndText01 : ToastTemplateBase
        {
            public ToastImageAndText01()
                : base(ToastTemplateType.ToastImageAndText01)
            {
            }

            public string Image
            {
                get { return GetImage(1); }
                set { SetImage(1, value); }
            }

            public string Content
            {
                get { return GetText(1); }
                set { SetText(1, value); }
            }
        }

        /// <summary>
        /// A large image, one string of bold text on the first line, one string of regular text wrapped across the second and third lines. 
        /// </summary>
        public class ToastImageAndText02 : ToastTemplateBase
        {
            public ToastImageAndText02()
                : base(ToastTemplateType.ToastImageAndText02)
            {
            }
            public string Image
            {
                get { return GetImage(1); }
                set { SetImage(1, value); }
            }
            public string Title
            {
                get { return GetText(1); }
                set { SetText(1, value); }
            }
            public string Content
            {
                get { return GetText(2); }
                set { SetText(2, value); }
            }
        }

        /// <summary>
        /// A large image, one string of bold text wrapped across the first two lines, one string of regular text on the third line. 
        /// </summary>
        public class ToastImageAndText03 : ToastTemplateBase
        {
            public ToastImageAndText03()
                : base(ToastTemplateType.ToastImageAndText03)
            {
            }
            public string Image
            {
                get { return GetImage(1); }
                set { SetImage(1, value); }
            }
            public string Title
            {
                get { return GetText(1); }
                set { SetText(1, value); }
            }
            public string Content
            {
                get { return GetText(2); }
                set { SetText(2, value); }
            }
        }

        /// <summary>
        /// A large image, one string of bold text on the first line, one string of regular text on the second line, one string of regular text on the third line. 
        /// </summary>
        public class ToastImageAndText04 : ToastTemplateBase
        {
            public ToastImageAndText04()
                : base(ToastTemplateType.ToastImageAndText04)
            {
            }

            public string Image
            {
                get { return GetImage(1); }
                set { SetImage(1, value); }
            }

            public string Title
            {
                get { return GetText(1); }
                set { SetText(1, value); }
            }

            public string ContentLine1
            {
                get { return GetText(2); }
                set { SetText(2, value); }
            }

            public string ContentLine2
            {
                get { return GetText(3); }
                set { SetText(3, value); }
            }
        }

        /// <summary>
        /// A single string wrapped across three lines of text. 
        /// </summary>
        public class ToastText01 : ToastTemplateBase
        {
            public ToastText01()
                : base(ToastTemplateType.ToastText01)
            {
            }
            public string Content
            {
                get { return GetText(1); }
                set { SetText(1, value); }
            }
        }

        /// <summary>
        /// One string of bold text on the first line, one string of regular text wrapped across the second and third lines. 
        /// </summary>
        public class ToastText02 : ToastTemplateBase
        {
            public ToastText02()
                : base(ToastTemplateType.ToastText02)
            {
            }
            public string Title
            {
                get { return GetText(1); }
                set { SetText(1, value); }
            }
            public string Content
            {
                get { return GetText(2); }
                set { SetText(2, value); }
            }
        }

        /// <summary>
        /// One string of bold text wrapped across the first and second lines, one string of regular text on the third line. 
        /// </summary>
        public class ToastText03 : ToastTemplateBase
        {
            public ToastText03()
                : base(ToastTemplateType.ToastText03)
            {
            }
            public string Title
            {
                get { return GetText(1); }
                set { SetText(1, value); }
            }
            public string Content
            {
                get { return GetText(2); }
                set { SetText(2, value); }
            }
        }

        /// <summary>
        /// One string of bold text on the first line, one string of regular text on the second line, one string of regular text on the third line. 
        /// </summary>
        public class ToastText04 : ToastTemplateBase
        {
            public ToastText04()
                : base(ToastTemplateType.ToastText04)
            {
            }

            public string Title
            {
                get { return GetText(1); }
                set { SetText(1, value); }
            }

            public string ContentLine1
            {
                get { return GetText(2); }
                set { SetText(2, value); }
            }

            public string ContentLine2
            {
                get { return GetText(3); }
                set { SetText(3, value); }
            }
        }
    }
}
