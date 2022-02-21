using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using SQ.Model;
using System;

namespace SQ
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private EditText myEnr;
        private EditText myMarks;
        // private EditText myId;
        private Button myAdd;
        private Button myView;
        StudentDatabase sDB;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            sDB = new StudentDatabase();
            UIReference();
            UIClickEvents();
            sDB.StudentTable();


        }

        private void UIClickEvents()
        {
            myAdd.Click += MyAdd_Click;
            myView.Click += MyView_Click;
        }

        private void MyView_Click(object sender, EventArgs e)
        {


            Intent i = new Intent(Application.Context, typeof(ViewData));
            StartActivity(i);
        }

        private void MyAdd_Click(object sender, EventArgs e)
        {
            Students studs = new Students();
            studs.sName = myEnr.Text;
            studs.sMarks = int.Parse(myMarks.Text);
            //studs.sId = int.Parse(myId.Text);

            bool checkinsert = sDB.InstertStudents(studs);
            if (checkinsert == true)
            {

                Toast.MakeText(this, "Data Inserted Succesfully", ToastLength.Short).Show();

            }
            else
            {

                Toast.MakeText(this, "No action performed", ToastLength.Short).Show();


            }
        Intent i = new Intent(Application.Context, typeof(ViewData));
            StartActivity(i);

        }

        private void UIReference()
        {
            myEnr = FindViewById<EditText>(Resource.Id.editText1);
            myMarks = FindViewById<EditText>(Resource.Id.editText3);
            myAdd = FindViewById<Button>(Resource.Id.buttonA);
            myView = FindViewById<Button>(Resource.Id.buttonV);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
