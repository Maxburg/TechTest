using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTest.Bll.ShowGenres;

public interface IBlShowGenres
{
    public Task<KeyValuePair<bool, string>> Save(List<ShowGenre> showGenresToSave);
}