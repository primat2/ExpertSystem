using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BestExpertSystem
{
    class DataBaseWorker
    {

        public static string connectionString = "Server=tcp:primatserver.database.windows.net,1433;Initial Catalog=ExpertSystemDB;Persist Security Info=False;User ID=primat;Password=Ilyamechmat90;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


        public static IPAddress GetServerIP()
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();

                string sql = "SELECT * FROM FreeServers WHERE server_load = (SELECT MIN(server_load) FROM FreeServers)";
                SqlCommand sqlCommand = new SqlCommand(sql, cnn);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                reader.Read();
                string strIp = (string)reader.GetValue(1);

                var ipAddress = IPAddress.Parse(strIp);
                cnn.Close();
                return ipAddress;
            }

        }


        public static void LoadData(int EsID, MODEL.MemoryComponent memory)
        {
            memory.domains = new DATA_TYPES.OrderedList<MODEL.Domain>();
            memory.variables = new DATA_TYPES.OrderedList<MODEL.Variable>();
            memory.rules = new DATA_TYPES.OrderedList<MODEL.Rule>();

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();

                // *** GETTING DOMAINS ***
                string sqlGetDomainsCount = "SELECT COUNT(*) FROM VarDomains WHERE VarDomains.es_id = @esID";
                SqlCommand sqlCommand = new SqlCommand(sqlGetDomainsCount, cnn);
                sqlCommand.Parameters.AddWithValue("@esID", EsID);
                int numberOfDomains = (int)sqlCommand.ExecuteScalar();

                string getDomainList = "SELECT * FROM VarDomains WHERE VarDomains.es_id = @esID";
                SqlCommand getDomainListCommand = new SqlCommand(getDomainList, cnn);
                getDomainListCommand.Parameters.AddWithValue("@esID", EsID);
                var domainListReader = getDomainListCommand.ExecuteReader();
                List<int> idList = new List<int>();
                List<string> nameList = new List<string>();

                while (domainListReader.Read())
                {
                    idList.Add(int.Parse(domainListReader.GetValue(0).ToString()));
                    nameList.Add(domainListReader.GetValue(1).ToString());
                }
                domainListReader.Close();


                for (int i = 1; i <= numberOfDomains; i++)
                {
                    int domID = idList[i - 1];

                    MODEL.Domain newDomain;
                    string domainName = "";
                    List<string> domainValues = new List<string>();

                    //string sql_getDomains = "SELECT * FROM VarDomains JOIN DomainValues ON VarDomains.id = DomainValues.domain_id WHERE VarDomains.id = @domID AND DomainValues.es_id = @esID";
                    string sql_getDomains = "SELECT * FROM DomainValues WHERE DomainValues.es_id = @esID AND DomainValues.domain_id = @domID";
                    SqlCommand sqlCommand2 = new SqlCommand(sql_getDomains, cnn);
                    sqlCommand2.Parameters.AddWithValue("@domID", domID);
                    sqlCommand2.Parameters.AddWithValue("@esID", EsID);
                    SqlDataReader reader = sqlCommand2.ExecuteReader();

                    while (reader.Read())
                    {
                        //domainName = (string)reader.GetValue(reader.GetOrdinal("name"));
                        string domainValue = (string)reader.GetValue(reader.GetOrdinal("value"));
                        domainValues.Add(domainValue);

                    }

                    newDomain = new MODEL.Domain(nameList[i - 1], domainValues);
                    memory.domains.Add(newDomain);
                    reader.Close();
                }


                // *** GETTING VARIABLES ***

                //string sql_getVariables = "SELECT * FROM (SELECT * FROM Variables WHERE Variables.es_id = @esID) t1 JOIN(SELECT row_number() OVER(ORDER BY id) as num, name FROM VarDomains WHERE VarDomains.es_id = @esID) t2 ON t1.domain_id = t2.num";
                string sql_getVariables = "SELECT * FROM Variables JOIN VarDomains ON Variables.domain_id = VarDomains.id AND Variables.es_id = @esID";
                SqlCommand sqlCommandVars = new SqlCommand(sql_getVariables, cnn);
                sqlCommandVars.Parameters.AddWithValue("@esID", EsID);
                SqlDataReader readerVars = sqlCommandVars.ExecuteReader();

                while (readerVars.Read())
                {
                    string varName = (string)readerVars.GetValue(readerVars.GetOrdinal("name"));
                    string question = (string)readerVars.GetValue(readerVars.GetOrdinal("question"));
                    string domainName = (string)readerVars.GetValue(8);
                    string var_type = (string)readerVars.GetValue(readerVars.GetOrdinal("var_type"));

                    var newVar = new MODEL.Variable(varName, question, memory.ParseDomain(domainName), memory.ParseVarType(var_type));
                    memory.variables.Add(newVar);
                }
                readerVars.Close();


                // *** GETTING RULES ***
                List<MODEL.Fact> premises = new List<MODEL.Fact>();
                List<MODEL.Fact> conclusions = new List<MODEL.Fact>();

                // GETTING THE NUMBER OF RULES
                string sqlNumOfRules = "SELECT COUNT(DISTINCT rule_id) FROM Facts WHERE Facts.es_id = @esID";
                SqlCommand commandNumOfFacts = new SqlCommand(sqlNumOfRules, cnn);
                commandNumOfFacts.Parameters.AddWithValue("@esID", EsID);
                int numberOfRules = (int)commandNumOfFacts.ExecuteScalar();

                string getRulesList = "SELECT * FROM EsRules WHERE EsRules.es_id = @esID";
                SqlCommand getRulesListCommand = new SqlCommand(getRulesList, cnn);
                getRulesListCommand.Parameters.AddWithValue("@esID", EsID);
                var RulesListReader = getRulesListCommand.ExecuteReader();
                List<int> rulesIdList = new List<int>();

                while (RulesListReader.Read())
                {
                    rulesIdList.Add(int.Parse(RulesListReader.GetValue(0).ToString()));
                }
                RulesListReader.Close();


                for (int i = 1; i <= numberOfRules; i++)
                {
                    int ruleID = rulesIdList[i - 1];
                    premises = new List<MODEL.Fact>();
                    conclusions = new List<MODEL.Fact>();

                    string ruleName = "";
                    string explain = "";
                    // GETTING NAME AND EXPLAIN
                    string ruleInfo = "SELECT * FROM EsRules WHERE EsRules.id = @ruleID AND EsRules.es_id = @esID";
                    SqlCommand ruleInfoCommand = new SqlCommand(ruleInfo, cnn);
                    ruleInfoCommand.Parameters.AddWithValue("@ruleID", ruleID);
                    ruleInfoCommand.Parameters.AddWithValue("@esID", EsID);
                    SqlDataReader ruleInfoReader = ruleInfoCommand.ExecuteReader();
                    ruleInfoReader.Read();
                    ruleName = (string)ruleInfoReader.GetValue(ruleInfoReader.GetOrdinal("name"));
                    explain = (string)ruleInfoReader.GetValue(ruleInfoReader.GetOrdinal("explain"));
                    ruleInfoReader.Close();

                    // GETTING PREMISES
                    string sqlPremisesFacts = "SELECT * FROM Facts JOIN Variables ON Facts.var_id = Variables.id WHERE Facts.rule_id = @ruleID AND Facts.is_premise = 1 AND Facts.es_id = @esID";
                    SqlCommand commandPremisesFacts = new SqlCommand(sqlPremisesFacts, cnn);
                    commandPremisesFacts.Parameters.AddWithValue("@ruleID", ruleID);
                    commandPremisesFacts.Parameters.AddWithValue("@esID", EsID);
                    SqlDataReader readerPremisesFacts = commandPremisesFacts.ExecuteReader();

                    while (readerPremisesFacts.Read())
                    {
                        string varName = (string)readerPremisesFacts.GetValue(readerPremisesFacts.GetOrdinal("name"));
                        string factValue = (string)readerPremisesFacts.GetValue(readerPremisesFacts.GetOrdinal("value"));

                        var newFact = new MODEL.Fact(memory.ParseVariable(varName), new MODEL.VariableValue(factValue));
                        premises.Add(newFact);
                    }
                    readerPremisesFacts.Close();

                    // GETTING CONCLUSIONS
                    string sqlConclusionFacts = "SELECT * FROM Facts JOIN Variables ON Facts.var_id = Variables.id WHERE Facts.rule_id = @ruleID AND Facts.is_premise = 0 AND Facts.es_id = @esID";
                    SqlCommand commandConclusionFacts = new SqlCommand(sqlConclusionFacts, cnn);
                    commandConclusionFacts.Parameters.AddWithValue("@ruleID", ruleID);
                    commandConclusionFacts.Parameters.AddWithValue("@esID", EsID);
                    SqlDataReader readerConclusionFacts = commandConclusionFacts.ExecuteReader();

                    while (readerConclusionFacts.Read())
                    {
                        string varName = (string)readerConclusionFacts.GetValue(readerConclusionFacts.GetOrdinal("name"));
                        string factValue = (string)readerConclusionFacts.GetValue(readerConclusionFacts.GetOrdinal("value"));

                        var newFact = new MODEL.Fact(memory.ParseVariable(varName), new MODEL.VariableValue(factValue));
                        conclusions.Add(newFact);
                    }
                    readerConclusionFacts.Close();

                    var newRule = new MODEL.Rule(ruleName, premises, conclusions, explain);
                    memory.rules.Add(newRule);
                }


                cnn.Close();
            }

        }


        public static async void WriteToBD(int ownerID, string EsName, MODEL.MemoryComponent memory)
        {
            ownerID = 1;

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();

                string createES_sql = "INSERT INTO ExpertSystems(name, owner_id) output INSERTED.ID VALUES (@name, @owner_id)";
                SqlCommand createES_command = new SqlCommand(createES_sql, cnn);
                createES_command.Parameters.AddWithValue("@name", EsName);
                createES_command.Parameters.AddWithValue("@owner_id", ownerID);
                int esID = (int) await createES_command.ExecuteScalarAsync();

                foreach (var dom in memory.domains)
                {
                    string insertDomain_sql = @"INSERT INTO VarDomains(name, order_item, es_id)
                                                VALUES (@domName,@domOrder, @esID)";
                    SqlCommand insertDomain_command = new SqlCommand(insertDomain_sql, cnn);
                    insertDomain_command.Parameters.AddWithValue("@domName", dom.name);
                    insertDomain_command.Parameters.AddWithValue("@domOrder", dom.Order);
                    insertDomain_command.Parameters.AddWithValue("@esID", esID);
                    insertDomain_command.ExecuteNonQuery();
                }


                foreach (var vary in memory.variables)
                {
                    string getDomainId_sql = "SELECT id FROM VarDomains WHERE VarDomains.name = @domainName";
                    SqlCommand getDomainId_command = new SqlCommand(getDomainId_sql, cnn);
                    getDomainId_command.Parameters.AddWithValue("@domainName", vary.domain.name);
                    int domain_id = (int)getDomainId_command.ExecuteScalar();

                    string insertVariable_sql = @"INSERT INTO Variables (name,order_item,question,domain_id,var_type, es_id)
                                                    VALUES (@name, @order, @question, @domain_id, @var_type, @es_id)";
                    SqlCommand insertVariable_command = new SqlCommand(insertVariable_sql, cnn);
                    insertVariable_command.Parameters.AddWithValue("@name", vary.name);
                    insertVariable_command.Parameters.AddWithValue("@order", vary.Order);
                    insertVariable_command.Parameters.AddWithValue("@question", vary.question);
                    insertVariable_command.Parameters.AddWithValue("@domain_id", domain_id);
                    insertVariable_command.Parameters.AddWithValue("@var_type", vary.variableType.ToString());
                    insertVariable_command.Parameters.AddWithValue("@es_id", esID);
                    insertVariable_command.ExecuteNonQuery();
                }


                foreach (var rule in memory.rules)
                {
                    string insertRule_sql = @"INSERT INTO EsRules(name, order_item, explain, es_id)
                                                VALUES (@name, @ruleOrder, @explain, @esID)";
                    SqlCommand insertRule_command = new SqlCommand(insertRule_sql, cnn);
                    insertRule_command.Parameters.AddWithValue("@name", rule.name);
                    insertRule_command.Parameters.AddWithValue("@ruleOrder", rule.Order);
                    insertRule_command.Parameters.AddWithValue("@explain", rule.explain);
                    insertRule_command.Parameters.AddWithValue("@esID", esID);
                    insertRule_command.ExecuteNonQuery();
                }

                foreach (var dom in memory.domains)
                {
                    string getDomainId_sql = "SELECT id FROM VarDomains WHERE VarDomains.name = @domainName";
                    SqlCommand getDomainId_command = new SqlCommand(getDomainId_sql, cnn);
                    getDomainId_command.Parameters.AddWithValue("@domainName", dom.name);
                    int domain_id = (int)getDomainId_command.ExecuteScalar();

                    foreach (var val in dom.values)
                    {
                        string insertDomValue_sql = @"INSERT INTO DomainValues(domain_id, value, es_id)
                                                        VALUES (@domain_id, @domValue, @esID)";
                        SqlCommand insertDomValue_command = new SqlCommand(insertDomValue_sql, cnn);
                        insertDomValue_command.Parameters.AddWithValue("@domain_id", domain_id);
                        insertDomValue_command.Parameters.AddWithValue("@domValue", val.Value.ToString());
                        insertDomValue_command.Parameters.AddWithValue("@esID", esID);
                        insertDomValue_command.ExecuteNonQuery();
                    }
                }

                foreach (var rule in memory.rules)
                {
                    string getRuleId_sql = "SELECT id FROM EsRules WHERE EsRules.name = @ruleName";
                    SqlCommand getRuleId_command = new SqlCommand(getRuleId_sql, cnn);
                    getRuleId_command.Parameters.AddWithValue("@ruleName", rule.name);
                    int ruleID = (int)getRuleId_command.ExecuteScalar();

                    foreach (var ant in rule.antecedents)
                    {
                        string getFactVarId_sql = "SELECT id FROM Variables WHERE Variables.name = @factVarName";
                        //string getFactVarId_sql = "SELECT id FROM VarDomains WHERE VarDomains.name = @factVarName";
                        SqlCommand getFactVarId_command = new SqlCommand(getFactVarId_sql, cnn);
                        getFactVarId_command.Parameters.AddWithValue("@factVarName", ant.Variable.name);
                        int factVarId = (int)getFactVarId_command.ExecuteScalar();

                        string insertFacts_sql = @"INSERT INTO Facts(var_id, value, is_premise, rule_id, es_id)
                                                    VALUES (@var_id, @value, @is_premise, @rule_id, @es_id)";
                        SqlCommand insertFacts_command = new SqlCommand(insertFacts_sql, cnn);
                        insertFacts_command.Parameters.AddWithValue("@var_id", factVarId);
                        insertFacts_command.Parameters.AddWithValue("@value", ant.DomainValue.Value);
                        insertFacts_command.Parameters.AddWithValue("@is_premise", true);
                        insertFacts_command.Parameters.AddWithValue("@rule_id", ruleID);
                        insertFacts_command.Parameters.AddWithValue("@es_id", esID);
                        insertFacts_command.ExecuteNonQuery();
                    }

                    foreach (var des in rule.descendants)
                    {
                        string getFactVarId_sql = "SELECT id FROM Variables WHERE Variables.name = @factVarName";
                        SqlCommand getFactVarId_command = new SqlCommand(getFactVarId_sql, cnn);
                        getFactVarId_command.Parameters.AddWithValue("@factVarName", des.Variable.name);
                        int factVarId = (int)getFactVarId_command.ExecuteScalar();

                        string insertFacts_sql = @"INSERT INTO Facts(var_id, value, is_premise, rule_id, es_id)
                                                    VALUES (@var_id, @value, @is_premise, @rule_id, @es_id)";
                        SqlCommand insertFacts_command = new SqlCommand(insertFacts_sql, cnn);
                        insertFacts_command.Parameters.AddWithValue("@var_id", factVarId);
                        insertFacts_command.Parameters.AddWithValue("@value", des.DomainValue.Value);
                        insertFacts_command.Parameters.AddWithValue("@is_premise", false);
                        insertFacts_command.Parameters.AddWithValue("@rule_id", ruleID);
                        insertFacts_command.Parameters.AddWithValue("@es_id", esID);
                        insertFacts_command.ExecuteNonQuery();
                    }
                }


                cnn.Close();
            }

            // method end
        }



        public static void DeleteFromBD(int ownerID, int esID, MODEL.MemoryComponent memory)
        {

        }

    }
}
