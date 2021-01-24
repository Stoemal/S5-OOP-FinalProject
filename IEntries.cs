using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S5_OOP_FinalProject
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
