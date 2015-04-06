using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;

namespace Usuarios.WebPartUsuarios
{
    [ToolboxItemAttribute(false)]
    public partial class WebPartUsuarios : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public WebPartUsuarios()
        {
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            var usuario = SPContext.Current.Web.CurrentUser;
            var roles = SPContext.Current.Web.RoleDefinitions;
            var texto = String.Format("Hola {0} {1} bienvenido", usuario.Name, usuario.Email);

            lblUsuario.Text = texto;

            var usuarios = SPContext.Current.Web.AllUsers;

            foreach (SPUser usu in usuarios)
            {
                var tx = String.Format("Usuario {0} <br/>", usu.Name);
                lblUsuarios.Text += tx;
            }
            
            foreach (SPRoleDefinition rol in roles)
            {
                var tx = String.Format("Rol {0} <br/>", rol.Name);
                lblRoles.Text += tx;
            }
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnOutPerm_Click(object sender, EventArgs e)
        {

        }
    }
}
