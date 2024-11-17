using VendasEstoqueProdutos.Shared.Domain.Entities;
using VendasEstoqueProdutos.Shared.Domain.Services.Base;
using VendasEstoqueProdutos.Shared.Domain.Interfaces.Repositories;
using VendasEstoqueProdutos.Shared.Domain.Interfaces.Services;

namespace VendasEstoqueProdutos.Shared.Domain.Services;

public class EmpresaService(IEmpresaRepository repository)
    : BaseService<Empresa>(repository), IEmpresaService
{
}
