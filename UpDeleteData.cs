using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQ.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQ
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    class UpDeleteData : Activity
    {
        private EditText myUEnr;
        private EditText myUMarks;
        private EditText myUId;
        private Button myUpdate;
        private Button myDelete;
        StudentDatabase sDB;
        Students studentU;

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.updatedeletedata);
            UIReference();


            if (Intent.Extras != null)
            {

                int message = Intent.Extras.GetInt(key: "StudentDetails", 0);

                if (message != 0)
                {
                    myUId.Text = message.ToString();

                    sDB = new StudentDatabase();

                    studentU = sDB.GetByUserId(message);

                    myUEnr.Text = studentU.sName;
                    myUMarks.Text = studentU.sMarks.ToString();



                }
            }

            UIClikevents();



        }

        private void UIClikevents()
        {
            myUpdate.Click += MyUpdate_Click;
            myDelete.Click += MyDelete_Click;
        }

        private void MyDelete_Click(object sender, EventArgs e)
        {
            if (studentU != null)
            {
                var isDeleted = sDB.DeleteStudents(studentU);
                if (isDeleted == true)
                {
                    Toast.MakeText(this, "Data Deleted Succesfully", ToastLength.Short).Show();
                }

                else
                {

                    Toast.MakeText(this, "No action performed", ToastLength.Short).Show();

                }
            }

        }

        private void MyUpdate_Click(object sender, EventArgs e)
        {

            if (studentU != null)
            {

                studentU.sName = myUEnr.Text;
                studentU.sMarks = int.Parse(myUMarks.Text);

                var isUpdated = sDB.UpdateStudents(studentU);

                if (isUpdated == true)
                {
                    Toast.MakeText(this, "Data Updated Succesfully", ToastLength.Short).Show();
                }

                else
                {

                    Toast.MakeText(this, "No action performed", ToastLength.Short).Show();

                }
            }

        }

        private void UIReference()
        {
            myUEnr = FindViewById<EditText>(Resource.Id.editTextUD1);
            myUMarks = FindViewById<EditText>(Resource.Id.editTextUD3);
            myUId = FindViewById<EditText>(Resource.Id.editTextUD4);
            myUpdate = FindViewById<Button>(Resource.Id.buttonU);
            myDelete = FindViewById<Button>(Resource.Id.buttonD);
        }
    }
}