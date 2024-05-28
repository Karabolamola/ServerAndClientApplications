using System.Reflection;
using System.Text;

namespace ServerAndClientApplications.Infrastructure.Helpers;

public class TableGenerator
{
    private Dictionary<Type, string> DataMapper
    {
        get
        {
            // Add the rest of your CLR to SQL Types mappings here
            Dictionary<Type, string> dataMapper = new Dictionary<Type, string>
            {
                { typeof(int), "BIGINT" },
                { typeof(string), "NVARCHAR(500)" },
                { typeof(bool), "BIT" },
                { typeof(DateTime), "DATETIME" },
                { typeof(float), "FLOAT" },
                { typeof(decimal), "DECIMAL(18,0)" },
                { typeof(Guid), "UNIQUEIDENTIFIER" }
            };

            return dataMapper;
        }
    }

    public List<KeyValuePair<string, Type>> Fields { get; set; } = new List<KeyValuePair<string, Type>>();

    public string ClassName { get; set; } = string.Empty;

    public TableGenerator(Type t)
    {
        ClassName = t.Name;
        foreach (var p in t.GetProperties())
        {
            var field = new KeyValuePair<string, Type>();
            Fields.Add(field);
        }
    }

    public string CreateTableScript()
    {
        StringBuilder script = new StringBuilder();
        script.AppendLine($"CREATE TABLE {ClassName}");
        script.AppendLine("(");
        script.AppendLine("\t ID BIGINT,");
        for (var i = 0; i < Fields.Count; i++)
        {
            KeyValuePair<string, Type> field = Fields[i];
            if (DataMapper.ContainsKey(field.Value))
            {
                script.Append($"\t {field.Key} {DataMapper[field.Value]}");
            }
            else
            {
                // Complex Type?
                script.Append($"\t {field.Key} BIGINT");
            }

            if (i != Fields.Count - 1)
            {
                script.Append(",");
            }

            script.Append(Environment.NewLine);
        }

        script.AppendLine(")");
        return script.ToString();
    }
}

public class RunTableGenerator
{
    public void Run(string[] args)
    {
        List<TableGenerator> tables = new List<TableGenerator>();

        // Pass assembly name via argument
        Assembly a = Assembly.LoadFile(args[0]);

        Type[] types = a.GetTypes();

        // Get Types in the assembly.
        foreach (Type t in types)
        {
            TableGenerator tc = new TableGenerator(t);                
            tables.Add(tc);
        }

        // Create SQL for each table
        foreach (TableGenerator table in tables)
        {
            Console.WriteLine(table.CreateTableScript());
            Console.WriteLine();
        }

        // Total Hacked way to find FK relationships! Too lazy to fix right now
        foreach (TableGenerator table in tables)
        {
            foreach (KeyValuePair<String, Type> field in table.Fields)
            {
                foreach (TableGenerator t2 in tables)
                {
                    if (field.Value.Name == t2.ClassName)
                    {
                        // We have a FK Relationship!
                        Console.WriteLine("GO");
                        Console.WriteLine("ALTER TABLE " + table.ClassName + " WITH NOCHECK");
                        Console.WriteLine("ADD CONSTRAINT FK_" + field.Key + " FOREIGN KEY (" + field.Key + ") REFERENCES " + t2.ClassName + "(ID)");
                        Console.WriteLine("GO");

                    }
                }
            }
        }
    }
}