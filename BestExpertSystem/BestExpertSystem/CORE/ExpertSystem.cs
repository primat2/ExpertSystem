using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestExpertSystem.CORE
{
    public class ExpertSystem
    {
        public MODEL.MemoryComponent workingMemory;
        private ConsultationForm consultationForm;


        public ExpertSystem(MODEL.MemoryComponent memory)
        {
            this.workingMemory = memory;
        }

        public void InitES(ConsultationForm ConsultationForm)
        {
            consultationForm = ConsultationForm;
            workingMemory.UntriggeredRules = workingMemory.rules.ToList();
        }

        public void DeduceGoalVariable(MODEL.Variable variable)
        {
            workingMemory.GoalVariable = variable;
            var domainValue = Deduce(variable);
            consultationForm.VariableDeduced(domainValue);
        }


        private MODEL.VariableValue Deduce(MODEL.Variable variable)
        {
            var fact = workingMemory
                .TrueFacts
                .FirstOrDefault(x => x.Variable == variable);

            if (fact != null)
            {
                return fact.DomainValue;
            }

            if (variable.variableType == MODEL.VariableType.Requested)
            {
                //var domainValue = this.RequestVariable(variable);
                //MODEL.VariableValue domainValue = new MODEL.VariableValue("123");
                MODEL.VariableValue domainValue = consultationForm.AskNextQuestion(variable);
                var newFact = new MODEL.Fact(variable, domainValue);
                workingMemory.TrueFacts.Add(newFact);

                return domainValue;
            }

            foreach (var rule in workingMemory
                .UntriggeredRules
                .Where(r => r.descendants.Any(c => c.Variable == variable))
                .ToList())
            {
                var source = TryApplyRule(rule);
                if (source != null)
                {
                    workingMemory.TrueFacts.AddRange(source);
                    return source.First(x => x.Variable == variable).DomainValue;
                }
            }

            // Если вывести не получилось - не беда, запросим!
            if (variable.variableType == MODEL.VariableType.RequestedDeducible)
            {
                MODEL.VariableValue domainValue = consultationForm.AskNextQuestion(variable);

                var newFact = new MODEL.Fact(variable, domainValue);
                workingMemory.TrueFacts.Add(newFact);

                return domainValue;
            }

            return null;
        }


        private List<MODEL.Fact> TryApplyRule(MODEL.Rule rule)
        {
            workingMemory.UntriggeredRules.Remove(rule);
            foreach (var fact in rule.antecedents)
            {
                // Посмотрим, вдруг посылка правила нам уже известна
                var fact2 = workingMemory
                    .TrueFacts
                    .FirstOrDefault(x => x.Variable == fact.Variable);

                // Если правда известна, то шик, идём дальше
                // Если не известна, то что поделать - пытаемся вывести
                var domainValue = fact2 != null ? fact2.DomainValue : Deduce(fact.Variable);
                if (fact.DomainValue.value != domainValue.value)
                {
                    return null;
                }
            }

            foreach (var fact in rule.descendants)
            {
                workingMemory.InferenceDictionary[fact.Variable] = rule;
            }

            return rule.descendants.ToList();
        }

    }
}
