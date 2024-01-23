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

namespace Group_2__Medium_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        private void numberTextbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out int result);
        } /* if "int.TryParse" successfully turn the input into a int, it will return a ture, then"!int.TryParse" will be false
           if 'e.Handled" is false, then the input will be showed in the textbox*/

        private void numberTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(numberTextbox.Text, out int ellipseInput)) //turn the number into int
            {
                DrawEllipses(ellipseInput); //if the number is int, then start this method
            }
        }

        private void DrawEllipses(int ellipseInput)
        {
            int ellipseNumber = 0; //start to deal with the first ellipse  
            // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements; 
            foreach (var element in myGrid.Children) /* use Loop "foreach" to search every elements on Canvas
                                                      https://www.tutorialsteacher.com/articles/foreach-loop-in-csharp
                */
            {
                if (element is Ellipse ellipse) /* use "is" to determine that if the element is an ellipse or not,
                                               if it is, then this selected ellipse will be saved in the variable "ellipse"
                                               https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/pattern-matching*/

                {
                    if (ellipseNumber < ellipseInput)
                    {
                        ellipse.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        ellipse.Visibility = Visibility.Collapsed;
                    }
                    /*deal with the visibility of the ellipse in the variable "ellipse"
                     * Use"if" to compare the number we input and the number of "ellipseIndex". 
                     * If the input number is more than number of "ellipseIndex",then show this ellipse. 
                     * If the input number is less than number of "ellipseIndex",then collapse thus ellipse.*/

                    ellipseNumber++; //prepare to deal with the next ellipse, continue the loop
                    /* The loop stops when the number of "ellipseIndex equals the number that we input  */
                }
            }
        }
    }
 
    
}
