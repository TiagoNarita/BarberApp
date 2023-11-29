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
        private string email;
        

        public Cliente(string nome, string cpf, string telefone, string email)
        {
            this.nome = nome;
            this.cpf = cpf;
            this.telefone = telefone;
            this.email = email;
        }

        public string getNome() { return nome; }
        public string getCPF() { return cpf; }
        public string getTelefone() { return telefone; }
        public string getEmail() { return email; }
    }
}
