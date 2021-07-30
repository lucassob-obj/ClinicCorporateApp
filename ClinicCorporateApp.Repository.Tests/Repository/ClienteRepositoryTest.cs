using ClinicCorporateApp.Core.Domain;
using ClinicCorporateApp.Data.Context;
using ClinicCorporateApp.Data.Repositories;
using ClinicCorporateApp.FakeData.ClienteData;
using ClinicCorporateApp.FakeData.TelefoneData;
using ClinicCorporateApp.Manager.Interfaces.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ClinicCorporateApp.Repository.Tests.Repository
{
    public class ClienteRepositoryTest : IDisposable
    {
        private readonly IClienteRepository repository;
        private readonly ClinicCorporateContext context;
        private readonly Cliente cliente;
        private ClienteFaker clienteFaker;

        public ClienteRepositoryTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ClinicCorporateContext>();
            optionBuilder.UseInMemoryDatabase("Db_Teste");

            context = new ClinicCorporateContext(optionBuilder.Options);
            repository = new ClienteRepository(context);

            clienteFaker = new ClienteFaker();
            cliente = clienteFaker.Generate();
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }

        private async Task<List<Cliente>> InsereRegistros()
        {
            var clientes = clienteFaker.Generate(100);
            foreach (var cli in clientes)
            {
                cli.Id = 0;
                await context.Clientes.AddAsync(cli);
            }
            await context.SaveChangesAsync();
            return clientes;
        }

        [Fact]
        public async Task GetClientesAsync()
        {
            var registros = await InsereRegistros();
            var retorno = await repository.GetClientesAsync();

            retorno.Should().HaveCount(registros.Count);
            retorno.First().Endereco.Should().NotBeNull();
            retorno.First().Telefones.Should().NotBeNull();
        }

        [Fact]
        public async Task GetClientesAsyncVazio()
        {
            var retorno = await repository.GetClientesAsync();
            retorno.Should().HaveCount(0);
        }

        [Fact]
        public async Task GetClienteAsyncEncontrado()
        {
            var registros = await InsereRegistros();
            var retorno = await repository.GetClienteAsync(registros.First().Id);
            retorno.Should().BeEquivalentTo(registros.First());
        }

        [Fact]
        public async Task GetClienteAsyncNaoEncontrado()
        {
            var retorno = await repository.GetClienteAsync(1);
            retorno.Should().BeNull();
        }

        [Fact]
        public async Task InsertClienteAsyncSucesso()
        {
            var retorno = await repository.InsertClienteAsync(cliente);
            retorno.Should().BeEquivalentTo(cliente);
        }

        [Fact]
        public async Task UpdateClienteAsyncSucesso()
        {
            var registros = await InsereRegistros();
            var clienteAlterado = clienteFaker.Generate();
            clienteAlterado.Id = registros.First().Id;
            var retorno = await repository.UpdateClienteAsync(clienteAlterado);
            retorno.Should().BeEquivalentTo(clienteAlterado);
        }

        [Fact]
        public async Task UpdateClienteAsyncAddTelefone()
        {
            var registros = await InsereRegistros();
            var clienteAlterado = registros.First();
            clienteAlterado.Telefones.Add(new TelefoneFaker(clienteAlterado.Id).Generate());
            var retorno = await repository.UpdateClienteAsync(clienteAlterado);
            retorno.Should().BeEquivalentTo(clienteAlterado);
        }

        [Fact]
        public async Task UpdateClienteAsyncRemoveTelefone()
        {
            var registros = await InsereRegistros();
            var clienteAlterado = registros.First();
            clienteAlterado.Telefones.Remove(clienteAlterado.Telefones.First());
            var retorno = await repository.UpdateClienteAsync(clienteAlterado);
            retorno.Should().BeEquivalentTo(clienteAlterado);
        }

        [Fact]
        public async Task UpdateClienteAsyncRemoveTodosOsTelefones()
        {
            var registros = await InsereRegistros();
            var clienteAlterado = registros.First();
            clienteAlterado.Telefones.Clear();
            var retorno = await repository.UpdateClienteAsync(clienteAlterado);
            retorno.Should().BeEquivalentTo(clienteAlterado);
        }

        [Fact]
        public async Task UpdateClienteAsyncNaoEncontrado()
        {
            var retorno = await repository.UpdateClienteAsync(cliente);
            retorno.Should().BeNull();
        }

        [Fact]
        public async Task DeleteClienteAsyncSucesso()
        {
            var registros = await InsereRegistros();
            var retorno = await repository.DeleteClienteAsync(registros.First().Id);
            retorno.Should().BeEquivalentTo(registros.First());
        }

        [Fact]
        public async Task DeleteClienteAsyncNaoEncontrado()
        {
            var retorno = await repository.DeleteClienteAsync(1);
            retorno.Should().BeNull();
        }

    }
}
