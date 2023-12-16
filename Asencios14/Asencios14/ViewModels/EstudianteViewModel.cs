using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

public class EstudianteViewModel : BaseViewModel
{
    private ObservableCollection<Estudiante> _estudiantes;
    public ObservableCollection<Estudiante> Estudiantes
    {
        get { return _estudiantes; }
        set { SetProperty(ref _estudiantes, value); }
    }

    private Estudiante _estudianteSeleccionado;
    public Estudiante EstudianteSeleccionado
    {
        get { return _estudianteSeleccionado; }
        set { SetProperty(ref _estudianteSeleccionado, value); }
    }

    public ICommand GuardarCommand { get; }
    public ICommand ActualizarCommand { get; }
    public ICommand EliminarCommand { get; }

    public EstudianteViewModel()
    {
        GuardarCommand = new Command(Guardar);
        ActualizarCommand = new Command(Actualizar);
        EliminarCommand = new Command(Eliminar);

        CargarEstudiantes();
    }

    private void CargarEstudiantes()
    {
        using (var context = new ApplicationDbContext())
        {
            Estudiantes = new ObservableCollection<Estudiante>(context.Estudiantes.ToList());
        }
    }

    private void Guardar()
    {
        using (var context = new ApplicationDbContext())
        {
            context.Estudiantes.Add(_estudianteSeleccionado);
            context.SaveChanges();
        }

        CargarEstudiantes();
    }

    private void Actualizar()
    {
        using (var context = new ApplicationDbContext())
        {
            context.Estudiantes.Update(_estudianteSeleccionado);
            context.SaveChanges();
        }

        CargarEstudiantes();
    }

    private void Eliminar()
    {
        using (var context = new ApplicationDbContext())
        {
            context.Estudiantes.Remove(_estudianteSeleccionado);
            context.SaveChanges();
        }

        CargarEstudiantes();
    }
}