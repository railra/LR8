using System;
using System.IO;
using System.Reflection;
using AppFinally1.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
[assembly: ExportFont("MISTRAL.TTF", Alias = "Mistral")]
[assembly: ExportFont("comic.ttf", Alias = "Comic")]
[assembly: ExportFont("LeoHand.ttf", Alias = "LeoHand")]
namespace AppFinally1
{
    public partial class App : Application
    {

        public const string DATABASE_NAME = "kurs.db";
        public static SQLAsyncRepository database;
        public static SQL2AsyncRepository database2;
        public static SQL3AsyncRepository database3;
        public static SQL4AsyncRepository database4;
        public static SQL5AsyncRepository database5;
        public static string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME);
        public static SQLAsyncRepository Database
        {
            get
            {
                if (database == null)
                {
                    // если база данных не существует (еще не скопирована)
                    if (!File.Exists(dbPath))
                    {
                        // получаем текущую сборку
                        var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
                        // берем из нее ресурс базы данных и создаем из него поток
                        using (Stream stream = assembly.GetManifestResourceStream($"AppFinally1.{DATABASE_NAME}"))
                        {
                            using (FileStream fs = new FileStream(dbPath, FileMode.OpenOrCreate))
                            {
                                stream.CopyTo(fs);  // копируем файл базы данных в нужное нам место
                                fs.Flush();
                            }
                        }
                    }
                    database = new SQLAsyncRepository(dbPath);
                }
                return database;
            }
        }
        public static SQL2AsyncRepository Database2
        {
            get
            {
                if (database2 == null)
                {
                    database2 = new SQL2AsyncRepository(dbPath);
                }
                return database2;
            }
        }
        public static SQL3AsyncRepository Database3
        {
            get
            {
                if (database3 == null)
                {
                    database3 = new SQL3AsyncRepository(dbPath);
                }
                return database3;
            }
        }
        public static SQL4AsyncRepository Database4
        {
            get
            {
                if (database4 == null)
                {
                    database4 = new SQL4AsyncRepository(dbPath);
                }
                return database4;
            }
        }
        public static SQL5AsyncRepository Database5
        {
            get
            {
                if (database5 == null)
                {
                    database5 = new SQL5AsyncRepository(dbPath);
                }
                return database5;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainMenu());
            //MainPage = new FlyoutPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
