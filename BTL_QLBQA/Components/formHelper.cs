using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_QLBQA.Components
{
    class formHelper
    {
        public static void comboBoxLoad<T>(ComboBox comboBox, List<T> valueData, string value = "id", string text = "Name") where T : class
        {
            if (typeof(List<T>).IsAssignableFrom(valueData.GetType()))
            {
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox.DataSource = valueData;
                comboBox.ValueMember = value;
                comboBox.DisplayMember = text;
                if (comboBox.Items.Count > 0)
                {
                    comboBox.SelectedIndex = 0;
                }
            }
        }
        public static void loadGroupBox(GroupBox groupBox)
        {
            foreach (var item in groupBox.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Clear();
                }
                if (item is ComboBox)
                {
                    if (((ComboBox)item).Items.Count > 0)
                        ((ComboBox)item).SelectedIndex = 0;
                }
                if (item is DateTimePicker)
                {
                    ((DateTimePicker)item).Value = DateTime.Now;
                }
            }
        }
    }
}
