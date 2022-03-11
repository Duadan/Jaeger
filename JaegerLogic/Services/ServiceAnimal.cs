using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaegerLogic
{
    class ServiceAnimal
    {
        public List<Tiere> GetAllAnimals()
        {
            using (JaegerDB hunt = new JaegerDB())
            {
                var animal = from a in hunt.Tiere
                             select a;
                List<Tiere> animals = animal.ToList();
                return animals;
            }
        }
        public void DeleteAnimal(Tiere animalToDelete)
        {
            using (JaegerDB hunt = new JaegerDB())
            {
                //if/where SelectedHunter.ID==hunter.ID
                Tiere del = hunt.Tiere.Find(animalToDelete.ID);
                hunt.Tiere.Remove(del);
                hunt.SaveChanges();
            }
        }
        public void UpdateAnimal(Tiere animalToEdit)
        {
            using (JaegerDB hunt = new JaegerDB())
            {
                //if/where SelectedHunter.ID==hunter.ID
                Tiere del = hunt.Tiere.Find(animalToEdit.ID);
                del.Tierart = animalToEdit.Tierart;
                hunt.SaveChanges();
            }
        }
        public void AddAnimal(string animalName)
        {
            using (JaegerDB hunt = new JaegerDB())
            {
                var copy = from a in hunt.Tiere
                           select new { a.Tierart };
                bool existin = false;
                foreach (var i in copy)
                {
                    if (i.Tierart == animalName)
                    {
                        existin = true;
                    }
                }
                if (!existin)
                {
                    Tiere animal = new Tiere() { Tierart = animalName };
                    hunt.Tiere.Add(animal);
                    hunt.SaveChanges();
                }
                else
                {
                    AnimalListUCViewModel duh = ServiceLocator.Current.GetInstance<AnimalListUCViewModel>();
                    duh.AnimalName = "existiert schon";
                }
            }
        }
    }
}
