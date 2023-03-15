using Soneta.Business;
using Soneta.Business.UI;
using Soneta.Kadry;
using SonetaAddon6.UI;
using System;

[assembly: Worker(typeof(MyWorker1Worker), typeof(Pracownicy))]

namespace SonetaAddon6.UI
{
    public class MyWorker1Worker
    {

        [Context]
        public MyWorker1WorkerParams @params
        {
            get;
            set;
        }


        // TODO -> Należy podmienić podany opis akcji na bardziej czytelny dla uzytkownika
        [Action("SCAPAFLOW/SonetaAddon6", Mode = ActionMode.SingleSession | ActionMode.ConfirmSave | ActionMode.Progress)]
        public MessageBoxInformation ToDo()
        {


            return new MessageBoxInformation("Potwierdzasz wykonanie operacji ?")
            {
                Text = "Opis operacji",
                YesHandler = () =>
                {
                    using (var t = @params.Session.Logout(true))
                    {
                        t.Commit();
                    }
                    return "Operacja została zakończona";
                },
                NoHandler = () => "Operacja przerwana"
            };

        }
    }


    public class MyWorker1WorkerParams : ContextBase
    {
        public MyWorker1WorkerParams(Context context) : base(context)
        {
            folder = string.Empty;
        }

        // TODO -> Poniższy parametr dodany dla celów poglądowych. Należy usunąć.
        public string Parametr1 { get; set; }















        private string folder;

        [Required]
        public string Folder
        {
            get => folder;
            set
            {
                folder = value;
                OnChanged();
            }
        }

        public object GetListFolder()
        {
            return new FileDialogInfo
            {
                Title = "Wybierz folder",
                ForbidMultiSelection = true,
                InitialDirectory = @"C:\"
            };
        }






        public string PlikWe { get; set; }




        public object GetListPlikWe()
        {
            return new FileDialogInfo()
            {
                Title = "Wybierz pliki",
                Filter = "Pliki XLSX (*.xlsx)|*.xlsx|Wszystkie pliki (*.*)|*.*"
            };
        }

        public string PlikWy { get; set; }




        public object GetListPlikWy()
        {
            return new FileDialogInfo()
            {
                Title = "Wybierz pliki",
                Filter = "Pliki XLSX (*.xlsx)|*.xlsx|Wszystkie pliki (*.*)|*.*"
            };
        }


    }

}
