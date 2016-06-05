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

namespace WpfExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   /// <summary>
    /// will be used to keep track of the numeric up down veiw sense wpf does not have one built in
    /// </summary>
        double msecondMathValue = 0, mfirstMathValue = 0;
        /// <summary>
        /// used to track what selected item in the combo box is.
        /// </summary>
        int mIndexBaseCal = 0, mIndexChildCal = 1;
        BaseCalculator PolyMorphicCalcultor;
        /// <summary>
        /// keeps the scroll at .5 sense value range is from 0 to 1
        /// also kept at .5 so i can esaier detect which changed as actually happend up or down.
        /// </summary>
        double mMidPointforScrollBar = .5d;
        double mincrementValue = .5d;
        public MainWindow()
        {
            InitializeComponent();
            // set the scrollbar to mid value
            scrollBarTwo.Value = scrollBarOne.Value = mMidPointforScrollBar;
          // setting this here will call the combobox index change callback below
            comboBoxCalSelect.SelectedIndex = mIndexBaseCal;
        }
        /// <summary>
        /// call back when a scroll arrow is changed, this for changing first and second values for the caculators
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void scrollBarUpDownButtons(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {
            if(incrementValue(e.NewValue))
                setScrollBar(((ScrollBar)(e.Source)), mincrementValue);
            else
               setScrollBar(((ScrollBar)(e.Source)), -mincrementValue);

        }
        private bool incrementValue(double _NewValue)
        {
            if (_NewValue < mMidPointforScrollBar)
            {
                return true;
            }
            else
           if (_NewValue > mMidPointforScrollBar)
            {
                return false;
            }
            return false;
        }

     
        private void setScrollBar( ScrollBar _bar, double _incrementby)
        {
            if(_bar == scrollBarTwo)
            {
                labelNumTwo.Content =  msecondMathValue += _incrementby;
                scrollBarTwo.Value = mMidPointforScrollBar;
            }
            else
              if (_bar == scrollBarOne)
            {
                labelNumOne.Content = mfirstMathValue += _incrementby;
                scrollBarOne.Value = mMidPointforScrollBar;
            }

        }


        private void buttonSubtract_Click(object sender, RoutedEventArgs e)
        {
            labelTotal.Content = PolyMorphicCalcultor.subtract(mfirstMathValue, msecondMathValue);
          
        }

        private void comboBoxCalSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

           if(comboBoxCalSelect.SelectedIndex == mIndexBaseCal)
            {
                PolyMorphicCalcultor = new BaseCalculator();
            }
           else
           if(comboBoxCalSelect.SelectedIndex == mIndexChildCal)
            {
                PolyMorphicCalcultor = new ChildCalculator();
            }
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            labelTotal.Content = PolyMorphicCalcultor.add(mfirstMathValue, msecondMathValue);
        }
    }
}
