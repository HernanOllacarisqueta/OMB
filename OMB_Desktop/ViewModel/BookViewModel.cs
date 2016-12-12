using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Entidades;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Infraestructura;
using Prism.Interactivity.InteractionRequest;
using Servicios;

namespace OMB_Desktop.ViewModel
{
    class BookViewModel : ViewModelBase, IInteractionRequestAware
    {
        private string _titulo;
        private string _subtitulo;
        private string _isbn13;
        private string _isbn10;
        private string _editorial;

        public DateTime _calendario; //Queda public?

        public string Titulo
        {
            get { return _titulo; }
            set
            {
                Set(() => Titulo, ref _titulo, value);
            }
        }

        public string Subtitulo
        {
            get { return _subtitulo; }
            set
            {
                Set(() => Subtitulo, ref _subtitulo, value);
            }
        }

        public string Isbn13
        {
            get { return _isbn13; }
            set
            {
                Set(() => Isbn13, ref _isbn13, value);
            }
        }

        public string Isbn10
        {
            get { return _isbn10; }
            set
            {
                Set(() => Isbn10, ref _isbn10, value);
            }
        }

        public string Editorial
        {
            get { return _editorial; }
            set
            {
                Set(() => Editorial, ref _editorial, value);
            }
        }

        public INotification Notification { get; set; }
        public Action FinishInteraction { get; set; }
        public RelayCommand AgregarLibro { get; set; }
        public RelayCommand CancelarLibro { get; set; }
        public InteractionRequest<INotification> FaltanDatosLibros { get; set; }

        public BookViewModel()
        {
            AgregarLibro= new RelayCommand(AddBook);
            CancelarLibro = new RelayCommand(CancelBook);

            FaltanDatosLibros = new InteractionRequest<INotification>();
        }


        
        public void AddBook()
        {
            ProductServices seg = new ProductServices();
        }
        public void CancelBook() { }

    }
}
