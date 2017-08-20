using Foundation;
using System;
using UIKit;

namespace Lab06
{
    public partial class ValidationController : UIViewController
    {
        public ValidationController (IntPtr handle) : base (handle)
        {
        }

        async partial void ValidateButton_TouchUpInside(UIButton sender)
        {
            if (!IsValidCredential())
            {
                return;
            }

            var client = new SALLab06.ServiceClient();
            var result = await client.ValidateAsync(emailText.Text, passwordText.Text, this);
            var alert = UIAlertController.Create("Ressultado", $"{result.Status}\n{result.FullName}\n{result.Token}", 
                UIAlertControllerStyle.Alert);
            alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
            PresentViewController(alert, true, null);
        }

        private bool IsValidCredential()
        {
            return !string.IsNullOrWhiteSpace(emailText.Text) && !string.IsNullOrWhiteSpace(passwordText.Text);
        }
    }
}