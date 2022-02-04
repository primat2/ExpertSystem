using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;


namespace BestExpertSystem.UI_LOGICK
{
    public class UI_Domain
    {

        private MODEL.MemoryComponent memory;


        public Application mainForm;


        public UI_Domain(Application form)
        {
            mainForm = form;
            memory = MODEL.MemoryComponent.instance;
        }


        private void AddOrUpdate(DomainAddForm myHappyNewForm, MODEL.Domain domainToChange = null)
        {
            MODEL.Domain newDomain;
            int order = domainToChange == null ? -1 : domainToChange.Order;

            DialogResult dResult = myHappyNewForm.ShowDialog();
            if (dResult == DialogResult.OK)
            {
                string name = myHappyNewForm.DomainName.Text;
                List<string> values = Util.ListViewToList(myHappyNewForm.DomainListView);
                newDomain = new MODEL.Domain(order, name, values);

                memory.AddOrUpdateDomain(newDomain);
            }
        }

        public void ChangeDomain(MODEL.Domain domainToChange)
        {
            var myHappyNewForm = new DomainAddForm(domainToChange);
            AddOrUpdate(myHappyNewForm, domainToChange);
        }

        public void AddDomain()
        {
            var myHappyNewForm = new DomainAddForm();
            AddOrUpdate(myHappyNewForm);
        }

    }
}
