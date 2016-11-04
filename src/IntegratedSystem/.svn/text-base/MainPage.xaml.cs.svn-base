using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;

namespace IntegratedSystem
{
    public partial class MainPage : UserControl
    {
        bool MenuIsOpen = false;
        bool backgroundOneIsSet = true;
        bool backgroundTwoIsSet = false;
        bool ColorIsGreen = false;
        bool ColorIsBlue = true;
        public MainPage()
        {
            InitializeComponent();
        }

        // After the Frame navigates, ensure the HyperlinkButton representing the current page is selected
        private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
        {
            //foreach (UIElement child in LinksStackPanel.Children)
            //{
            //    HyperlinkButton hb = child as HyperlinkButton;
            //    if (hb != null && hb.NavigateUri != null)
            //    {
            //        if (hb.NavigateUri.ToString().Equals(e.Uri.ToString()))
            //        {
            //            VisualStateManager.GoToState(hb, "ActiveLink", true);
            //        }
            //        else
            //        {
            //            VisualStateManager.GoToState(hb, "InactiveLink", true);
            //        }
            //    }
            //}
        }

        // If an error occurs during navigation, show an error window
        private void ContentFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            /************************ Added By ME*/
            Exception ex = e.Exception;

            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            /*************************************/

            e.Handled = true;
            ChildWindow errorWin = new ErrorWindow(ex);
            errorWin.Show();

             errorWin = new ErrorWindow(e.Uri);
            errorWin.Show();
            //e.Handled = true;
            //ChildWindow errorWin = new ErrorWindow(e.Uri);
            //errorWin.Show();
        }
        private void Blue_MouseEnter(object sender, MouseEventArgs e)
        {
            BlueColorChooserMouseEnter.Begin();
        }

        private void Blue_MouseLeave(object sender, MouseEventArgs e)
        {
            BlueColorChooserMouseLeave.Begin();
        }

        private void Green_MouseEnter(object sender, MouseEventArgs e)
        {
            GreenColorChooserMouseEnter.Begin();
        }

        private void Green_MouseLeave(object sender, MouseEventArgs e)
        {
            GreenColorChooserMouseLeave.Begin();
        }

        private void Yellow_MouseEnter(object sender, MouseEventArgs e)
        {
            YellowColorChooserMouseEnter.Begin();
        }

        private void Yellow_MouseLeave(object sender, MouseEventArgs e)
        {
            YellowColorChooserMouseLeave.Begin();
        }

        private void Ellipse_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MenuIsOpen == false)
            {
                MenuIsOpen = true;
                MenuExpantion.Begin();
            }
            else
            {
                MenuIsOpen = false;
                MenuClose.Begin();
            }
        }


        private void BackgrounImageFadeOut_Completed(object sender, EventArgs e)
        {
            if (backgroundOneIsSet)
            {

                ImageBrush im1 = new ImageBrush();
                im1.ImageSource = new BitmapImage(new Uri("images/mnt2.jpg", UriKind.Relative));
                grid1.Background = im1;
                BackgroundImageFadeIn.Begin();
            }
            if (backgroundTwoIsSet)
            {
                ImageBrush im = new ImageBrush();
                im.ImageSource = new BitmapImage(new Uri("images/mnt1.jpg", UriKind.Relative));
                grid1.Background = im;
                BackgroundImageFadeIn.Begin();
            }
        }

        private void BackgrounImageOne_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (backgroundOneIsSet == false)
            {
                backgroundOneIsSet = true;
                backgroundTwoIsSet = false;
                BackgrounImageFadeOut.Begin();
            }
        }

        private void BackgroundImageTwo_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (backgroundTwoIsSet == false)
            {
                backgroundTwoIsSet = true;
                backgroundOneIsSet = false;
                BackgrounImageFadeOut.Begin();
            }
        }

        private void Green_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!ColorIsGreen)
            {
                BlueToGreenAnimation.Begin();
                ColorIsGreen = true;
                ColorIsBlue = false;
            }
        }

        private void Blue_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!ColorIsBlue)
            {
                GreenToBlue.Begin();
                ColorIsBlue = true;
                ColorIsGreen = false;
            }
        }

        private void ellipse_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            // TODO: Add event handler implementation here.
            EllipseMouseEngerAnimation.Begin();

        }

        private void ellipse_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            // TODO: Add event handler implementation here.
            EllipseMouseLeaveAnimation.Begin();
        }

        private void BackgrounImageOne_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            // TODO: Add event handler implementation here.
            if (!backgroundOneIsSet)
            {
                BackgroundOneMouseEnter.Begin();
            }
        }

        private void BackgrounImageOne_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            // TODO: Add event handler implementation here.
            if (!backgroundOneIsSet)
            {
                BackgroundOneMouseLeave.Begin();
            }
        }

        private void BackgroundImageTwo_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            // TODO: Add event handler implementation here.

        }

        private void BackgroundImageTwo_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            // TODO: Add event handler implementation here.

        }


       
    }
}