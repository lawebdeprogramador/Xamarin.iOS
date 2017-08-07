using Android.App;
using Android.Widget;
using Android.OS;

namespace AndroidApp
{
    [Activity(Label = "AndroidApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Creamos la instancia del código compartido
            // y le inyectamos la dependencia.
            var validator = new PCLProject.AppValidator(new AndroidDialog(this));

            // Aquí podríamos establecer los valores de las propriedades
            // Email, Password y Device

            // Realizamos la validación
            validator.Validate();

            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
        }
    }
}

