using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace Lab06.NavigationThroughCode
{
    public partial class ViewController : UIViewController
    {
        // Perform any additional setup after loading the view, typically from a nib.

        private string _translatedNumber = string.Empty;
        List<string> _phoneNumbers = new List<string>();

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            translateButton.TouchUpInside += delegate
            {
                var translator = new PhoneTranslator();
                _translatedNumber = translator.ToNumber(phoneNumberText.Text);

                if (string.IsNullOrEmpty(_translatedNumber))
                {
                    // No hay número a llamar
                    callButton.SetTitle("Llamar", UIControlState.Normal);
                    callButton.Enabled = false;
                }
                else
                {
                    // Hay un posible número telefónico a llamar
                    callButton.SetTitle($"Llamar a {_translatedNumber}", UIControlState.Normal);
                    callButton.Enabled = true;
                }
            };

            callButton.TouchUpInside += delegate
            {
                _phoneNumbers.Add(_translatedNumber);
                var url = new NSUrl($"tel:{_translatedNumber}");

                // Utilizar el manejador de URL con el prefijo tel: para invocar a la 
                // aplicación Phone de Apple, de lo contrario mostrar un diálogo de alerta.

                if (!UIApplication.SharedApplication.OpenUrl(url))
                {
                    var alert = UIAlertController.Create("No soportado", "El esquema 'tel:' no es soportado en este dispositivo", 
                        UIAlertControllerStyle.Alert);
                    alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                    PresentViewController(alert, true, null);
                }
            };

            callHistoryButton.TouchUpInside += delegate
            {
                CallHistoryController controller = Storyboard.InstantiateViewController("CallHistoryController") as CallHistoryController;

                if (controller != null)
                {
                    controller.PhoneNumbers = _phoneNumbers;
                    NavigationController.PushViewController(controller, true);
                }
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        //public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        //{
        //    base.PrepareForSegue(segue, sender);

        //    // ¿Se desea realizar la transición a CallHistoryController ?
        //    if (segue.DestinationViewController is CallHistoryController)
        //    {
        //        // Proporcionar la lista de números telefónicos al CallHistoryController
        //        (segue.DestinationViewController as CallHistoryController).PhoneNumbers = _phoneNumbers;
        //    }
        //}
    }
}