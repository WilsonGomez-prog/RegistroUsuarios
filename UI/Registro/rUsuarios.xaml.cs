﻿using RegistroUsuarios.BLL;
using RegistroUsuarios.Entidades;
using System;
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

namespace RegistroUsuarios.UI.Registro
{
    /// <summary>
    /// Interaction logic for rUsuarios.xaml
    /// </summary>
    public partial class rUsuarios : Window
    {
        Usuarios Usuario;
        public rUsuarios()
        {
            InitializeComponent();
            Usuario = new Usuarios();
            this.DataContext = Usuario;
        }

        private void Limpiar()
        {
            Usuario = new Usuarios();
            ClaveTextBox.Password = string.Empty;
            ClaveVerificacionTextBox.Password = string.Empty;
            this.DataContext = Usuario;
        }

        private bool Validar()
        {
            bool valido = true;

            if(!ValidarCasillaTexto(NombreTextBox.Text))
            {
                valido = false;
                MessageBox.Show("La casilla nombre no puede tener \nnumeros ni caracteres especiales.", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if(!ValidarCasillaTexto(ApellidoTextBox.Text))
            {
                valido = false;
                MessageBox.Show("La casilla apellido no puede tener \nnumeros ni caracteres especiales.", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!ValidarUserName(NombreUsuarioTextBox.Text))
            {
                valido = false;
                MessageBox.Show("La casilla nombre de usuario no puede tener \n caracteres especiales.", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (UsuariosBLL.Existe(Convert.ToInt32(UsuarioIdTextBox.Text), NombreUsuarioTextBox.Text))
            {
                valido = false;
                MessageBox.Show("El nombre de usuario ingresado en la casilla\n'Nombre de usuario' ya pertenece a otro usuario,\n ingrese uno diferente.", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if(string.IsNullOrWhiteSpace(ClaveTextBox.Password) || ClaveTextBox.Password.Length < 6)
            {
                valido = false;
                MessageBox.Show("Es necesario ingresar una clave con un minimo de 6 caracteres.", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (string.IsNullOrWhiteSpace(ClaveVerificacionTextBox.Password))
            {
                valido = false;
                MessageBox.Show("Es necesario es necesario verificar la clave ingresada.", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return valido;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var usuario = UsuariosBLL.Buscar(Convert.ToInt32(UsuarioIdTextBox.Text));

            if(usuario != null)
            {
                Usuario = usuario;
            }
            else
            {
                Limpiar();
            }

            this.DataContext = Usuario;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (Validar())
            {
                Usuario.Clave = ClaveTextBox.Password;

                bool guardo = UsuariosBLL.Guardar(Usuario);

                if (guardo)
                {
                    Limpiar();
                    MessageBox.Show("El usuario ha sido guardado correctamente", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("El usuario no ha podido ser guardado.", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if(UsuariosBLL.Eliminar(Convert.ToInt32(UsuarioIdTextBox.Text)))
            {
                MessageBox.Show("El usuario ha sido eliminado correctamente.", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("El usuario no pudo ser eliminado.", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool ValidarCasillaNumerica(string texto)
        {
            foreach (char invalido in texto.ToCharArray())
            {
                if (!Char.IsDigit(invalido))
                {
                    return false;
                }
            }

            return true;
        }

        private bool ValidarCasillaTexto(string texto)
        {

            foreach (char carac in texto.ToCharArray())
            {
                if (!Char.IsLetter(carac))
                {
                    return false;
                }
            }

            return true;
        }

        private bool ValidarUserName(string texto)
        {
            foreach (char invalido in texto.ToCharArray())
            {
                if (!Char.IsLetterOrDigit(invalido))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
