using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PumConverter
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        const double FootToMeters = 0.3048;
        const double InchToMeters = 0.0254;

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void convertButton_Click(object sender, RoutedEventArgs e)
        {
            var meteres = double.Parse(inputEntry.Text);
            var feet = Math.Floor(meteres / FootToMeters);
            var inches = Math.Round((meteres - feet * FootToMeters)/InchToMeters);
            if (inches == 12.0) { feet += 1;inches = 0; }
            if (feet == 0)
                outputLabel.Text = $"{meteres}m equals {inches}''";
            else if (inches == 0)
                outputLabel.Text = $"{meteres}m equals {feet}'";
            else
                outputLabel.Text = $"{meteres}m equals {feet}'{inches}''";
        }
    }
}
