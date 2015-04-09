using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace ApiInformationDemo.Repositories
{
    public class ColorRepository
    {
        public IEnumerable<Models.ColorInfo> GetColors()
        {
            return typeof(Colors)
                .GetRuntimeProperties()
                .Select(x => new Models.ColorInfo
                {
                    Name = x.Name,
                    Color = (Color)x.GetValue(null),
                });
        }
    }
}
