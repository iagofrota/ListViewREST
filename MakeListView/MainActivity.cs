using System;
using System.Collections.Generic;
using System.Net;
using Android.App;

using Android.Widget;
using Android.OS;
using com.refractored.fab;


using RestSharp;



namespace MakeListView {
    [Activity(Label = "MakeListView", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private List<Pessoa> mItens;
        private ListView mListView;
        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);
           
            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            mItens = new List<Pessoa>();
            mListView = FindViewById<ListView>(Resource.Id.myListView);
           

            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            var client = new RestClient("http://200.10.10.148:3000");
            var request = new RestRequest("pessoas", Method.GET);
            var response = client.Execute<List<Pessoa>>(request);
            mItens = response.Data;
            Console.WriteLine(mItens);
            MyListViewAdapter adapter = new MyListViewAdapter(this, mItens);
            mListView.Adapter = adapter;
            var fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.AttachToListView(mListView);
            mListView.ItemClick += mListView_ItemClick;
            mListView.ItemLongClick += mListView_ItemLongClick;
            fab.Click += FabOnClick;


        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            
            StartActivity((typeof(AddPessoa)));
        }


        private void mListView_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            //Console.WriteLine(mItens[e.Position].LastName);
        }

        private void mListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //Console.WriteLine(mItens[e.Position].FirstName);
            //Console.WriteLine(mItens[e.Position].LastName);
            //Console.WriteLine(mItens[e.Position].Age);
            //Console.WriteLine(mItens[e.Position].Gender);
        }
    }
}

