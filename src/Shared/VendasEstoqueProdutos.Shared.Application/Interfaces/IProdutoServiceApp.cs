﻿using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Produto;

namespace VendasEstoqueProdutos.Shared.Application.Interfaces;

public interface IProdutoServiceApp
{
    public Task<IEnumerable<ReadProdutoDto>> RecuperarListaDeProdutosCadastrados();
    public ReadProdutoDto? RecuperarProdutoPeloId(int id);
    public Task<bool> CadastrarNovoProduto(CreateProdutoDto produtoDto);
}