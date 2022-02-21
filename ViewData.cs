using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using SQ.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQ
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class ViewData : Activity
    {
        private RecyclerView myRecycleView;



        private List<Students> studentslist;

        RecyclerView.LayoutManager myLayoutmanager;
        private StudentAdapter sadapter;
        StudentDatabase sDB;
        public string sstudEnr;
        public int ssMarks;
        public int ssId;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.viewdatalayout);

            myRecycleView = FindViewById<RecyclerView>(Resource.Id.recyclerView1);


            GetStudentsDetails();

            myLayoutmanager = new LinearLayoutManager(this);
            myRecycleView.SetLayoutManager(myLayoutmanager);

            sadapter = new StudentAdapter(studentslist, this);
            myRecycleView.SetAdapter(sadapter);



        }

        private List<Students> GetStudentsDetails()
        {
            sDB = new StudentDatabase();
            var students = sDB.ReadStudents();

            studentslist = new List<Students>();

            studentslist.AddRange(students);

            return studentslist;
        }


    }
}