
namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.AccesoPerfil
{
    public class UsuarioDto
    {
        public int ID_USUARIO { get; set; }
        public string SIGLA_USUARIO { get; set; }
        public string NOMBRE { get; set; }
        public string VIGENTE { get; set; }
        public int ID_AREA { get; set; }
        public string CORREO { get; set; }

        //public virtual FUWEB_P_AREA FUWEB_P_AREA { get; set; }
    }
}
