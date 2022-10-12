using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace WpfCasino
{
    class Statics
    {
        public static void TryCatch(Action aAction, string aTitreMsgBox)
        {
            try
            {
                aAction();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, aTitreMsgBox, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
