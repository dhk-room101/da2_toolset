using System.Reactive;
using System.Reactive.Linq;
using MVVMSidekick.ViewModels;
using MVVMSidekick.Views;
using MVVMSidekick.Reactive;
using MVVMSidekick.Services;
using MVVMSidekick.Commands;
using Toolset.WPF.ViewModels;
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
using Gibbed.Bioware.FileFormats;

namespace Toolset.WPF
{
     /// <summary>
     /// Interaction logic for MainWindow.xaml
     /// </summary>
     public partial class MainWindow : MVVMWindow
     {
          public static ToolsetDataContext toolsetDataContext = new ToolsetDataContext();
          public static string gamePath = null;
          public static string da2UserPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\BioWare\Dragon Age 2\";
          public static string toolsetPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
          public static GenericFile_Type gffType = new GenericFile_Type();
          public static MainWindow_Model parentMainModel;

          public MainWindow()
               : base(null)
          {
               InitializeComponent();
          }

          public MainWindow(MainWindow_Model model)
               : base(model)
          {
               InitializeComponent();
          }
     }
}
