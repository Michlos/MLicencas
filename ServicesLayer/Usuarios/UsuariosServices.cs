﻿using DomainLayer.Usuarios;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServicesLayer.Usuarios
{
    public class UsuariosServices : IUsuariosRepository, IUsuariosServices
    {
        private IUsuariosRepository _usuarioRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public UsuariosServices(IUsuariosRepository usuarioRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _usuarioRepository = usuarioRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public IUsuarioModel Add(IUsuarioModel usuario)
        {
            return _usuarioRepository.Add(usuario);
        }

        public bool CheckLogin(string usuario, string senha)
        {
            return _usuarioRepository.CheckLogin(usuario, senha);
        }



        public void Edit(IUsuarioModel usuario)
        {
            _usuarioRepository.Edit(usuario);
        }

        public void Enable(int usuarioId)
        {
            _usuarioRepository.Enable(usuarioId);
        }

        public void Desable(int usuarioId)
        {
            _usuarioRepository.Desable(usuarioId);
        }

        public IEnumerable<IUsuarioModel> GetAll()
        {
            return _usuarioRepository.GetAll();
        }

        public IUsuarioModel GetById(int usuarioId)
        {
            return _usuarioRepository.GetById(usuarioId);
        }

        public IUsuarioModel GetByLogin(string login)
        {
            return _usuarioRepository.GetByLogin(login);
        }

        public void ValidateModel(IUsuarioModel usuario)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(usuario);
        }
    }
}
