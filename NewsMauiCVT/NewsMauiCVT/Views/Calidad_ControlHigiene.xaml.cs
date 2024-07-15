using static Android.Views.WindowInsetsAnimation;

namespace NewsMauiCVT.Views;

public partial class Calidad_ControlHigiene : ContentPage
{
    public Calidad_ControlHigiene()
    {
        InitializeComponent();
        cargaDatos();
    }

    protected override async void OnAppearing()
    {

        base.OnAppearing();
        cboMonitor.SelectedIndex = -1;
        cboArea.SelectedIndex = -1;
        cboTipoContraro.SelectedIndex = -1;
        lblError2.Text = string.Empty;
        cboPersona.SelectedIndex = -1;
        cboLimpUniforme.SelectedIndex = -1;
        cboAfeitadoCorto.SelectedIndex = -1;
        cboUnas.SelectedIndex = -1;
        cboJoyas.SelectedIndex = -1;
        cboHigiene.SelectedIndex = -1;
        txtAccionCorrectiva.Text = string.Empty;
        CboEstUniforme.SelectedIndex = -1;
        cboHeridaExpuesta.SelectedIndex = -1;

        //lblError.Text = string.Empty;
        //lblError.IsVisible = false;

        //lblError2.IsVisible = false;
        //lblError3.Text = string.Empty;
        //lblError3.IsVisible = false;
        ////txt_Bodega.SelectedIndex = -1;

        //txt_pallet.Text = string.Empty;

        //txt_cantidad.Text = string.Empty;

    }

    void cargaDatos()
    {
        var ACC = Connectivity.NetworkAccess;
        if (ACC == NetworkAccess.Internet)
        {
            DatosCalidadControlHigiene ti = new DatosCalidadControlHigiene();
            List<PersonalClass> lt = ti.ListaPerdonal();
            List<AreaClass> lta = ti.ListaAreas();
            List<PersonalClass> lt2 = ti.ListaPerdonalFull();

            List<PersonalClass> fl = new List<PersonalClass>();
            List<PersonalClass> fl2 = new List<PersonalClass>();
            List<AreaClass> fla = new List<AreaClass>();

            foreach (var t in lt)
            {
                fl.Add(new PersonalClass { Id_Personal = t.Id_Personal, Nombre = t.Nombre + " " + t.apellido });

            }
            foreach (var t in lt2)
            {
                fl2.Add(new PersonalClass { Id_Personal = t.Id_Personal, Nombre = t.Nombre + " " + t.apellido });

            }

            foreach (var ta in lta)
            {
                fla.Add(new AreaClass { Id_Area = ta.Id_Area, Nombre = ta.Nombre });
            }

            List<CVTtipoContrato> lst = new List<CVTtipoContrato>();

            lst.Add(new CVTtipoContrato { tipoCont = "P", NombreCont = "Planta" });
            lst.Add(new CVTtipoContrato { tipoCont = "E", NombreCont = "Contratista" });

            cboMonitor.BindingContext = fl;
            cboArea.BindingContext = fla;
            cboTipoContraro.BindingContext = lst;
            cboPersona.BindingContext = fl2;



        }
        else
        {
            DependencyService.Get<IAudio>().PlayAudioFile("terran-error.mp3");
            DisplayAlert("Alerta", "Debe Conectarse a la Red Local", "Aceptar");
        }



        //txtCodigo.Focus();
    }
}