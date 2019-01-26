using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace RestWithAspNetUdemy.Model.Base
{
    //Contrato que determina como o classe será exposta via json (contrato entre atributos e a tabela)
    //[DataContract]
    public class BaseEntity
    {
        public long? Id { get; set; }
    }
}
