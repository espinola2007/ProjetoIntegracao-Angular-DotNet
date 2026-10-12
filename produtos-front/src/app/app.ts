
import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { ProdutosService } from './services/produtos';
import { Produto } from './models/produto.model';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {

  private produtosService = inject(ProdutosService);

  produtos: Produto[] = [];

  buscaId: number | null = null;
  produtoEncontrado: Produto | null = null;

  novoProduto = {
    nome: '',
    preco: 0
  };

  editandoId: number | null = null;

  produtoEdicao = {
    nome: '',
    preco: 0
  };

  mensagem = '';

  ngOnInit(): void {
    this.listarProdutos();
  }

  listarProdutos(): void {
    this.produtosService.listarTodos().subscribe({
      next: (dados) => {
        this.produtos = dados;
      },
      error: () => {
        this.mensagem = 'Erro ao carregar os produtos.';
      }
    });
  }

  buscarProduto(): void {
    if (
      this.buscaId === null ||
      !Number.isInteger(this.buscaId) ||
      this.buscaId <= 0
    ) {
      this.mensagem = 'Informe um ID válido.';
      return;
    }

    this.produtosService.buscarPorId(this.buscaId).subscribe({
      next: (produto) => {
        this.produtoEncontrado = produto;
        this.mensagem = '';
      },
      error: () => {
        this.produtoEncontrado = null;
        this.mensagem = 'Produto não encontrado ou API indisponível.';
      }
    });
  }

  adicionarProduto(): void {
    if (
      !this.novoProduto.nome.trim() ||
      !Number.isFinite(this.novoProduto.preco) ||
      this.novoProduto.preco < 0
    ) {
      this.mensagem = 'Informe um nome e um preço válido.';
      return;
    }

    this.produtosService.criar(this.novoProduto).subscribe({
      next: () => {
        this.mensagem = 'Produto cadastrado com sucesso!';
        this.novoProduto = { nome: '', preco: 0 };
        this.listarProdutos();
      },
      error: () => {
        this.mensagem = 'Erro ao cadastrar produto.';
      }
    });
  }

  iniciarEdicao(produto: Produto): void {
    this.editandoId = produto.id;

    this.produtoEdicao = {
      nome: produto.nome,
      preco: produto.preco
    };
  }

  salvarEdicao(): void {
    if (this.editandoId === null) {
      return;
    }

    if (
      !this.produtoEdicao.nome.trim() ||
      !Number.isFinite(this.produtoEdicao.preco) ||
      this.produtoEdicao.preco < 0
    ) {
      this.mensagem = 'Informe dados válidos.';
      return;
    }

    this.produtosService.atualizar(
      this.editandoId,
      this.produtoEdicao
    ).subscribe({
      next: (produto) => {
        this.mensagem = 'Produto atualizado com sucesso!';
        this.editandoId = null;

        if (this.produtoEncontrado?.id === produto.id) {
          this.produtoEncontrado = produto;
        }

        this.listarProdutos();
      },
      error: () => {
        this.mensagem = 'Erro ao atualizar produto.';
      }
    });
  }

  cancelarEdicao(): void {
    this.editandoId = null;
  }

  removerProduto(id: number): void {
    this.produtosService.remover(id).subscribe({
      next: () => {
        this.mensagem = 'Produto removido com sucesso!';

        if (this.produtoEncontrado?.id === id) {
          this.produtoEncontrado = null;
        }

        this.listarProdutos();
      },
      error: () => {
        this.mensagem = 'Erro ao remover produto.';
      }
    });
  }
}
