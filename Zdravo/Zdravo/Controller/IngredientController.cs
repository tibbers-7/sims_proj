﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdravo.Service;

namespace Zdravo.Controller
{
    public class IngredientController
    {
        private IngredientService ingredientService;

        public IngredientController(IngredientService ingredientService)
        {
            this.ingredientService = ingredientService;
        }

        public ObservableCollection<string> GetAll()
        {
            return ingredientService.GetAll();
        }
    }
}
