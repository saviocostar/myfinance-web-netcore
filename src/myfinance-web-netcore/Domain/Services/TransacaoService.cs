using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Domain.Entities;
using myfinance_web_netcore.Domain.Services.Interfaces;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Domain.Services
{
    public class TransacaoService : ITransacaoService
    {
        private readonly MyFinanceDbContext _dbContext;

        public TransacaoService(MyFinanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Excluir(int id)
        {
            var item = _dbContext.Transacao.Where(item => item.Id == id).First();
            _dbContext.Attach(item);
            _dbContext.Remove(item);
            _dbContext.SaveChanges();
        }

        public List<TransacaoModel> ListarRegistros()
        {
            var result = new List<TransacaoModel>();
            var dbSet = _dbContext.Transacao.Include(dbSet => dbSet.PlanoConta)
              .Include(dbSet => dbSet.TipoPagamento);

            foreach (var item in dbSet)
            {
                var itemTransacao = new TransacaoModel()
                {
                    Id = item.Id,
                    Data = item.Data,
                    Historico = item.Historico,
                    Valor = item.Valor,
                    ItemPlanoConta = new PlanoContaModel()
                    {
                        Id = item.PlanoConta.Id,
                        Descricao = item.PlanoConta.Descricao,
                        Tipo = item.PlanoConta.Tipo
                    },
                    PlanoContaId = item.PlanoContaId,
                    ItemTipoPagamento = new TipoPagamentoModel()
                    {
                        Id = item.TipoPagamento.Id,
                        Tipo = item.TipoPagamento.Tipo
                    },
                    TipoPagamentoId = item.TipoPagamentoId
                };

                result.Add(itemTransacao);
            }

            return result;
        }

        public TransacaoModel RetornarRegistro(int id)
        {
            var item = _dbContext.Transacao.Where(item => item.Id == id).First();

            var itemTransacao = new TransacaoModel()
            {
                Id = item.Id,
                Data = item.Data,
                Historico = item.Historico,
                Valor = item.Valor,
                PlanoContaId = item.PlanoContaId,
                TipoPagamentoId = item.TipoPagamentoId
            };

            return itemTransacao;
        }

        public void Salvar(TransacaoModel model)
        {
            var dbSet = _dbContext.Transacao;

            var entidade = new Transacao()
            {
                Id = model.Id,
                Data = model.Data,
                Historico = model.Historico,
                Valor = model.Valor,
                PlanoContaId = model.PlanoContaId,
                TipoPagamentoId = model.TipoPagamentoId
            };

            if (entidade.Id == null)
            {
                dbSet.Add(entidade);
            }
            else
            {
                dbSet.Attach(entidade);
                _dbContext.Entry(entidade).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }

            _dbContext.SaveChanges();
        }
    }
}