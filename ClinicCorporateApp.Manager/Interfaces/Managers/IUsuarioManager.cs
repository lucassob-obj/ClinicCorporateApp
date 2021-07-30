﻿using ClinicCorporateApp.Core.Domain;
using ClinicCorporateApp.Core.Shared.ModelViews.Usuario;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicCorporateApp.Manager.Interfaces.Managers
{
    public interface IUsuarioManager
    {
        Task<IEnumerable<UsuarioView>> GetAsync();
        Task<UsuarioView> GetAsync(string login);
        Task<UsuarioView> InsertAsync(Usuario usuario);
        Task<UsuarioView> UpdateMedicoAsync(Usuario usuario);
        Task<bool> ValidaSenhaAsync(Usuario usuario);
    }
}
