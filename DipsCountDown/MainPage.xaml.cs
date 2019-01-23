using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DipsCountDown
{
    public sealed partial class MainPage : Page
    {
        private DispatcherTimer timer;
        private double diff;

        public MainPage()
        {
            this.NavigationCacheMode = NavigationCacheMode.Required;
            this.InitializeComponent();

            var now = DateTime.Now;
            var end = new DateTime(2019, 4, 1);
            diff = (end - now).TotalSeconds;

            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += timer_Tick;

            this.Background = new SolidColorBrush(Color.FromArgb(255,207,48,44));

            timer.Start();
        }

        void timer_Tick(object sender, object e)
        {
            diff = diff - 1;
            var timespan = TimeSpan.FromSeconds(diff);
            CountDown.Text = $"{timespan.Days} dag(er) {timespan.Hours} time(r) {timespan.Minutes} min. {timespan.Seconds} s.";
            if (diff == 0)
            {
                timer.Stop();
            }

        }
    }
}
