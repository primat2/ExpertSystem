using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BestExpertSystem
{
    enum ReadingState { None, Domains, Variables, Rules };

    class FileParser
    {
        //static string path = "D:\\4_YEAR\\NewExpertSystem\\ExpertSystem\\BestExpertSystem\\BestExpertSystem\\IntegralES.mes";

        public static void Parse(MODEL.MemoryComponent memory)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "D:\\4_YEAR\\NewExpertSystem\\ExpertSystem\\BestExpertSystem\\BestExpertSystem";
            openFileDialog1.Filter = "My expert system files |*.mes";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = openFileDialog1.FileName;

                StreamReader reader = new StreamReader(selectedFileName);
                ReadingState state = ReadingState.None;

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    //if (line == "\n" || line == "") continue;
                    if (line == "***ENDBLOCK***")
                    {
                        reader.ReadLine();
                        reader.ReadLine();
                        continue;
                    }

                    if (line == "DOMAINS")
                    {
                        state = ReadingState.Domains;
                        continue;
                    }
                    if (line == "VARIABLES")
                    {
                        state = ReadingState.Variables;
                        continue;
                    }
                    if (line == "RULES")
                    {
                        state = ReadingState.Rules;
                        continue;
                    }
                    if (line == "ENDALL")
                    {
                        state = ReadingState.None;
                        break;
                    }

                    if (state == ReadingState.Domains)
                    {
                        string name = string.Join(" ", reader.ReadLine().Split().Skip(1).ToArray());
                        var values = new List<MODEL.VariableValue>();
                        string domainLine = reader.ReadLine();

                        while (domainLine != "===")
                        {
                            values.Add(new MODEL.VariableValue(domainLine));
                            domainLine = reader.ReadLine();
                        }

                        MODEL.Domain newDomain = new MODEL.Domain(name, values);
                        memory.domains.Add(newDomain);
                    }
                    else if (state == ReadingState.Variables)
                    {
                        string name = string.Join(" ", reader.ReadLine().Split().Skip(1).ToArray());
                        string domain = reader.ReadLine();
                        string question = reader.ReadLine();
                        string type = reader.ReadLine();

                        var newVar = new MODEL.Variable(
                            name, question, memory.ParseDomain(domain), memory.ParseVarType(type));
                        memory.variables.Add(newVar);
                        reader.ReadLine();
                    }
                    else if (state == ReadingState.Rules)
                    {
                        string name = string.Join(" ", reader.ReadLine().Split().Skip(1).ToArray());
                        var premises = new List<MODEL.Fact>();
                        var sequences = new List<MODEL.Fact>();
                        reader.ReadLine(); // skipping "PRE" text
                        string readLine = string.Empty;

                        readLine = reader.ReadLine();

                        while (readLine != "SEQ")
                        {
                            string vary = readLine.Split(new char[] { '=' }, 2)[0];
                            string value = readLine.Split(new char[] { '=' }, 2)[1];
                            premises.Add(new MODEL.Fact(memory.ParseVariable(vary), new MODEL.VariableValue(value)));
                            readLine = reader.ReadLine();
                        }

                        readLine = reader.ReadLine();

                        while (readLine != "===")
                        {
                            string vary = readLine.Split(new char[] { '=' }, 2)[0];
                            string value = readLine.Split(new char[] { '=' }, 2)[1];
                            sequences.Add(new MODEL.Fact(memory.ParseVariable(vary), new MODEL.VariableValue(value)));
                            readLine = reader.ReadLine();
                        }

                        var newRule = new MODEL.Rule(name, premises, sequences, "<rule explain>");
                        memory.rules.Add(newRule);
                    }
                }
                reader.Close();

            }
        }


        public static void Write(MODEL.MemoryComponent memory)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            StreamWriter writer = null;

            saveFileDialog1.InitialDirectory = "D:\\4_YEAR\\NewExpertSystem\\ExpertSystem\\BestExpertSystem\\BestExpertSystem";
            saveFileDialog1.Filter = "My expert system files |*.mes";
            saveFileDialog1.FilterIndex = 0;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = saveFileDialog1.FileName;
                writer = new StreamWriter(selectedFileName);

                writer.WriteLine("DOMAINS");
                
                //writer.WriteLine();

                foreach (var domain in memory.domains)
                {
                    writer.WriteLine();
                    writer.WriteLine($"DOMAIN {domain.name}");
                    foreach (var val in domain.values)
                    {
                        writer.WriteLine(val.value);
                    }
                    writer.WriteLine("===");
                }
                writer.WriteLine("***ENDBLOCK***");



                writer.WriteLine();
                writer.WriteLine();
                writer.WriteLine("VARIABLES");

                foreach (var vary in memory.variables)
                {
                    writer.WriteLine();
                    writer.WriteLine($"VARIABLE {vary.name}");
                    writer.WriteLine(vary.domain.name);
                    writer.WriteLine(vary.question);
                    writer.WriteLine(vary.variableType.ToString());
                    writer.WriteLine("===");
                }
                writer.WriteLine("***ENDBLOCK***");


                writer.WriteLine();
                writer.WriteLine();
                writer.WriteLine("RULES");

                foreach (var rule in memory.rules)
                {
                    writer.WriteLine();
                    writer.WriteLine($"RULE {rule.name}");
                    writer.WriteLine("PRE");
                    foreach (var fact in rule.antecedents)
                    {
                        writer.WriteLine($"{fact.Variable}={fact.DomainValue.ToString()}");
                    }
                    writer.WriteLine("SEQ");
                    foreach (var fact in rule.descendants)
                    {
                        writer.WriteLine($"{fact.Variable}={fact.DomainValue.ToString()}");
                    }

                    writer.WriteLine("===");
                }
                writer.WriteLine("***ENDBLOCK***");
            }

            if (writer != null) writer.Close();

        }
    }
}
