﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ChallengeMe
{
    [System.Runtime.Serialization.DataContract]
    /// <summary>
    /// Logique d'interaction pour Niveau9.xaml
    /// </summary>
    public partial class Niveau9 : Window
    {
        //Joueur sérialisé 
        [System.Runtime.Serialization.DataMember] private Joueur j;

        //Musique du jeu 
        private Musique mus = new Musique();

        //Stockage 
        private IStorage storage;

        /// <summary>
        /// Constructeur du niveau 9
        /// </summary>
        /// <param name="j">Joueur</param>
        /// <param name="storage">Stockage</param>
        public Niveau9(Joueur j, IStorage storage)
        {
            InitializeComponent();
            this.j = j;
            this.storage = storage;
        }

        /// <summary>
        /// Méthode pour afficher le pseudonyme du joueur dès l'apparition de la fenêtre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pseudoAfficher(object sender, RoutedEventArgs e)
        {
            this.pseudo.Content = this.j.Nom;
        }

        /// <summary>
        /// Méthode pour afficher le score du joueur dès l'apparition de la fenêtre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void scoreAfficher(object sender, RoutedEventArgs e)
        {
            this.scoring.Content = Convert.ToString(j.Score);
        }

        /// <summary>
        /// Méthode pour changer de niveau dès que l'énigme est résolu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changerNiveau(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (reponse.Text.ToString() == Convert.ToString(87))
                {
                    mus.playVic();
                    this.Hide();
                    this.j.Score += 1;
                    storage.Save(j);
                    Niveau10 p = new Niveau10(j,storage);
                    p.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Ce n'est pas la bonne réponse !!");
                }
            }
        }

        /// <summary>
        /// Méthode lors de la fermeture de la fenêtre pour revenir au Menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backToMain(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
