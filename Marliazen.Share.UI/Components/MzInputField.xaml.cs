using System.Windows;
using System.Windows.Controls;

namespace Marliazen.Share.UI.Components
{
    /// <summary>
    /// Logique d'interaction pour MzInputField.xaml
    /// </summary>
    public partial class MzInputField : UserControl
    {
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string),
                typeof(MzInputField), new FrameworkPropertyMetadata(string.Empty, LabelPropertyChangedCallback));

        public static readonly DependencyProperty LabelWidthProperty =
            DependencyProperty.Register("LabelWidth", typeof(GridLength), typeof(MzInputField),
                new FrameworkPropertyMetadata(GridLength.Auto, LabelWidthPropertyChangedCallback));

        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(string), typeof(MzInputField),
                new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    ContentPropertyChangedCallback));

        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        public GridLength LabelWidth
        {
            get => (GridLength)GetValue(LabelWidthProperty);
            set => SetValue(LabelWidthProperty, value);
        }

        public string Content
        {
            get => (string)GetValue(ContentProperty);
            set => SetValue(ContentProperty, value);
        }

        public MzInputField()
        {
            InitializeComponent();
        }

        private static void LabelPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MzInputField obj)
            {
                obj.Label = (string)e.NewValue;
                obj.LabelField.Content = (string)e.NewValue;
            }
        }

        private static void LabelWidthPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MzInputField obj)
            {
                obj.LabelWidth = (GridLength)e.NewValue;
                obj.LabelColumn.Width = (GridLength)e.NewValue;
            }
        }

        private static void ContentPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MzInputField obj)
            {
                obj.Content = (string)e.NewValue;
                obj.ValueField.Text = (string)e.NewValue;
            }
        }
    }
}