﻿using DomainLayer.Usuarios;

using System.Collections.Generic;

namespace ServicesLayer.Usuarios
{
    public interface IUsuariosRepository
    {
        IUsuarioModel Add(IUsuarioModel usuario);
        void Edit(IUsuarioModel usuario);
        void Enable(int usuarioId);
        void Desable(int usuarioId);
        IUsuarioModel GetByLogin(string login);
        IUsuarioModel GetById(int usuarioId);
        IEnumerable<IUsuarioModel> GetAll();
        bool CheckLogin(string usuario, string senha);
        


    }
}
