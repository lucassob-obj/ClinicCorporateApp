using Bogus;
using ClinicCorporateApp.Core.Shared.ModelViews;

namespace ClinicCorporateApp.FakeData.TelefoneData
{
    public class NovoTelefoneFaker : Faker<NovoTelefone>
    {
        public NovoTelefoneFaker()
        {
            RuleFor(p => p.Numero, f => f.Person.Phone);
        }
    }
}
