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
    public class BasicRenovationRepository
    {
        private BasicRenovationFileHandler bsFileHandler;
        private ObservableCollection<BasicRenovation> renovations;

        public BasicRenovationRepository() { 
            bsFileHandler = new BasicRenovationFileHandler();
            renovations = new ObservableCollection<BasicRenovation>();
            //renovations = bsFileHandler.Read();
        }

        public void Create(BasicRenovation newRenovation) { 
            renovations.Add(newRenovation);
            bsFileHandler.Write(renovations);
        }

        public ObservableCollection<BasicRenovation> GetAll()
        {
            return renovations;
        }

        public void DeleteById(int id)
        {
            int selected = -1;
            int i = 0;
            foreach (BasicRenovation br in renovations)
            {
                if (br.Id == id)
                {
                    selected = i;
                }
                i++;
            }
            if (selected >= 0)
            {
                renovations.RemoveAt(selected);
            }
            bsFileHandler.Write(renovations);
        }

        public BasicRenovation GetById(int id)
        {
            foreach (BasicRenovation r in renovations)
            {
                if (r.Id == id)
                {
                    return r;
                }
            }
            return null;
        }
    }
}
