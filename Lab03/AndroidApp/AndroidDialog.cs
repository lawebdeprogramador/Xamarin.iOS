using Android.App;
using Android.Content;

namespace AndroidApp
{
    public class AndroidDialog : PCLProject.IDialog
    {
        Context _context;

        public AndroidDialog(Context context)
        {
            _context = context;
        }

        public void Show(string message)
        {
            var alert = new AlertDialog.Builder(_context).Create();
            alert.SetTitle("Resultado de la verificación");
            alert.SetIcon(Resource.Drawable.Icon);
            alert.SetMessage(message);
            alert.SetButton("OK", delegate { });
            alert.Show();
        }
    }
}