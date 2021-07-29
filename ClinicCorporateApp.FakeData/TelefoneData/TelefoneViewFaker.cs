using Bogus;
using ClinicCorporateApp.Core.Shared.ModelViews.Telefone;

namespace ClinicCorporateApp.FakeData.TelefoneData
{
    public class TelefoneViewFaker : Faker<TelefoneView>
    {
        public TelefoneViewFaker()
        {
            RuleFor(p => p.Id, f => f.Random.Number(1, 10));
            RuleFor(p => p.Numero, f => f.Person.Phone);
        }
    }
}
