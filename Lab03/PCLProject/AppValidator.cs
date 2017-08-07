namespace PCLProject
{
    public class AppValidator
    {
        IDialog _dialog;

        public string Email { get; set; }
        public string Password { get; set; }
        public string Device { get; set; }

        public AppValidator(IDialog platformDialog)
        {
            _dialog = platformDialog;
        }

        public void Validate()
        {
            string result;
            // Aquí se puede implementar la funcionalidad
            // principal de la clase. Por el momento solo devuelve una cadena fija.

            result = "¡Aplicación validada!";

            // Invocar el código específico de la plataforma
            _dialog.Show(result);
        }
    }
}
