using System;
using System.Collections.Generic;

using System.Net;


using Android.App;

using Android.OS;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using RestSharp;

namespace MakeListView {
    [Activity(Label = "AddPessoa")]
    public class AddPessoa : Activity
    {
        private static List<Pessoa> pessoas { get; set;}
        private EditText RazaoSocialTxt { get; set; }
        private EditText NomeFantasiaTxt { get; set; }
        private EditText CpfCnpjTxt { get; set; }
        private Button BtnAddPessoa { get; set; }
        private Button BtnSincronizar { get; set; }
        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.add_pessoa);
            pessoas = new List<Pessoa>();
            ActionBar.SetHomeButtonEnabled(true);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            RazaoSocialTxt = FindViewById<EditText>(Resource.Id.RazaoSocialTxt);
            NomeFantasiaTxt = FindViewById<EditText>(Resource.Id.NomeFantasiaTxt);
            CpfCnpjTxt = FindViewById<EditText>(Resource.Id.CpfCnpjTxt);
            BtnAddPessoa = FindViewById<Button>(Resource.Id.BtnAddPessoa);
            BtnSincronizar = FindViewById<Button>(Resource.Id.BtnSincronizar);
            BtnAddPessoa.Click += BtnAddPessoaOnClick;
            BtnSincronizar.Click += BtnSincronizarOnClick;


        }

        private void BtnSincronizarOnClick(object sender, EventArgs eventArgs) {
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            var pessoasJson = JsonConvert.SerializeObject(pessoas);
            var client = new RestClient("http://200.10.10.148:3000");
            var request = new RestRequest("pessoas", Method.POST);
            request.AddParameter("application/json", pessoasJson, ParameterType.RequestBody);
            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Toast.MakeText(this, "Pessoas Cadastradas com Sucesso!!!", ToastLength.Short).Show();
                LimparCampos();
            }
            else
            {
                Toast.MakeText(this, "Erro ao Cadastrar Pessoa, Contate a Equipe de Desenvolvimento!!!", ToastLength.Short).Show();
            }
           
        }

        private void BtnAddPessoaOnClick(object sender, EventArgs eventArgs) {
            var rs = RazaoSocialTxt.Text;
            var nf = NomeFantasiaTxt.Text;
            var cc = CpfCnpjTxt.Text;
            var pessoa = new Pessoa() { razaoSocial = rs, nomeFantasia = nf, cpfCnpj = cc };
            pessoas.Add(pessoa);
            Toast.MakeText(this, pessoas.Count.ToString(), ToastLength.Short).Show();
            LimparCampos();
        }

        private void LimparCampos() {
            RazaoSocialTxt.Text = "";
            NomeFantasiaTxt.Text = "";
            CpfCnpjTxt.Text = "";
        }

        public override bool OnOptionsItemSelected(IMenuItem item) {
            switch (item.ItemId) {
                case Android.Resource.Id.Home:
                Finish();
                return true;

                default:
                return base.OnOptionsItemSelected(item);
            }
        }
    }
}