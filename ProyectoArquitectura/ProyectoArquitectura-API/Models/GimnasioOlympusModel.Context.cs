﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoArquitectura_API.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class GimnasioOlympusEntities : DbContext
    {
        public GimnasioOlympusEntities()
            : base("name=GimnasioOlympusEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DetalleCuerpoUsuario> DetalleCuerpoUsuarios { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<TipoEstado> TipoEstadoes { get; set; }
        public virtual DbSet<TipoRol> TipoRols { get; set; }
        public virtual DbSet<Menbresia> Menbresias { get; set; }
        public virtual DbSet<MenbresiasUsuario> MenbresiasUsuarios { get; set; }
        public virtual DbSet<TipoMembresia> TipoMembresias { get; set; }
        public virtual DbSet<UsuarioPersona> UsuarioPersonas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<PersonaDetalleCuerpoView> PersonaDetalleCuerpoViews { get; set; }
        public virtual DbSet<PersonasSinUsuario> PersonasSinUsuarios { get; set; }
        public virtual DbSet<PersonaView> PersonaViews { get; set; }
        public virtual DbSet<UsuariosView> UsuariosViews { get; set; }
        public virtual DbSet<PersonaMetricas> PersonaMetricas { get; set; }
        public virtual DbSet<UsuariosMetricas> UsuariosMetricas { get; set; }
        public virtual DbSet<TipoMembresiaIDMetricas> TipoMembresiaIDMetricas { get; set; }
        public virtual DbSet<Metricas> Metricas { get; set; }
    
        public virtual int Sp_ActualizarCliente(Nullable<int> idCliente, string numemeroTelefono, string direccion, Nullable<decimal> peso, Nullable<decimal> altura, Nullable<decimal> porcentajeMasaMuscular, Nullable<decimal> porcentajeGrasaCorporal, ObjectParameter mensaje)
        {
            var idClienteParameter = idCliente.HasValue ?
                new ObjectParameter("IdCliente", idCliente) :
                new ObjectParameter("IdCliente", typeof(int));
    
            var numemeroTelefonoParameter = numemeroTelefono != null ?
                new ObjectParameter("NumemeroTelefono", numemeroTelefono) :
                new ObjectParameter("NumemeroTelefono", typeof(string));
    
            var direccionParameter = direccion != null ?
                new ObjectParameter("Direccion", direccion) :
                new ObjectParameter("Direccion", typeof(string));
    
            var pesoParameter = peso.HasValue ?
                new ObjectParameter("Peso", peso) :
                new ObjectParameter("Peso", typeof(decimal));
    
            var alturaParameter = altura.HasValue ?
                new ObjectParameter("Altura", altura) :
                new ObjectParameter("Altura", typeof(decimal));
    
            var porcentajeMasaMuscularParameter = porcentajeMasaMuscular.HasValue ?
                new ObjectParameter("PorcentajeMasaMuscular", porcentajeMasaMuscular) :
                new ObjectParameter("PorcentajeMasaMuscular", typeof(decimal));
    
            var porcentajeGrasaCorporalParameter = porcentajeGrasaCorporal.HasValue ?
                new ObjectParameter("PorcentajeGrasaCorporal", porcentajeGrasaCorporal) :
                new ObjectParameter("PorcentajeGrasaCorporal", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Sp_ActualizarCliente", idClienteParameter, numemeroTelefonoParameter, direccionParameter, pesoParameter, alturaParameter, porcentajeMasaMuscularParameter, porcentajeGrasaCorporalParameter, mensaje);
        }
    
        public virtual int Sp_AcualizarUsuario(Nullable<int> idUsuario, Nullable<int> tipoEstadoID, Nullable<int> tipoRol_ID, string password, ObjectParameter mensaje)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            var tipoEstadoIDParameter = tipoEstadoID.HasValue ?
                new ObjectParameter("TipoEstadoID", tipoEstadoID) :
                new ObjectParameter("TipoEstadoID", typeof(int));
    
            var tipoRol_IDParameter = tipoRol_ID.HasValue ?
                new ObjectParameter("TipoRol_ID", tipoRol_ID) :
                new ObjectParameter("TipoRol_ID", typeof(int));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Sp_AcualizarUsuario", idUsuarioParameter, tipoEstadoIDParameter, tipoRol_IDParameter, passwordParameter, mensaje);
        }
    
        public virtual int Sp_EliminarCliente(Nullable<int> idPersona, ObjectParameter mensaje)
        {
            var idPersonaParameter = idPersona.HasValue ?
                new ObjectParameter("IdPersona", idPersona) :
                new ObjectParameter("IdPersona", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Sp_EliminarCliente", idPersonaParameter, mensaje);
        }
    
        public virtual int Sp_EliminarUsuario(Nullable<int> idUsuario, ObjectParameter mensaje)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Sp_EliminarUsuario", idUsuarioParameter, mensaje);
        }
    
        public virtual int Sp_InsertarPersona(string nombre, string identificacion, string primerApellido, string segundoApellido, string direccion, string correoElectronico, string numeroTelefono, Nullable<decimal> peso, Nullable<decimal> altura, Nullable<decimal> porcentajeMasaMuscular, Nullable<decimal> porcentajeGrasaCorporal, ObjectParameter mensaje)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var identificacionParameter = identificacion != null ?
                new ObjectParameter("Identificacion", identificacion) :
                new ObjectParameter("Identificacion", typeof(string));
    
            var primerApellidoParameter = primerApellido != null ?
                new ObjectParameter("PrimerApellido", primerApellido) :
                new ObjectParameter("PrimerApellido", typeof(string));
    
            var segundoApellidoParameter = segundoApellido != null ?
                new ObjectParameter("SegundoApellido", segundoApellido) :
                new ObjectParameter("SegundoApellido", typeof(string));
    
            var direccionParameter = direccion != null ?
                new ObjectParameter("Direccion", direccion) :
                new ObjectParameter("Direccion", typeof(string));
    
            var correoElectronicoParameter = correoElectronico != null ?
                new ObjectParameter("CorreoElectronico", correoElectronico) :
                new ObjectParameter("CorreoElectronico", typeof(string));
    
            var numeroTelefonoParameter = numeroTelefono != null ?
                new ObjectParameter("NumeroTelefono", numeroTelefono) :
                new ObjectParameter("NumeroTelefono", typeof(string));
    
            var pesoParameter = peso.HasValue ?
                new ObjectParameter("Peso", peso) :
                new ObjectParameter("Peso", typeof(decimal));
    
            var alturaParameter = altura.HasValue ?
                new ObjectParameter("Altura", altura) :
                new ObjectParameter("Altura", typeof(decimal));
    
            var porcentajeMasaMuscularParameter = porcentajeMasaMuscular.HasValue ?
                new ObjectParameter("PorcentajeMasaMuscular", porcentajeMasaMuscular) :
                new ObjectParameter("PorcentajeMasaMuscular", typeof(decimal));
    
            var porcentajeGrasaCorporalParameter = porcentajeGrasaCorporal.HasValue ?
                new ObjectParameter("PorcentajeGrasaCorporal", porcentajeGrasaCorporal) :
                new ObjectParameter("PorcentajeGrasaCorporal", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Sp_InsertarPersona", nombreParameter, identificacionParameter, primerApellidoParameter, segundoApellidoParameter, direccionParameter, correoElectronicoParameter, numeroTelefonoParameter, pesoParameter, alturaParameter, porcentajeMasaMuscularParameter, porcentajeGrasaCorporalParameter, mensaje);
        }
    
        public virtual int Sp_InsertarUsuario(Nullable<int> idPersona, Nullable<int> tipoRol_ID, string userName, string password, ObjectParameter mensaje)
        {
            var idPersonaParameter = idPersona.HasValue ?
                new ObjectParameter("IdPersona", idPersona) :
                new ObjectParameter("IdPersona", typeof(int));
    
            var tipoRol_IDParameter = tipoRol_ID.HasValue ?
                new ObjectParameter("TipoRol_ID", tipoRol_ID) :
                new ObjectParameter("TipoRol_ID", typeof(int));
    
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Sp_InsertarUsuario", idPersonaParameter, tipoRol_IDParameter, userNameParameter, passwordParameter, mensaje);
        }
    
        public virtual int Sp_EliminarMenbresiasUsuario(Nullable<int> menbresiaID, ObjectParameter mensaje)
        {
            var menbresiaIDParameter = menbresiaID.HasValue ?
                new ObjectParameter("MenbresiaID", menbresiaID) :
                new ObjectParameter("MenbresiaID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Sp_EliminarMenbresiasUsuario", menbresiaIDParameter, mensaje);
        }
    
        public virtual int Sp_EliminarTipoMembresia(Nullable<int> tipoMembresiaID, ObjectParameter mensaje)
        {
            var tipoMembresiaIDParameter = tipoMembresiaID.HasValue ?
                new ObjectParameter("TipoMembresiaID", tipoMembresiaID) :
                new ObjectParameter("TipoMembresiaID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Sp_EliminarTipoMembresia", tipoMembresiaIDParameter, mensaje);
        }
    
        public virtual int Sp_InsertarMenbresiasUsuario(Nullable<int> usuarioID, string tipoMenbresia, string tipoEstado, Nullable<System.DateTime> fechaAdquisicion, Nullable<System.DateTime> fechaVencimiento, ObjectParameter mensaje)
        {
            var usuarioIDParameter = usuarioID.HasValue ?
                new ObjectParameter("UsuarioID", usuarioID) :
                new ObjectParameter("UsuarioID", typeof(int));
    
            var tipoMenbresiaParameter = tipoMenbresia != null ?
                new ObjectParameter("TipoMenbresia", tipoMenbresia) :
                new ObjectParameter("TipoMenbresia", typeof(string));
    
            var tipoEstadoParameter = tipoEstado != null ?
                new ObjectParameter("TipoEstado", tipoEstado) :
                new ObjectParameter("TipoEstado", typeof(string));
    
            var fechaAdquisicionParameter = fechaAdquisicion.HasValue ?
                new ObjectParameter("FechaAdquisicion", fechaAdquisicion) :
                new ObjectParameter("FechaAdquisicion", typeof(System.DateTime));
    
            var fechaVencimientoParameter = fechaVencimiento.HasValue ?
                new ObjectParameter("FechaVencimiento", fechaVencimiento) :
                new ObjectParameter("FechaVencimiento", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Sp_InsertarMenbresiasUsuario", usuarioIDParameter, tipoMenbresiaParameter, tipoEstadoParameter, fechaAdquisicionParameter, fechaVencimientoParameter, mensaje);
        }
    
        public virtual int Sp_InsertarTipoMembresia(string nombre, Nullable<decimal> precio, string descripcion, ObjectParameter mensaje)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var precioParameter = precio.HasValue ?
                new ObjectParameter("Precio", precio) :
                new ObjectParameter("Precio", typeof(decimal));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Sp_InsertarTipoMembresia", nombreParameter, precioParameter, descripcionParameter, mensaje);
        }
    
        public virtual int Sp_ModidicarTipoMembresia(Nullable<int> tipoMembresiaID, Nullable<decimal> precio, string descripcion, ObjectParameter mensaje)
        {
            var tipoMembresiaIDParameter = tipoMembresiaID.HasValue ?
                new ObjectParameter("TipoMembresiaID", tipoMembresiaID) :
                new ObjectParameter("TipoMembresiaID", typeof(int));
    
            var precioParameter = precio.HasValue ?
                new ObjectParameter("Precio", precio) :
                new ObjectParameter("Precio", typeof(decimal));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Sp_ModidicarTipoMembresia", tipoMembresiaIDParameter, precioParameter, descripcionParameter, mensaje);
        }
    
        public virtual int sp_AutenticarUsuario(string nombreUsuario, string contraseña, ObjectParameter autenticacion)
        {
            var nombreUsuarioParameter = nombreUsuario != null ?
                new ObjectParameter("NombreUsuario", nombreUsuario) :
                new ObjectParameter("NombreUsuario", typeof(string));
    
            var contraseñaParameter = contraseña != null ?
                new ObjectParameter("Contraseña", contraseña) :
                new ObjectParameter("Contraseña", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_AutenticarUsuario", nombreUsuarioParameter, contraseñaParameter, autenticacion);
        }
    
        public virtual int Sp_GenerarUsername(Nullable<int> idPersona, ObjectParameter userName)
        {
            var idPersonaParameter = idPersona.HasValue ?
                new ObjectParameter("IdPersona", idPersona) :
                new ObjectParameter("IdPersona", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Sp_GenerarUsername", idPersonaParameter, userName);
        }
    }
}
