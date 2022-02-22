using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestExpertSystem.MODEL
{
    public class MemoryComponent
    {
        public static MemoryComponent instance;

        public delegate void ModelChanged();
        public event ModelChanged rulesChanged;
        public event ModelChanged variablesChanged;
        public event ModelChanged domainsChanged;


        public DATA_TYPES.OrderedList<MODEL.Rule> rules;
        public DATA_TYPES.OrderedList<MODEL.Variable> variables;
        public DATA_TYPES.OrderedList<MODEL.Domain> domains;


        public Variable GoalVariable { get; set; }
        public List<Fact> TrueFacts { get; set; }
        public List<Rule> UntriggeredRules { get; set; }
        public List<Rule> TriggeredRules { get; }
        public Dictionary<Variable, Rule> InferenceDictionary { get; }


        public MemoryComponent()
        {
            instance = this;
            this.TrueFacts = new List<Fact>();
            this.UntriggeredRules = new List<Rule>();
            this.TriggeredRules = new List<Rule>();
            this.InferenceDictionary = new Dictionary<Variable, Rule>();
        }

        public DATA_TYPES.OrderedList<MODEL.Domain> GetDomainList()
        {
            return domains;
        }

        public DATA_TYPES.OrderedList<MODEL.Rule> GetRuleList()
        {
            return rules;
        }

        public void AddOrUpdateDomain(MODEL.Domain domain)
        {
            if (domain.Order == -1)
            {
                domains.Add(domain);
                domain.Order = domains.Count;
            }
            else
            {
                var domainToChange = domains.Find(t => t.Order == domain.Order) as MODEL.Domain;
                domainToChange.name = domain.name;
                domainToChange.values = domain.values;
            }

            domainsChanged?.Invoke();
        }


        public void AddOrUpdateVariable(MODEL.Variable variable)
        {
            if (variable.Order == -1)
            {
                variables.Add(variable);
                variable.Order = variables.Count;
            }
            else
            {
                var varToChange = variables.Find(t => t.Order == variable.Order) as MODEL.Variable;
                varToChange.name = variable.name;
                varToChange.question = variable.question;
                varToChange.domain = variable.domain;
                varToChange.variableType = variable.variableType;
            }
            variablesChanged?.Invoke();

        }


        public void AddOrUpdateRule(MODEL.Rule rule)
        {
            if (rule.Order == -1)
            {
                rules.Add(rule);
                rule.Order = rules.Count;
            }
            else
            {
                var ruleToChange = rules.Find(t => t.Order == rule.Order) as MODEL.Rule;
                ruleToChange.name = rule.name;
                ruleToChange.antecedents = rule.antecedents;
                ruleToChange.descendants = rule.descendants;
                ruleToChange.explain = rule.explain;
            }
            rulesChanged?.Invoke();
        }

        //public void AddOrUpdateFact(MODEL.Fact fact)
        //{
        //    if (fact.Order == -1)
        //    {
        //        variables.Add(variable);
        //        variable.Order = domains.Count;
        //    }
        //    else
        //    {
        //        var varToChange = variables.Find(t => t.Order == variable.Order) as MODEL.Variable;
        //        varToChange.name = variable.name;
        //        varToChange.question = variable.question;
        //        varToChange.domain = variable.domain;
        //        varToChange.variableType = variable.variableType;
        //    }
        //    variablesChanged?.Invoke();

        //}


        public void DeleteItem<T>(int index)
        {
            if (typeof(T) == typeof(MODEL.Variable))
            {
                variables.RemoveAt(index);
                variablesChanged?.Invoke();
            }
            else if (typeof(T) == typeof(MODEL.Rule))
            {
                rules.RemoveAt(index);
                rulesChanged?.Invoke();
            }
            else if (typeof(T) == typeof(MODEL.Domain))
            {
                domains.RemoveAt(index);
                domainsChanged?.Invoke();
            }
        }


        public Domain ParseDomain(string domain)
        {
            foreach (Domain dom in domains)
            {
                if (domain == dom.name)
                {
                    return dom;
                }
            }
            throw new Exception("Cannot cast");
        }

        public VariableType ParseVarType(string varType)
        {
            if (varType == VariableType.Deducible.ToString()) return VariableType.Deducible;
            if (varType == VariableType.Requested.ToString()) return VariableType.Requested;
            if (varType == VariableType.RequestedDeducible.ToString()) return VariableType.RequestedDeducible;

            throw new Exception("Cannot cast");
        }

        public Variable ParseVariable(string strVar)
        {
            foreach (Variable vari in variables)
            {
                if (strVar == vari.name)
                {
                    return vari;
                }
            }
            throw new Exception("Cannot cast");
        }

    }
}
