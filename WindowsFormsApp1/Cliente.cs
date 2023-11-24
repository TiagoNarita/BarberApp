using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Cliente
    {
        private string nome;
        private string cpf;
        private string telefone;
        private int idade;
        

        public Cliente(string nome, string cpf, string telefone,
                         int idade)
        {
            this.nome = nome;
            this.cpf = cpf;
            this.telefone = telefone;
            this.idade = idade;
           
        }

        public string getNome() { return nome; }
        public string getCPF() { return cpf; }
        public string getTelefone() { return telefone; }
        public int getIdade() { return idade; }

    }
}
