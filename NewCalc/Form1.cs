using DataBase.Models;
using DataBase.NHibernate.Repositories;
using NewCalc.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewCalc
{
    public partial class Form1 : Form
    {
        private Calc calc;

        private NHBaseRepository Repository = new NHBaseRepository();

        public Form1()
        {
            InitializeComponent();
            calc = new Calc();

            //operations = new List<IOperation>();

            //Assembly asm = Assembly.GetExecutingAssembly();
            //var types = asm.GetTypes();
            //var typeOperation = typeof(IOperation);

            //foreach (var item in types.Where(t => !t.IsAbstract && !t.IsInterface))
            //{
            //    if (item.GetInterfaces().Any(t => t == typeOperation))
            //    {
            //        var obj = Activator.CreateInstance(item);
            //        var operation = obj as IOperation;
            //        if (operation != null) operations.Add(operation);
            //    }
            //}
            cbOperation.Items.Clear();
            cbOperation.Items.AddRange(calc.GetOperationsName());
            cbOperation.Text = cbOperation.Items[0].ToString();

            var history = Repository.GetAll();
            foreach (var historyItem in history)
            {
                tbHistory.AppendText($"{historyItem.NameOperation}({historyItem.Args}) = {historyItem.Result} | {historyItem.Time}\r\n");
            }

        }

        private void btExec_Click(object sender, EventArgs e)
        {
            var str = tbArgs.Text.Trim(' ');

            if (string.IsNullOrEmpty(str))
            {
                tbResult.Text = "Введите аргументы";
                return;
            }

            var args = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(s => Convert.ToDouble(s));

            var result = calc.Exec(cbOperation.Text, args.ToArray());

            tbResult.Text = result.ToString();

            HistoryItem item = new HistoryItem();
            item.Args = str;
            item.NameOperation = cbOperation.Text;
            item.Time = DateTime.Now;
            item.Result = (float?)result;

            Repository.Add(item);

            //получаем из базы историю
            var history = Repository.GetAll();
            tbHistory.Clear();
            foreach (var historyItem in history)
            {
                tbHistory.AppendText($"{historyItem.NameOperation}({historyItem.Args}) = {historyItem.Result} | {historyItem.Time}\r\n");
            }

        }

        private void tbArgs_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                btExec.PerformClick();
            }
        }
    }
}
