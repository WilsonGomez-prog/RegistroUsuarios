using System;
using System.ComponentModel.DataAnnotations;

namespace RegistroUsuarios.Entidades
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Es necesario ingresar el nombre de la persona.")]
        [MaxLength(30, ErrorMessage = "El nombre no puede exceder de 30 caracteres.")]
        public string Nombre { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Es necesario ingresar el apellido de la persona.")]
        [MaxLength(30, ErrorMessage = "El apellido no puede exceder de 30 caracteres.")]
        public string Apellido { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Es necesario ingresar el nombre de usuario.")]
        [MaxLength(16, ErrorMessage = "El nombre de usuario no puede exceder de 16 caracteres.")]
        public string NombreUsuario { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Es necesario ingresar la clave de la cuenta.")]
        public string Clave { get; set; }

        public Usuarios()
        {
            UsuarioId = 0;
            Nombre = "";
            Apellido = "";
            NombreUsuario = "";
            Clave = "";
        }

        public Usuarios(string nombre, string apellido, string username, string password)
        {
            Nombre = nombre;
            Apellido = "";
            NombreUsuario = username;
            Clave = password;
        }
    }
}