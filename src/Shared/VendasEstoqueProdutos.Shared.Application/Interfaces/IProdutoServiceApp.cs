using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Produto;

namespace VendasEstoqueProdutos.Shared.Application.Interfaces;

public interface IProdutoServiceApp
{
    public Task<IEnumerable<ReadProdutoDto>> RecuperarListaDeProdutosCadastrados();
    public ReadProdutoCompletoDto? RecuperarProdutoPeloId(int id);
    public Task<bool> CadastrarNovoProduto(CreateProdutoDto produtoDto);
    public Task<bool> AtualizarProduto(int id, UpdateProdutoDto produtoDto);
    public Task<bool> DeletarProduto(int id);
}
