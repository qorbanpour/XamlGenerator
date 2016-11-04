using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections.Generic;

namespace IntegratedSystem
{
    public class Security : INotifyPropertyChanged
    {


        public bool _IsFormReadOnly;
        public bool _IsFormAccessValid;
        public bool _IsEditorReadOnly;
        public bool _IsFormDeleteable;
        public bool _IsFormEditable;
        public bool _IsFormNewable;
        IList<string> PropertiesReadOnly;
        IList<string> PropertiesInVisibility;
       


        private string FormName;
        private int UserID;

     

        public Security(string FormName)
        {
            this.FormName = FormName;
            IsFormAccessValid = true;
            IsFormReadOnly = false;
        }

        public bool IsFormReadOnly
        {
            get { return _IsFormReadOnly; }
            set
            {

                _IsFormReadOnly = value;
                RaisePropertyChanged("IsFormReadOnly");

            }
        }


        public bool IsFormAccessValid
        {
            get { return _IsFormAccessValid; }
            set
            {

                _IsFormAccessValid = value;
                RaisePropertyChanged("IsFormAccessValid");

            }
        }


        public bool IsFormDeleteable
        {
            get { return _IsFormDeleteable; }
            set
            {

                _IsFormDeleteable = value;
                RaisePropertyChanged("IsFormDeleteable");

            }
        }


        public bool IsFormEditable
        {
            get { return _IsFormEditable; }
            set
            {

                _IsFormEditable = value;
                RaisePropertyChanged("IsFormEditable");

            }
        }


        public bool IsFormNewable
        {
            get { return _IsFormNewable; }
            set
            {

                _IsFormNewable = value;
                RaisePropertyChanged("IsFormNewable");

            }
        }

    




        public void GetEditorsReadOnly()
        {



        }

        public bool IsPropertyReadOnly(String EditorName)
        {
            if (PropertiesReadOnly != null)
                return PropertiesReadOnly.Contains(EditorName);
            return false;


        }
        public bool IsPropertyVisible(String EditorName)
        {
            if (PropertiesInVisibility != null)
                return !PropertiesInVisibility.Contains(EditorName);
            return true;


        }

      

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
