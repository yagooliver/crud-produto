using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudBackend.Domain.Core.Shared.Models
{
    public class ApiErro
    {
        public bool Sucesso { get; set; }
        public List<string> erros { get; set; }
    }
}
