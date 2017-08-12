using System;

using UIKit;

namespace Lab05
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var translatedNumber = string.Empty;

            translateButton.TouchUpInside += delegate
            {
                var translator = new PhoneTranslator();
                translatedNumber = translator.ToNumber(phoneNumberText.Text);

                if (string.IsNullOrEmpty(translatedNumber))
                {
                    // No hay número a llamar
                    callButton.SetTitle("Llamar", UIControlState.Normal);
                    callButton.Enabled = false;
                }
                else
                {
                    // Hay un posible número telefónico a llamar
                    callButton.SetTitle($"Llamar a {translatedNumber}", UIControlState.Normal);
                    callButton.Enabled = true;
                }
            };

            callButton.TouchUpInside += delegate
            {
                var url = new Foundation.NSUrl($"tel:{translatedNumber}");

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
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}