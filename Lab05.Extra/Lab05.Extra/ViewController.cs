using System;

using UIKit;

namespace Lab05.Extra
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            button0.TouchUpInside += Button_TouchUpInside;
            button1.TouchUpInside += Button_TouchUpInside;
            button2.TouchUpInside += Button_TouchUpInside;
            button3.TouchUpInside += Button_TouchUpInside;
            button4.TouchUpInside += Button_TouchUpInside;
            button5.TouchUpInside += Button_TouchUpInside;
            button6.TouchUpInside += Button_TouchUpInside;
            button7.TouchUpInside += Button_TouchUpInside;
            button8.TouchUpInside += Button_TouchUpInside;
            button9.TouchUpInside += Button_TouchUpInside;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        private void Button_TouchUpInside(object sender, EventArgs e)
        {
            mainLabel.Text += (sender as UIButton)?.Title(UIControlState.Normal);
        }
    }
}