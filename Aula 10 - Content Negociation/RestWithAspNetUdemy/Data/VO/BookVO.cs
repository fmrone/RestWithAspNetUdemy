using System;
using System.Runtime.Serialization;

namespace RestWithAspNetUdemy.Data.VO
{
    //Contrato que determina como o classe será exposta via json(contrato entre atributos e a tabela)
    //Necessário anotar os métodos com o nome e ordem em que os mesmos serão expostos
    [DataContract]
    public class BookVO
    {
        [DataMember(Order =1, Name = "Identificador")]
        public long? Id { get; set; }

        [DataMember(Order = 2)]
        public string Title { get; set; }

        [DataMember(Order = 3)]
        public string Author { get; set; }

        [DataMember(Order = 5)]
        public DateTime LaunchDate { get; set; }

        [DataMember(Order = 4)]
        public decimal Price { get; set; }
    }
}
