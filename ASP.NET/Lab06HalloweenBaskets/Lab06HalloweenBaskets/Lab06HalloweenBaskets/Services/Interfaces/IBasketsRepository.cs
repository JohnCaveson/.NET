using Lab06HalloweenBaskets.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab06HalloweenBaskets.Services.Interfaces
{
    public interface IBasketsRepository
    {
       List<Basket> ReadAll();

        Basket Create(Basket basket);

        Basket Read(int id);

        void Update(int id, Basket basket);
    }
}
