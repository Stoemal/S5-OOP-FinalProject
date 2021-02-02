using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF3._0
{
    /// <summary>
    /// Permet d'entrer, de modifier ou de supprimer une instance.
    /// </summary>
    interface IEntries
    {
        void Create();
        void Modify();
        void Delete();
    }
}
