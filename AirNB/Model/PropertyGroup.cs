using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace AirNB.Model
{
    public class PropertyGroup:ObservableCollection<Properties>
    {
        public string Title { get; set; }
        public PropertyGroup(string title, IEnumerable<Properties> searches = null)
            : base(searches)
        {
            Title = title;
        }
        
    }
}
