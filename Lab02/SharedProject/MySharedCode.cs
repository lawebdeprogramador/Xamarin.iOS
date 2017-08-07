using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SharedProject
{
    class MySharedCode
    {
        public string GetFilePath(string fileName)
        {
#if WINDOWS_UWP
            return Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, fileName);
#elif __ANDROID__
            string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(libraryPath, fileName);
#elif WINDOWS_WPF
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), fileName);
#endif
        }
    }
}
