using RegistroUsuarios.BLL;
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

namespace RegistroUsuarios.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cUsuarios.xaml
    /// </summary>
    public partial class cUsuarios : Window
    {
        public cUsuarios()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Usuarios>();
            if (string.IsNullOrWhiteSpace(CriterioTextBox.Text))
            {
                listado = UsuariosBLL.GetList(e => true);
            }
            else
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = UsuariosBLL.GetList(e => e.UsuarioId == Convert.ToInt32(CriterioTextBox.Text));
                        break;
                    case 1:
                        listado = UsuariosBLL.GetList(e => e.NombreUsuario.Contains(CriterioTextBox.Text));
                        break;
                }
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}
