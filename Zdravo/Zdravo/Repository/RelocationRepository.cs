using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdravo.FileHandler;
using Zdravo.Model;

namespace Zdravo.Repository
{
    public class RelocationRepository
    {
        private RelocationFileHandler relFileHandler;
        private ObservableCollection<Relocation> relocations;

        public RelocationRepository() { 
            relFileHandler = new RelocationFileHandler();
            relocations = relFileHandler.Read();
        }
        public void Create(Relocation _relocation) { 
            relocations.Add(_relocation);
            relFileHandler.Write(relocations);
        }

        public ObservableCollection<Relocation> GetAll()
        {
            return relocations;
        }

        public void Delete(Relocation _relocation)
        {
            relocations.Remove(_relocation);
            relFileHandler.Write(relocations);
        }
    }
}
