using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListViewExample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewGroup : ContentPage
    {
        public ListViewGroup()
        {
            InitializeComponent();

            List<Animal> animals = new List<Animal>
            {
                new Animal { Name = "Pez", Limbs = 5, FamilyType = "Fish" },
                new Animal { Name = "Gato", Limbs = 1, FamilyType = "Mammals" },
                new Animal { Name = "Ardilla", Limbs = 7, FamilyType = "Mammals" },
                new Animal { Name = "Loro", Limbs = 1, FamilyType = "Mammals" }
            };

            var groupedAnimal = animals.GroupBy(x => x.FamilyType)
                .Select(g => new Grouping<string, Animal>(g.Key, g));

            animalsListView.ItemsSource = groupedAnimal;
            BindingContext = this;
        }
        public class Grouping<K, T> : ObservableCollection<T>
        {
            public K Key { get; private set; }
            public Grouping(K key, IEnumerable<T> items)
            {
                Key = key;
                foreach (var item in items)
                    Items.Add(item);
            }
        }
    }
}