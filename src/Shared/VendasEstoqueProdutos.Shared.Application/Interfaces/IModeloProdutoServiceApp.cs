﻿using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.ModeloProduto;

namespace VendasEstoqueProdutos.Shared.Application.Interfaces;

public interface IModeloProdutoServiceApp
{
    public Task<IEnumerable<ReadModeloProdutoDto>> RecuperarListaDeTodosOsModelosDoProduto();
    public ReadModeloProdutoCompletoDto? RecuperarModeloProdutoPeloId(int id);
    public Task<bool> CadastrarNovoModeloProduto(CreateModeloProdutoDto modeloProdutoDto);
    public Task<bool> AtualizarModeloProduto(int id, UpdateModeloProdutoDto modeloProdutoDto);
    public Task<bool> DeletarModeloProduto(int id);
}
