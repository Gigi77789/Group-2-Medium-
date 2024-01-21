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
        }

        private void numberTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(numberTextbox.Text, out int ellipseCount)) //turn the number into int
            {
                DrawEllipses(ellipseCount); //if the number is int, then start this method
            }
        }

        private void DrawEllipses(int ellipseCount)
        {
            int ellipseIndex = 0; //Track the current position of the ellipse being processed in the loop
            foreach (var child in myGrid.Children) // search every elements in Canvas
            {
                if (child is Ellipse ellipse) // search that if the element is an ellipse or not
                {
                    ellipse.Visibility = ellipseIndex < ellipseCount ? Visibility.Visible : Visibility.Collapsed;
                    /*deal with the visibility, use"?" to compare the number we input and the number of visible ellipses. 
                     * If the input number is more than number of visiable ellipses,then show more ellipses. 
                     * If the input number is less than number of visiable ellipses,then show mless ellipses.
                     * In total,  the number of visible ellipses equals the number that we input  */
                    ellipseIndex++; //prepare to deal with the next ellipse, be visible or collapsed
                }
            }
        }
    }
 
    
}
