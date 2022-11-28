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
    public sealed partial class AjouterP : Page
    {
        public AjouterP()
        {
            this.InitializeComponent();
            listEmploye.ItemsSource = GestionBDE.getInstance().GetEmployes();

        }

        private void btAjt_Click(object sender, RoutedEventArgs e)
        {
            int valide = 0;
            bool valide1 = true;

            reset();

            /*
             * vous pouvez choisir l'une ou l'autre façon de gérer
             * la vérification des champs
             * Commentez une façon et décommentez l'autre 
             */


            /*première façon de gérer la vérification*/
            if (tbxNum.Text.Trim() == "")
            {
                tblErreurNum.Visibility = Visibility.Visible;
                valide += 1;
            }

            if (tbxDat.SelectedDate == null)
            {
                tblErreurDat.Visibility = Visibility.Visible;
                valide += 1;
            }

            if (tbxBud.Text.Trim() == "" )
                
            {
                tblErreurBud.Visibility = Visibility.Visible;
                valide += 1;
            }

            if (tbxDesc.Text.Trim() == "")
            {
                tblErreurDesc.Visibility = Visibility.Visible;
                valide += 1;
            }
            if (listEmploye.SelectedIndex == -1)
            {
                tblErreurNom.Visibility = Visibility.Visible;
                valide += 1;
            }
            if (valide == 0 && valide1 == true)
            {
                Employe emp = listEmploye.SelectedItem as Employe;


                Projet po = new Projet()
                {
                    Numero = tbxNum.Text,
                    Date = tbxDat.SelectedDate.Value.ToString("yyyy-MM-dd"),
                    Budget = tbxBud.Text,//Convert.ToInt32
                    Description = tbxDesc.Text,
                    Employe =  emp.Matricule,
                    

                };
                GestionBD.getInstance().AjouterProjet(po);
                tblsucces.Visibility = Visibility.Visible;


            }


        }
        private void reset()
        {
            tblErreurNum.Visibility = Visibility.Collapsed;
            tblErreurDat.Visibility = Visibility.Collapsed;
            tblErreurBud.Visibility = Visibility.Collapsed;
            tblErreurDesc.Visibility = Visibility.Collapsed;
            tblErreurNom.Visibility = Visibility.Collapsed;
            

        }
    }
}
