using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ejercicio1.mibd;
using System.Text.RegularExpressions;

namespace Ejercicio1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //instanciar bd
            if (Regex.IsMatch(txtnombre.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(txtsueldo.Text, @"^\d+$"))
            {
            demoEF db = new demoEF();
            Empleado emp = new Empleado();
            emp.Nombre = txtnombre.Text;
            emp.Sueldo = int.Parse(txtsueldo.Text);
            emp.DepartamentoId = (int)CbDepartamentos.SelectedValue;
            db.Empleado.Add(emp);
            db.SaveChanges();
           }
            else { MessageBox.Show("Solo Letras en #nombre y numeros en #sueldo "); }
        }

        private void txtnombre_TextChanged(object sender, TextChangedEventArgs e)
        {
        
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txtnombre.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(txtsueldo.Text, @"^\d+$") && Regex.IsMatch(txtid.Text, @"^\d+$"))
                {
            demoEF db = new demoEF();
            int id = int.Parse(txtid.Text);
            var emp = db.Empleado.SingleOrDefault(x => x.id == id);/*from x in db.Empleado
                      where x.id == id
                      select x;*/
            if(emp != null){
                emp.Nombre = txtnombre.Text;
                emp.Sueldo = int.Parse(txtsueldo.Text);
                db.SaveChanges();
                }
            }
            else { MessageBox.Show("Solo Letras en #nombre, numeros en #sueldo y numeros en #id"); }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txtid.Text, @"^\d+$"))
            {
                demoEF db = new demoEF();
                int id = int.Parse(txtid.Text);
                var emp = db.Empleado.SingleOrDefault(x => x.id == id);/*from x in db.Empleado
                      where x.id == id
                      select x;*/
                if (emp != null)
                {
                    db.Empleado.Remove(emp);

                    db.SaveChanges();

                }
            }
            else { MessageBox.Show("Solo Numeros  #id"); }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txtid.Text, @"^\d+$"))
                {
            demoEF db = new demoEF();
            int id = int.Parse(txtid.Text);
            var reg = from s in db.Empleado
                      where s.id == id
                      select new
                      {
                          s.Nombre,
                          s.Sueldo
                      };
            dbgrid.ItemsSource = reg.ToList();
        }
            else { MessageBox.Show("Solo Numeros  #id"); }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txtid.Text, @"^\d+$"))
                {
                    demoEF db = new demoEF();
                    var reg = from s in db.Empleado
                        select s;
                        dbgrid.ItemsSource = reg.ToList();
                }
                else { MessageBox.Show("Solo Numeros  #id"); }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txtdeps.Text, @"^[a-zA-Z]+$"))
            {
            demoEF db = new demoEF();
            Departamento dep = new Departamento();
            dep.Nombre = txtdeps.Text;
            db.Departamentos.Add(dep);
            db.SaveChanges();
           }
            else { MessageBox.Show("Solo Letras en #departamento"); }
        }

        private void Grid_Loaded_1(object sender, RoutedEventArgs e)
        {
            demoEF db=new demoEF();
            CbDepartamentos.ItemsSource = db.Departamentos.ToList();
            CbDepartamentos.DisplayMemberPath = "Nombre";
            CbDepartamentos.SelectedValuePath = "id";
        }
        }
    }

