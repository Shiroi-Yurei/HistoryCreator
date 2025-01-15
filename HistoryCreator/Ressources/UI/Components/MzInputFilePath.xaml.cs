using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HistoryCreator.Ressources.UI.Components
{
    /// <summary>
    /// Logique d'interaction pour MzInputFilePath.xaml
    /// </summary>
    public partial class MzInputFilePath : UserControl
    {
        public static DependencyProperty LabelTextProperty = DependencyProperty.Register(nameof(LabelText), 
            typeof(string), typeof(MzInputFilePath), new PropertyMetadata(string.Empty));

        public static DependencyProperty PathProperty = DependencyProperty.Register(nameof(Path),
            typeof(string), typeof(MzInputFilePath), new PropertyMetadata(string.Empty));

        public static DependencyProperty DefaultPathProperty = DependencyProperty.Register(nameof(DefaultPath),
            typeof(string), typeof(MzInputFilePath), new PropertyMetadata((string.Empty)));

        public string LabelText
        {
            get => (string)GetValue(LabelTextProperty);
            set => SetValue(LabelTextProperty, value);
        }

        public string Path
        {
            get => (string)(GetValue(PathProperty));
            set => SetValue(PathProperty, value);
        }

        public string DefaultPath
        {
            get => (string)(GetValue(DefaultPathProperty));
            set => SetValue(DefaultPathProperty, value);
        }

        public MzInputFilePath()
        {
            InitializeComponent();

            DialogButton.Click += DialogButton_OnClick;
        }

        private void DialogButton_OnClick(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFolderDialog();
            dialog.DefaultDirectory = DefaultPath;
            dialog.InitialDirectory = DefaultPath;

            dialog.ShowDialog();

            Path = dialog.FolderName;
        }

        public override void OnApplyTemplate()
        {
            var labelTextBinding = new Binding
            {
                Path = new PropertyPath(nameof(LabelText)),
                Source = this
            };

            var pathProperty = new Binding
            {
                Path = new PropertyPath(nameof(Path)),
                Source = this
            };

            var defaultProperty = new Binding
            {
                Path = new PropertyPath(nameof(DefaultPath)),
                Source = this
            };

            LabelPart.SetBinding(Label.ContentProperty, labelTextBinding);
            DataPart.SetBinding(TextBox.TextProperty, pathProperty);

            base.OnApplyTemplate();
        }
    }
}
