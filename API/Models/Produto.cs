using System;
namespace API.Models
{
    public class Produto
    {
        public Produto() => CriadoEm = DateTime.Now ;
        

        //Atributos ou propiedades
        public int id { get; set;}
        public string Nome { get; set;}
        public double Preco { get; set;}
        public string Descrição { get; set; }
        public int Quantidade { get; set; }
        public DateTime CriadoEm { get; set; }

        //Criando o ToString
        public override string ToString() =>
        
            $"Nome: {Nome} | Preço: {Preco:C2} | CriadoEm em: {CriadoEm}";
    
    }
}