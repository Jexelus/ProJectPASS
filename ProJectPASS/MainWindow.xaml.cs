using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Walterlv.Demo.Interop;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace ProJectPASS
{
    
    public partial class MainWindow : Window
    {
        string LangType = "Russian";
        int LenForPass = 6;

        public MainWindow()
        {
            InitializeComponent();
            WindowBlur.SetIsEnabled(this, true);
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                return;
            }

        }
        
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }


        private void ExitApp(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MInimButtonClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void CopyButtonClick(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(PasswordField.Text);
        }

        private void PassGen(object sender, RoutedEventArgs e)
        {
            ScriptEngine engine = Python.CreateEngine();
            ScriptScope scope = engine.CreateScope();
            engine.ExecuteFile("C:\\Users\\Twifu\\source\\repos\\ProJectPASS\\ProJectPASS\\PasswordGen.py", scope);
            dynamic passString = scope.GetVariable("Generator");
            
            PasswordField.Text = passString(Convert.ToInt32(LengSlider.Value), LangType);
        }

        private void SVC_Lenght(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            LengBox.Text = "6";
            int val = Convert.ToInt32(e.NewValue);
            LengBox.Text = val.ToString();
        }

        private void LBV_Leng(object sender, TextChangedEventArgs e)
        {
            if (Convert.ToInt32(LengBox.Text) > 48)
            {
                this.LengSlider.Value = 64;
            }else if(Convert.ToInt32(LengBox.Text)<6) 
            {
                this.LengSlider.Value = 6;
            }
        }

        private void SelectorTypeLeng(object sender, SelectionChangedEventArgs e)
        {
            if (LangTypeBox.SelectedItem.ToString().Contains("Russian"))
            {
                LangType = "Russian";
            } 
            else if (LangTypeBox.SelectedItem.ToString().Contains("English"))
            {
                LangType = "English";
            }
            else if (LangTypeBox.SelectedItem.ToString().Contains("Multipl"))
            {
                LangType = "Multipl";
            }
        }
    }
}
