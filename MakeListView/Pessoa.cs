using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MakeListView {
    class  ListaPessoa 
    {
    public List<Pessoa> Pessoas { get; set; }
    }
    public class Pessoa {
        public int idPessoa { get; set; }
        public string razaoSocial { get; set; }
        public string nomeFantasia { get; set; }
        public string cpfCnpj { get; set; }

    }
}