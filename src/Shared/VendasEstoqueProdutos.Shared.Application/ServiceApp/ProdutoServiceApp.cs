using AutoMapper;
using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Produto;
using VendasEstoqueProdutos.Shared.Application.Interfaces;
using VendasEstoqueProdutos.Shared.Domain.Entities;
using VendasEstoqueProdutos.Shared.Domain.Interfaces.Services;

namespace VendasEstoqueProdutos.Shared.Application.ServiceApp;

public class ProdutoServiceApp(IMapper mapper, IProdutoService service) : IProdutoServiceApp
{
    private readonly IMapper _mapper = mapper;
    private readonly IProdutoService _service = service;

    public async Task<IEnumerable<ReadProdutoDto>> RecuperarListaDeProdutosCadastrados()
    {
        var produtos = await _service.GetModelsAsync();
        return _mapper.Map<IEnumerable<ReadProdutoDto>>(produtos);
    }

    public ReadProdutoDto? RecuperarProdutoPeloId(int id)
    {
        var produto = _service.GetModelById(id);
        return produto != null ? _mapper.Map<ReadProdutoDto>(produto) : null;
    }

    public async Task<bool> CadastrarNovoProduto(CreateProdutoDto produtoDto)
    {
        var produto = _mapper.Map<Produto>(produtoDto);
        produto.Modelos = [new() { Descricao = "Padrão", QuantidadeEstoque = 0 }];
        return await _service.CreateModel(produto);
    }

    public async Task<bool> AtualizarProduto(int id, UpdateProdutoDto produtoDto)
    {
        var produto = _service.GetModelById(id);
        if (produto == null) return false;
        _mapper.Map(produtoDto, produto);
        return await _service.UpdateModel(produto);
    }

    public async Task<bool> DeletarProduto(int id)
    {
        return await _service.DeleteModel(id);
    }
}
