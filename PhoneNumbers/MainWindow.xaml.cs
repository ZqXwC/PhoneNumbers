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


namespace PhoneNumbers
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (var context = new NameEntities())
            {
                var contact = context.Сontacts.FirstOrDefault(c => c.PhoneNumber.ToString() == hto.Text);
                if (contact == null)
                    return;
                else
                    zxc.Text = contact.Name;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new NameEntities())
            {
                var contact = new Сontacts()
                {
                    PhoneNumber = Convert.ToInt32(hto.Text),
                    Name = qwe.Text
                };

                context.Сontacts.Add(contact);
                context.SaveChanges();
            }
        }

        private void qwe_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (var context = new NameEntities())
            {
                var contact = context.Сontacts.FirstOrDefault(c => c.Name == qwe.Text);
                if (contact == null)
                    return;
                else
                    zxc.Text = contact.PhoneNumber.ToString();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (var context = new NameEntities())
            {
                var contact = context.Сontacts.FirstOrDefault(c => c.PhoneNumber.ToString() == hto.Text);
                if (contact == null)
                    return;

                MessageBox.Show($"Контакт {contact.Name} удалён");
                context.Сontacts.Remove(contact);
                context.SaveChanges();
            }
        }
    }
}
