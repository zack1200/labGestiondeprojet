// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Labgestiondeprojet
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AjouterE : Page
    {
        public AjouterE()
        {
            this.InitializeComponent();
        }

        private void btAjt_Click(object sender, RoutedEventArgs e)
        {
            int valide = 0;
            bool valide1 = true;

            reset();

            if (tbxMat.Text.Trim() == "")
            {
                tblErreurMat.Visibility = Visibility.Visible;
                valide += 1;
            }

            if (tbxNom.Text.Trim() == "")
            {
                tblErreurNom.Visibility = Visibility.Visible;
                valide += 1;
            }

            if (tbxPrenom.Text.Trim() == "")
            {
                tblErreurPrenom.Visibility = Visibility.Visible;
                valide += 1;
            }

            if (valide == 0 && valide1 == true)
            {
                Employe emp = new Employe()
                {
                    Matricule = tbxMat.Text,
                    Nom = tbxNom.Text,
                    Prenom = tbxPrenom.Text,

                };
                GestionBDE.getInstance().AjouterEmployer(emp);
                tblEmp.Visibility = Visibility.Visible;
            } 
        }
        private void reset()
        {
            tblErreurMat.Visibility = Visibility.Collapsed;
            tblErreurNom.Visibility = Visibility.Collapsed;
            tblErreurPrenom.Visibility = Visibility.Collapsed;
           

        }
    }
}
